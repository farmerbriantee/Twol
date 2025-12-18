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
            cboZoomLevel.Items.Clear();
            cboZoomLevel.Items.Add("Level 16 - Low (~4m/pixel)");
            cboZoomLevel.Items.Add("Level 17 - Medium (~2m/pixel)");
            cboZoomLevel.Items.Add("Level 18 - High (~1m/pixel)");
            cboZoomLevel.Items.Add("Level 19 - Very High (~0.5m/pixel)");
            cboZoomLevel.SelectedIndex = 2; // Default to level 18

            // Calculate boundary coordinates from field boundaries
            if (!CalculateBoundaryCoordinates())
            {
                MessageBox.Show("No field boundaries defined.\nPlease create boundaries first.",
                    "No Boundaries", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            UpdateUI();
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
                case 3: return 19;
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
