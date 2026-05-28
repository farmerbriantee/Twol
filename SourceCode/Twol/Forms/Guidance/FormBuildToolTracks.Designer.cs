namespace Twol
{
    partial class FormBuildToolTracks
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
            this.components = new System.ComponentModel.Container();
            this.oglSelf = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCurveSelected = new System.Windows.Forms.Label();
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnSecondSelect = new System.Windows.Forms.Button();
            this.btnSaveToolRecordTxtFile = new System.Windows.Forms.Button();
            this.btnSectionsTrams = new System.Windows.Forms.Button();
            this.btnSelectCurveBk = new System.Windows.Forms.Button();
            this.btnSelectCurve = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOuterLine = new System.Windows.Forms.Button();
            this.btnMakeInnerLine = new System.Windows.Forms.Button();
            this.bntALengthShorter = new System.Windows.Forms.Button();
            this.btnALength = new System.Windows.Forms.Button();
            this.btnBLengthShorter = new System.Windows.Forms.Button();
            this.btnBLength = new System.Windows.Forms.Button();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnSaveTracks = new System.Windows.Forms.Button();
            this.btnZoomReset = new System.Windows.Forms.Button();
            this.tlp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oglSelf
            // 
            this.oglSelf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oglSelf.BackColor = System.Drawing.Color.Black;
            this.oglSelf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.oglSelf.Location = new System.Drawing.Point(3, 1);
            this.oglSelf.Margin = new System.Windows.Forms.Padding(0);
            this.oglSelf.Name = "oglSelf";
            this.oglSelf.Size = new System.Drawing.Size(700, 700);
            this.oglSelf.TabIndex = 183;
            this.oglSelf.VSync = false;
            this.oglSelf.Load += new System.EventHandler(this.oglSelf_Load);
            this.oglSelf.Paint += new System.Windows.Forms.PaintEventHandler(this.oglSelf_Paint);
            this.oglSelf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseDown);
            this.oglSelf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseMove);
            this.oglSelf.MouseUp += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseUp);
            this.oglSelf.Resize += new System.EventHandler(this.oglSelf_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCurveSelected
            // 
            this.lblCurveSelected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurveSelected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurveSelected.ForeColor = System.Drawing.Color.Black;
            this.lblCurveSelected.Location = new System.Drawing.Point(7, 576);
            this.lblCurveSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveSelected.Name = "lblCurveSelected";
            this.lblCurveSelected.Size = new System.Drawing.Size(120, 26);
            this.lblCurveSelected.TabIndex = 329;
            this.lblCurveSelected.Text = "1";
            this.lblCurveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlp1
            // 
            this.tlp1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp1.ColumnCount = 2;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp1.Controls.Add(this.btnJoin, 1, 7);
            this.tlp1.Controls.Add(this.btnSecondSelect, 0, 7);
            this.tlp1.Controls.Add(this.btnSaveToolRecordTxtFile, 1, 5);
            this.tlp1.Controls.Add(this.btnSectionsTrams, 0, 1);
            this.tlp1.Controls.Add(this.btnSelectCurveBk, 0, 4);
            this.tlp1.Controls.Add(this.btnSelectCurve, 1, 4);
            this.tlp1.Controls.Add(this.btnOK, 1, 6);
            this.tlp1.Controls.Add(this.btnOuterLine, 0, 2);
            this.tlp1.Controls.Add(this.btnMakeInnerLine, 0, 3);
            this.tlp1.Controls.Add(this.bntALengthShorter, 1, 3);
            this.tlp1.Controls.Add(this.btnALength, 1, 2);
            this.tlp1.Controls.Add(this.btnBLengthShorter, 1, 1);
            this.tlp1.Controls.Add(this.btnBLength, 1, 0);
            this.tlp1.Controls.Add(this.btnDeleteCurve, 0, 0);
            this.tlp1.Controls.Add(this.btnSaveTracks, 0, 5);
            this.tlp1.Controls.Add(this.lblCurveSelected, 0, 6);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlp1.Location = new System.Drawing.Point(708, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 8;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.43467F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08076F));
            this.tlp1.Size = new System.Drawing.Size(268, 724);
            this.tlp1.TabIndex = 564;
            // 
            // btnJoin
            // 
            this.btnJoin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJoin.BackColor = System.Drawing.Color.Transparent;
            this.btnJoin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnJoin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnJoin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnJoin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnJoin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnJoin.Location = new System.Drawing.Point(146, 657);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(110, 43);
            this.btnJoin.TabIndex = 574;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnSecondSelect
            // 
            this.btnSecondSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSecondSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSecondSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSecondSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSecondSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSecondSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSecondSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecondSelect.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSecondSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSecondSelect.Location = new System.Drawing.Point(12, 657);
            this.btnSecondSelect.Name = "btnSecondSelect";
            this.btnSecondSelect.Size = new System.Drawing.Size(110, 43);
            this.btnSecondSelect.TabIndex = 573;
            this.btnSecondSelect.Text = "Select 2nd";
            this.btnSecondSelect.UseVisualStyleBackColor = false;
            this.btnSecondSelect.Click += new System.EventHandler(this.btnSecondSelect_Click);
            // 
            // btnSaveToolRecordTxtFile
            // 
            this.btnSaveToolRecordTxtFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveToolRecordTxtFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveToolRecordTxtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveToolRecordTxtFile.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveToolRecordTxtFile.FlatAppearance.BorderSize = 0;
            this.btnSaveToolRecordTxtFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSaveToolRecordTxtFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSaveToolRecordTxtFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToolRecordTxtFile.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSaveToolRecordTxtFile.Image = global::Twol.Properties.Resources.FileSaveRecordedTool;
            this.btnSaveToolRecordTxtFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveToolRecordTxtFile.Location = new System.Drawing.Point(137, 438);
            this.btnSaveToolRecordTxtFile.Name = "btnSaveToolRecordTxtFile";
            this.btnSaveToolRecordTxtFile.Size = new System.Drawing.Size(128, 105);
            this.btnSaveToolRecordTxtFile.TabIndex = 572;
            this.btnSaveToolRecordTxtFile.UseVisualStyleBackColor = false;
            this.btnSaveToolRecordTxtFile.Click += new System.EventHandler(this.btnSaveToolRecordTxtFile_Click);
            // 
            // btnSectionsTrams
            // 
            this.btnSectionsTrams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSectionsTrams.BackColor = System.Drawing.Color.Transparent;
            this.btnSectionsTrams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSectionsTrams.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSectionsTrams.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSectionsTrams.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSectionsTrams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSectionsTrams.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSectionsTrams.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSectionsTrams.Location = new System.Drawing.Point(12, 109);
            this.btnSectionsTrams.Name = "btnSectionsTrams";
            this.btnSectionsTrams.Size = new System.Drawing.Size(110, 43);
            this.btnSectionsTrams.TabIndex = 570;
            this.btnSectionsTrams.Text = "N-T-S-ST";
            this.btnSectionsTrams.UseVisualStyleBackColor = false;
            this.btnSectionsTrams.Click += new System.EventHandler(this.btnSectionsTrams_Click);
            // 
            // btnSelectCurveBk
            // 
            this.btnSelectCurveBk.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectCurveBk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectCurveBk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectCurveBk.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectCurveBk.FlatAppearance.BorderSize = 0;
            this.btnSelectCurveBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCurveBk.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectCurveBk.Image = global::Twol.Properties.Resources.ABLineCycleBk;
            this.btnSelectCurveBk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectCurveBk.Location = new System.Drawing.Point(3, 351);
            this.btnSelectCurveBk.Name = "btnSelectCurveBk";
            this.btnSelectCurveBk.Size = new System.Drawing.Size(128, 81);
            this.btnSelectCurveBk.TabIndex = 472;
            this.btnSelectCurveBk.UseVisualStyleBackColor = false;
            this.btnSelectCurveBk.Click += new System.EventHandler(this.btnSelectCurveBk_Click);
            // 
            // btnSelectCurve
            // 
            this.btnSelectCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectCurve.FlatAppearance.BorderSize = 0;
            this.btnSelectCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectCurve.Image = global::Twol.Properties.Resources.ABLineCycle;
            this.btnSelectCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectCurve.Location = new System.Drawing.Point(137, 351);
            this.btnSelectCurve.Name = "btnSelectCurve";
            this.btnSelectCurve.Size = new System.Drawing.Size(128, 81);
            this.btnSelectCurve.TabIndex = 5;
            this.btnSelectCurve.UseVisualStyleBackColor = false;
            this.btnSelectCurve.Click += new System.EventHandler(this.btnSelectCurve_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOK.Image = global::Twol.Properties.Resources.OK64;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(137, 549);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 81);
            this.btnOK.TabIndex = 0;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOuterLine
            // 
            this.btnOuterLine.BackColor = System.Drawing.Color.Transparent;
            this.btnOuterLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOuterLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOuterLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnOuterLine.FlatAppearance.BorderSize = 0;
            this.btnOuterLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOuterLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOuterLine.Image = global::Twol.Properties.Resources.FilterOuterLines;
            this.btnOuterLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOuterLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOuterLine.Location = new System.Drawing.Point(3, 177);
            this.btnOuterLine.Name = "btnOuterLine";
            this.btnOuterLine.Size = new System.Drawing.Size(128, 81);
            this.btnOuterLine.TabIndex = 569;
            this.btnOuterLine.Text = "Boundary";
            this.btnOuterLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOuterLine.UseVisualStyleBackColor = false;
            this.btnOuterLine.Click += new System.EventHandler(this.btnOuterLine_Click);
            // 
            // btnMakeInnerLine
            // 
            this.btnMakeInnerLine.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeInnerLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeInnerLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMakeInnerLine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeInnerLine.FlatAppearance.BorderSize = 0;
            this.btnMakeInnerLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeInnerLine.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeInnerLine.Image = global::Twol.Properties.Resources.FilterInnerLines;
            this.btnMakeInnerLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMakeInnerLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeInnerLine.Location = new System.Drawing.Point(3, 264);
            this.btnMakeInnerLine.Name = "btnMakeInnerLine";
            this.btnMakeInnerLine.Size = new System.Drawing.Size(128, 81);
            this.btnMakeInnerLine.TabIndex = 2;
            this.btnMakeInnerLine.Text = "Inner";
            this.btnMakeInnerLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMakeInnerLine.UseVisualStyleBackColor = false;
            this.btnMakeInnerLine.Click += new System.EventHandler(this.btnMakeInnerLine_Click);
            // 
            // bntALengthShorter
            // 
            this.bntALengthShorter.BackColor = System.Drawing.Color.Transparent;
            this.bntALengthShorter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntALengthShorter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntALengthShorter.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.bntALengthShorter.FlatAppearance.BorderSize = 0;
            this.bntALengthShorter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bntALengthShorter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bntALengthShorter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntALengthShorter.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntALengthShorter.Image = global::Twol.Properties.Resources.APlusMinusA;
            this.bntALengthShorter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntALengthShorter.Location = new System.Drawing.Point(137, 264);
            this.bntALengthShorter.Name = "bntALengthShorter";
            this.bntALengthShorter.Size = new System.Drawing.Size(128, 81);
            this.bntALengthShorter.TabIndex = 568;
            this.bntALengthShorter.UseVisualStyleBackColor = false;
            this.bntALengthShorter.Click += new System.EventHandler(this.bntALengthShorter_Click);
            // 
            // btnALength
            // 
            this.btnALength.BackColor = System.Drawing.Color.Transparent;
            this.btnALength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnALength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALength.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnALength.FlatAppearance.BorderSize = 0;
            this.btnALength.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnALength.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnALength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnALength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnALength.Image = global::Twol.Properties.Resources.APlusPlusA;
            this.btnALength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnALength.Location = new System.Drawing.Point(137, 177);
            this.btnALength.Name = "btnALength";
            this.btnALength.Size = new System.Drawing.Size(128, 81);
            this.btnALength.TabIndex = 352;
            this.btnALength.UseVisualStyleBackColor = false;
            this.btnALength.Click += new System.EventHandler(this.btnALength_Click);
            // 
            // btnBLengthShorter
            // 
            this.btnBLengthShorter.BackColor = System.Drawing.Color.Transparent;
            this.btnBLengthShorter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBLengthShorter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBLengthShorter.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBLengthShorter.FlatAppearance.BorderSize = 0;
            this.btnBLengthShorter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBLengthShorter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBLengthShorter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLengthShorter.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBLengthShorter.Image = global::Twol.Properties.Resources.APlusMinusB;
            this.btnBLengthShorter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLengthShorter.Location = new System.Drawing.Point(137, 90);
            this.btnBLengthShorter.Name = "btnBLengthShorter";
            this.btnBLengthShorter.Size = new System.Drawing.Size(128, 81);
            this.btnBLengthShorter.TabIndex = 567;
            this.btnBLengthShorter.UseVisualStyleBackColor = false;
            this.btnBLengthShorter.Click += new System.EventHandler(this.btnBLengthShorter_Click);
            // 
            // btnBLength
            // 
            this.btnBLength.BackColor = System.Drawing.Color.Transparent;
            this.btnBLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBLength.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBLength.FlatAppearance.BorderSize = 0;
            this.btnBLength.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBLength.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBLength.Image = global::Twol.Properties.Resources.APlusPlusB;
            this.btnBLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLength.Location = new System.Drawing.Point(137, 3);
            this.btnBLength.Name = "btnBLength";
            this.btnBLength.Size = new System.Drawing.Size(128, 81);
            this.btnBLength.TabIndex = 351;
            this.btnBLength.UseVisualStyleBackColor = false;
            this.btnBLength.Click += new System.EventHandler(this.btnBLength_Click);
            // 
            // btnDeleteCurve
            // 
            this.btnDeleteCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteCurve.FlatAppearance.BorderSize = 0;
            this.btnDeleteCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteCurve.Image = global::Twol.Properties.Resources.Trash;
            this.btnDeleteCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteCurve.Location = new System.Drawing.Point(3, 3);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(128, 81);
            this.btnDeleteCurve.TabIndex = 6;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
            // 
            // btnSaveTracks
            // 
            this.btnSaveTracks.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveTracks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveTracks.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSaveTracks.FlatAppearance.BorderSize = 0;
            this.btnSaveTracks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSaveTracks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSaveTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTracks.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSaveTracks.Image = global::Twol.Properties.Resources.FileExportToolTracks;
            this.btnSaveTracks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveTracks.Location = new System.Drawing.Point(3, 438);
            this.btnSaveTracks.Name = "btnSaveTracks";
            this.btnSaveTracks.Size = new System.Drawing.Size(128, 105);
            this.btnSaveTracks.TabIndex = 571;
            this.btnSaveTracks.UseVisualStyleBackColor = false;
            this.btnSaveTracks.Click += new System.EventHandler(this.btnSaveTracks_Click);
            // 
            // btnZoomReset
            // 
            this.btnZoomReset.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomReset.BackgroundImage = global::Twol.Properties.Resources.Pan;
            this.btnZoomReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomReset.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnZoomReset.FlatAppearance.BorderSize = 0;
            this.btnZoomReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnZoomReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZoomReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomReset.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnZoomReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZoomReset.Location = new System.Drawing.Point(3, 5);
            this.btnZoomReset.Name = "btnZoomReset";
            this.btnZoomReset.Size = new System.Drawing.Size(41, 39);
            this.btnZoomReset.TabIndex = 573;
            this.btnZoomReset.UseVisualStyleBackColor = false;
            this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
            // 
            // FormBuildToolTracks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(976, 724);
            this.ControlBox = false;
            this.Controls.Add(this.btnZoomReset);
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.oglSelf);
            this.ForeColor = System.Drawing.Color.Black;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1292, 1044);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(992, 740);
            this.Name = "FormBuildToolTracks";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool Track Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBuildToolTracks_FormClosing);
            this.Load += new System.EventHandler(this.FormBuildToolTracks_Load);
            this.tlp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl oglSelf;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMakeInnerLine;
        private System.Windows.Forms.Button btnSelectCurve;
        private System.Windows.Forms.Button btnDeleteCurve;
        private System.Windows.Forms.Label lblCurveSelected;
        private System.Windows.Forms.Button btnBLength;
        private System.Windows.Forms.Button btnALength;
        private System.Windows.Forms.Button btnSelectCurveBk;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Button bntALengthShorter;
        private System.Windows.Forms.Button btnBLengthShorter;
        private System.Windows.Forms.Button btnOuterLine;
        private System.Windows.Forms.Button btnSectionsTrams;
        private System.Windows.Forms.Button btnSaveTracks;
        private System.Windows.Forms.Button btnSaveToolRecordTxtFile;
        private System.Windows.Forms.Button btnZoomReset;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnSecondSelect;
    }
}