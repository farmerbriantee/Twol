namespace Twol
{
    partial class FormMapDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFieldLabel = new System.Windows.Forms.Label();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.lblBoundsLabel = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblZoomLabel = new System.Windows.Forms.Label();
            this.cboZoomLevel = new System.Windows.Forms.ComboBox();
            this.lblTilesLabel = new System.Windows.Forms.Label();
            this.lblTileCount = new System.Windows.Forms.Label();
            this.lblSizeLabel = new System.Windows.Forms.Label();
            this.lblEstimatedSize = new System.Windows.Forms.Label();
            this.lblResLabel = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.panelExisting = new System.Windows.Forms.Panel();
            this.lblExistingLabel = new System.Windows.Forms.Label();
            this.lblExistingSize = new System.Windows.Forms.Label();
            this.lblExistingStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelExisting.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Download Satellite Imagery";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelInfo
            //
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelInfo.Controls.Add(this.lblFieldLabel);
            this.panelInfo.Controls.Add(this.lblFieldName);
            this.panelInfo.Controls.Add(this.lblBoundsLabel);
            this.panelInfo.Controls.Add(this.lblCoordinates);
            this.panelInfo.Controls.Add(this.lblZoomLabel);
            this.panelInfo.Controls.Add(this.cboZoomLevel);
            this.panelInfo.Controls.Add(this.lblTilesLabel);
            this.panelInfo.Controls.Add(this.lblTileCount);
            this.panelInfo.Controls.Add(this.lblSizeLabel);
            this.panelInfo.Controls.Add(this.lblEstimatedSize);
            this.panelInfo.Controls.Add(this.lblResLabel);
            this.panelInfo.Controls.Add(this.lblResolution);
            this.panelInfo.Location = new System.Drawing.Point(12, 60);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(476, 200);
            this.panelInfo.TabIndex = 1;
            //
            // lblFieldLabel
            //
            this.lblFieldLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblFieldLabel.Location = new System.Drawing.Point(15, 15);
            this.lblFieldLabel.Name = "lblFieldLabel";
            this.lblFieldLabel.Size = new System.Drawing.Size(100, 25);
            this.lblFieldLabel.TabIndex = 0;
            this.lblFieldLabel.Text = "Field:";
            this.lblFieldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblFieldName
            //
            this.lblFieldName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblFieldName.Location = new System.Drawing.Point(120, 15);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(340, 25);
            this.lblFieldName.TabIndex = 1;
            this.lblFieldName.Text = "Field Name";
            this.lblFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblBoundsLabel
            //
            this.lblBoundsLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblBoundsLabel.Location = new System.Drawing.Point(15, 45);
            this.lblBoundsLabel.Name = "lblBoundsLabel";
            this.lblBoundsLabel.Size = new System.Drawing.Size(100, 25);
            this.lblBoundsLabel.TabIndex = 2;
            this.lblBoundsLabel.Text = "Bounds:";
            this.lblBoundsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCoordinates
            //
            this.lblCoordinates.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCoordinates.Location = new System.Drawing.Point(120, 45);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(340, 25);
            this.lblCoordinates.TabIndex = 3;
            this.lblCoordinates.Text = "0°N - 0°N / 0°E - 0°E";
            this.lblCoordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblZoomLabel
            //
            this.lblZoomLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblZoomLabel.Location = new System.Drawing.Point(15, 80);
            this.lblZoomLabel.Name = "lblZoomLabel";
            this.lblZoomLabel.Size = new System.Drawing.Size(100, 25);
            this.lblZoomLabel.TabIndex = 4;
            this.lblZoomLabel.Text = "Resolution:";
            this.lblZoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboZoomLevel
            //
            this.cboZoomLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZoomLevel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cboZoomLevel.FormattingEnabled = true;
            this.cboZoomLevel.Location = new System.Drawing.Point(120, 78);
            this.cboZoomLevel.Name = "cboZoomLevel";
            this.cboZoomLevel.Size = new System.Drawing.Size(250, 26);
            this.cboZoomLevel.TabIndex = 5;
            this.cboZoomLevel.SelectedIndexChanged += new System.EventHandler(this.cboZoomLevel_SelectedIndexChanged);
            //
            // lblTilesLabel
            //
            this.lblTilesLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTilesLabel.Location = new System.Drawing.Point(15, 115);
            this.lblTilesLabel.Name = "lblTilesLabel";
            this.lblTilesLabel.Size = new System.Drawing.Size(100, 25);
            this.lblTilesLabel.TabIndex = 6;
            this.lblTilesLabel.Text = "Tiles:";
            this.lblTilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblTileCount
            //
            this.lblTileCount.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblTileCount.Location = new System.Drawing.Point(120, 115);
            this.lblTileCount.Name = "lblTileCount";
            this.lblTileCount.Size = new System.Drawing.Size(120, 25);
            this.lblTileCount.TabIndex = 7;
            this.lblTileCount.Text = "0 tiles";
            this.lblTileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblSizeLabel
            //
            this.lblSizeLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblSizeLabel.Location = new System.Drawing.Point(240, 115);
            this.lblSizeLabel.Name = "lblSizeLabel";
            this.lblSizeLabel.Size = new System.Drawing.Size(110, 25);
            this.lblSizeLabel.TabIndex = 8;
            this.lblSizeLabel.Text = "Est. Size:";
            this.lblSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblEstimatedSize
            //
            this.lblEstimatedSize.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblEstimatedSize.Location = new System.Drawing.Point(350, 115);
            this.lblEstimatedSize.Name = "lblEstimatedSize";
            this.lblEstimatedSize.Size = new System.Drawing.Size(110, 25);
            this.lblEstimatedSize.TabIndex = 9;
            this.lblEstimatedSize.Text = "0 MB";
            this.lblEstimatedSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblResLabel
            //
            this.lblResLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblResLabel.Location = new System.Drawing.Point(15, 150);
            this.lblResLabel.Name = "lblResLabel";
            this.lblResLabel.Size = new System.Drawing.Size(100, 25);
            this.lblResLabel.TabIndex = 10;
            this.lblResLabel.Text = "Detail:";
            this.lblResLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblResolution
            //
            this.lblResolution.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblResolution.Location = new System.Drawing.Point(120, 150);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(200, 25);
            this.lblResolution.TabIndex = 11;
            this.lblResolution.Text = "~1 m/pixel";
            this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panelExisting
            //
            this.panelExisting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.panelExisting.Controls.Add(this.lblExistingLabel);
            this.panelExisting.Controls.Add(this.lblExistingStatus);
            this.panelExisting.Controls.Add(this.lblExistingSize);
            this.panelExisting.Location = new System.Drawing.Point(12, 265);
            this.panelExisting.Name = "panelExisting";
            this.panelExisting.Size = new System.Drawing.Size(476, 50);
            this.panelExisting.TabIndex = 10;
            this.panelExisting.Visible = false;
            //
            // lblExistingLabel
            //
            this.lblExistingLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblExistingLabel.Location = new System.Drawing.Point(10, 12);
            this.lblExistingLabel.Name = "lblExistingLabel";
            this.lblExistingLabel.Size = new System.Drawing.Size(150, 25);
            this.lblExistingLabel.TabIndex = 0;
            this.lblExistingLabel.Text = "Current Imagery:";
            this.lblExistingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblExistingStatus
            //
            this.lblExistingStatus.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblExistingStatus.ForeColor = System.Drawing.Color.Green;
            this.lblExistingStatus.Location = new System.Drawing.Point(160, 12);
            this.lblExistingStatus.Name = "lblExistingStatus";
            this.lblExistingStatus.Size = new System.Drawing.Size(120, 25);
            this.lblExistingStatus.TabIndex = 1;
            this.lblExistingStatus.Text = "Downloaded";
            this.lblExistingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblExistingSize
            //
            this.lblExistingSize.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblExistingSize.Location = new System.Drawing.Point(300, 12);
            this.lblExistingSize.Name = "lblExistingSize";
            this.lblExistingSize.Size = new System.Drawing.Size(160, 25);
            this.lblExistingSize.TabIndex = 2;
            this.lblExistingSize.Text = "Size: 0 MB";
            this.lblExistingSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(12, 325);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(476, 30);
            this.progressBar.TabIndex = 2;
            //
            // lblStatus
            //
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblStatus.Location = new System.Drawing.Point(12, 360);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(476, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Ready to download";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnDownload
            //
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(12, 395);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(150, 55);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            //
            // btnDelete
            //
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(175, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 55);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(338, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 55);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // FormMapDownload
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(500, 465);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panelExisting);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMapDownload";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download Satellite Imagery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMapDownload_FormClosing);
            this.Load += new System.EventHandler(this.FormMapDownload_Load);
            this.panelExisting.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblFieldLabel;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label lblBoundsLabel;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblZoomLabel;
        private System.Windows.Forms.ComboBox cboZoomLevel;
        private System.Windows.Forms.Label lblTilesLabel;
        private System.Windows.Forms.Label lblTileCount;
        private System.Windows.Forms.Label lblSizeLabel;
        private System.Windows.Forms.Label lblEstimatedSize;
        private System.Windows.Forms.Label lblResLabel;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Panel panelExisting;
        private System.Windows.Forms.Label lblExistingLabel;
        private System.Windows.Forms.Label lblExistingStatus;
        private System.Windows.Forms.Label lblExistingSize;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
    }
}
