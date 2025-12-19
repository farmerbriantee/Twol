using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twol.Mapping;

namespace Twol
{
    /// <summary>
    /// Form for downloading ESRI satellite imagery and creating GeoTIFF files.
    /// </summary>
    public partial class FormMapDownload : Form
    {
        private readonly FormGPS mf;
        private readonly ESRIDownloader downloader;
        private CancellationTokenSource cancellationTokenSource;
        private bool isDownloading;

        // Boundary coordinates in WGS84
        private double minLon, minLat, maxLon, maxLat;

        // Existing GeoTIFF state
        private bool geoTiffExists;
        private string existingGeoTiffPath;
        private long existingFileSize;

        /// <summary>
        /// Gets the path to the generated GeoTIFF file after successful download.
        /// </summary>
        public string GeneratedGeoTiffPath { get; private set; }

        public FormMapDownload(FormGPS callingForm)
        {
            mf = callingForm;
            downloader = new ESRIDownloader();
            downloader.ProgressChanged += Downloader_ProgressChanged;

            InitializeComponent();

            this.Text = "Download Satellite Imagery";
        }

        private void FormMapDownload_Load(object sender, EventArgs e)
        {
            // Initialize zoom level combo box
            // Note: ESRI World Imagery zoom 19+ is not available in many rural areas
            cboZoomLevel.Items.Clear();
            cboZoomLevel.Items.Add("Level 16 - Low (~4m/pixel)");
            cboZoomLevel.Items.Add("Level 17 - Medium (~2m/pixel)");
            cboZoomLevel.Items.Add("Level 18 - High (~1m/pixel)");
            cboZoomLevel.SelectedIndex = 2; // Default to level 18 (highest reliable coverage)

            // Calculate boundary coordinates from field boundaries
            if (!CalculateBoundaryCoordinates())
            {
                MessageBox.Show("No field boundaries defined.\nPlease create boundaries first.",
                    "No Boundaries", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            // Check if GeoTIFF already exists
            CheckExistingGeoTiff();

            UpdateUI();
        }

        /// <summary>
        /// Checks if a GeoTIFF already exists for this field and updates UI accordingly.
        /// </summary>
        private void CheckExistingGeoTiff()
        {
            string fieldPath = Path.Combine(RegistrySettings.fieldsDirectory, mf.currentFieldDirectory);
            existingGeoTiffPath = Path.Combine(fieldPath, "satellite.tif");
            geoTiffExists = File.Exists(existingGeoTiffPath);

            if (geoTiffExists)
            {
                var fileInfo = new FileInfo(existingGeoTiffPath);
                existingFileSize = fileInfo.Length;
                UpdateUIForExistingGeoTiff();
            }
            else
            {
                UpdateUIForNoGeoTiff();
            }
        }

        /// <summary>
        /// Updates UI when a GeoTIFF already exists.
        /// </summary>
        private void UpdateUIForExistingGeoTiff()
        {
            // Update title
            lblTitle.Text = "Manage Satellite Imagery";
            this.Text = "Manage Satellite Imagery";

            // Show existing panel
            panelExisting.Visible = true;
            lblExistingSize.Text = $"Size: {FormatFileSize(existingFileSize)}";

            // Update buttons
            btnDownload.Text = "Re-download";
            btnDelete.Visible = true;

            // Update status
            lblStatus.Text = "Satellite imagery is available for this field";
        }

        /// <summary>
        /// Updates UI when no GeoTIFF exists.
        /// </summary>
        private void UpdateUIForNoGeoTiff()
        {
            // Update title
            lblTitle.Text = "Download Satellite Imagery";
            this.Text = "Download Satellite Imagery";

            // Hide existing panel
            panelExisting.Visible = false;

            // Update buttons
            btnDownload.Text = "Download";
            btnDelete.Visible = false;

            // Update status
            lblStatus.Text = "Ready to download";
        }

        /// <summary>
        /// Calculates the bounding box from field boundaries and converts to WGS84.
        /// </summary>
        private bool CalculateBoundaryCoordinates()
        {
            if (mf.bnd.bndList.Count == 0 || mf.bnd.bndList[0].fenceLine.Count < 3)
                return false;

            // Find min/max in local coordinates
            double localMinE = double.MaxValue, localMaxE = double.MinValue;
            double localMinN = double.MaxValue, localMaxN = double.MinValue;

            foreach (var bndList in mf.bnd.bndList)
            {
                foreach (var pt in bndList.fenceLine)
                {
                    if (pt.easting < localMinE) localMinE = pt.easting;
                    if (pt.easting > localMaxE) localMaxE = pt.easting;
                    if (pt.northing < localMinN) localMinN = pt.northing;
                    if (pt.northing > localMaxN) localMaxN = pt.northing;
                }
            }

            // Add a small buffer (50 meters) around the boundaries
            const double buffer = 50.0;
            localMinE -= buffer;
            localMaxE += buffer;
            localMinN -= buffer;
            localMaxN += buffer;

            // Convert local coordinates to WGS84
            mf.pn.ConvertLocalToWGS84(localMinN, localMinE, out minLat, out minLon);
            mf.pn.ConvertLocalToWGS84(localMaxN, localMaxE, out maxLat, out maxLon);

            return true;
        }

        /// <summary>
        /// Updates the UI with current settings and estimates.
        /// </summary>
        private void UpdateUI()
        {
            // Display field name
            lblFieldName.Text = mf.currentFieldDirectory;

            // Display coordinates
            lblCoordinates.Text = $"{minLat:F5}°N - {maxLat:F5}°N / {minLon:F5}°E - {maxLon:F5}°E";

            // Calculate estimates
            int zoomLevel = GetSelectedZoomLevel();
            int tileCount = downloader.GetTileCount(minLon, minLat, maxLon, maxLat, zoomLevel);
            long estimatedSize = downloader.EstimateDownloadSize(minLon, minLat, maxLon, maxLat, zoomLevel);

            lblTileCount.Text = $"{tileCount} tiles";
            lblEstimatedSize.Text = FormatFileSize(estimatedSize);

            // Calculate resolution
            double resolutionMeters = 156543.03392 * Math.Cos(((minLat + maxLat) / 2) * Math.PI / 180) / Math.Pow(2, zoomLevel);
            lblResolution.Text = $"~{resolutionMeters:F2} m/pixel";
        }

        private int GetSelectedZoomLevel()
        {
            switch (cboZoomLevel.SelectedIndex)
            {
                case 0: return 16;
                case 1: return 17;
                case 2: return 18;
                default: return 18;
            }
        }

        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";
            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / (1024.0 * 1024.0):F1} MB";
            return $"{bytes / (1024.0 * 1024.0 * 1024.0):F2} GB";
        }

        private void cboZoomLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isDownloading)
                UpdateUI();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (isDownloading)
                return;

            // Check for internet connection before attempting download
            if (!mf.isInternetConnected)
            {
                MessageBox.Show(
                    "No internet connection available.\n\nPlease connect to the internet to download satellite imagery.",
                    "No Internet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Determine output path
            string fieldPath = Path.Combine(RegistrySettings.fieldsDirectory, mf.currentFieldDirectory);
            string geoTiffPath = Path.Combine(fieldPath, "satellite.tif");

            // Check if file already exists
            if (File.Exists(geoTiffPath))
            {
                var result = MessageBox.Show(
                    "A satellite image already exists for this field.\nDo you want to replace it?",
                    "File Exists",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                try
                {
                    // Unload the GeoTIFF first to release the file lock
                    mf.map.UnloadGeoTiff();

                    File.Delete(geoTiffPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Cannot delete existing file:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Start download
            isDownloading = true;
            btnDownload.Enabled = false;
            btnCancel.Text = "Cancel";
            cboZoomLevel.Enabled = false;
            progressBar.Value = 0;
            lblStatus.Text = "Starting download...";

            cancellationTokenSource = new CancellationTokenSource();
            int zoomLevel = GetSelectedZoomLevel();

            try
            {
                bool success = await downloader.DownloadFieldImageryAsync(
                    minLon, minLat, maxLon, maxLat,
                    geoTiffPath,
                    zoomLevel,
                    cancellationTokenSource.Token);

                if (success)
                {
                    GeneratedGeoTiffPath = geoTiffPath;
                    lblStatus.Text = "Download complete!";
                    progressBar.Value = 100;

                    // Mark download as complete BEFORE showing message and closing
                    // This prevents FormClosing from showing "cancel download?" dialog
                    isDownloading = false;

                    MessageBox.Show(
                        "Satellite imagery downloaded successfully!\nThe image will be loaded automatically.",
                        "Download Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblStatus.Text = "Download cancelled or failed.";
                    progressBar.Value = 0;
                }
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Download cancelled.";
                progressBar.Value = 0;

                // Clean up partial file
                if (File.Exists(geoTiffPath))
                {
                    try { File.Delete(geoTiffPath); } catch { }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Download failed.";
                progressBar.Value = 0;
                MessageBox.Show($"Download failed:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isDownloading = false;
                btnDownload.Enabled = true;
                btnCancel.Text = "Close";
                cboZoomLevel.Enabled = true;
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        private void Downloader_ProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateProgress(e)));
            }
            else
            {
                UpdateProgress(e);
            }
        }

        private void UpdateProgress(DownloadProgressEventArgs e)
        {
            progressBar.Value = Math.Min(e.ProgressPercent, 100);
            lblStatus.Text = e.Message;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                cancellationTokenSource?.Cancel();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isDownloading)
                return;

            var result = MessageBox.Show(
                "Delete satellite imagery for this field?\n\nThis cannot be undone.",
                "Delete Satellite Imagery",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (mf.map.DeleteFieldGeoTiff())
                {
                    MessageBox.Show("Satellite imagery deleted successfully.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Update UI to reflect deletion
                    geoTiffExists = false;
                    existingFileSize = 0;
                    UpdateUIForNoGeoTiff();

                    // Signal that changes were made
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to delete satellite imagery.\nThe file may be in use.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormMapDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDownloading)
            {
                var result = MessageBox.Show(
                    "Download is in progress. Are you sure you want to cancel?",
                    "Cancel Download",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                cancellationTokenSource?.Cancel();
            }
        }
    }
}
