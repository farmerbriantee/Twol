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
            this.btnBLength = new System.Windows.Forms.Button();
            this.btnALength = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteCurve = new System.Windows.Forms.Button();
            this.btnSelectCurveBk = new System.Windows.Forms.Button();
            this.btnSelectCurve = new System.Windows.Forms.Button();
            this.btnMakeBoundaryCurve = new System.Windows.Forms.Button();
            this.cboxFldOrBnd = new System.Windows.Forms.CheckBox();
            this.btnMakeCurve = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBLengthShorter = new System.Windows.Forms.Button();
            this.bntALengthShorter = new System.Windows.Forms.Button();
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
            this.oglSelf.Location = new System.Drawing.Point(2, 4);
            this.oglSelf.Margin = new System.Windows.Forms.Padding(0);
            this.oglSelf.Name = "oglSelf";
            this.oglSelf.Size = new System.Drawing.Size(700, 700);
            this.oglSelf.TabIndex = 183;
            this.oglSelf.VSync = false;
            this.oglSelf.Load += new System.EventHandler(this.oglSelf_Load);
            this.oglSelf.Paint += new System.Windows.Forms.PaintEventHandler(this.oglSelf_Paint);
            this.oglSelf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oglSelf_MouseDown);
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
            this.lblCurveSelected.Location = new System.Drawing.Point(7, 558);
            this.lblCurveSelected.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurveSelected.Name = "lblCurveSelected";
            this.lblCurveSelected.Size = new System.Drawing.Size(120, 26);
            this.lblCurveSelected.TabIndex = 329;
            this.lblCurveSelected.Text = "1";
            this.lblCurveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlp1
            // 
            this.tlp1.ColumnCount = 2;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp1.Controls.Add(this.bntALengthShorter, 1, 1);
            this.tlp1.Controls.Add(this.btnBLengthShorter, 1, 0);
            this.tlp1.Controls.Add(this.btnBLength, 0, 0);
            this.tlp1.Controls.Add(this.btnALength, 0, 1);
            this.tlp1.Controls.Add(this.btnCancel, 0, 7);
            this.tlp1.Controls.Add(this.btnDeleteCurve, 0, 3);
            this.tlp1.Controls.Add(this.lblCurveSelected, 0, 5);
            this.tlp1.Controls.Add(this.btnSelectCurveBk, 0, 4);
            this.tlp1.Controls.Add(this.btnSelectCurve, 1, 4);
            this.tlp1.Controls.Add(this.btnMakeCurve, 1, 3);
            this.tlp1.Controls.Add(this.btnOK, 1, 7);
            this.tlp1.Controls.Add(this.cboxFldOrBnd, 0, 2);
            this.tlp1.Controls.Add(this.btnMakeBoundaryCurve, 1, 2);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlp1.Location = new System.Drawing.Point(704, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 8;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.78567F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.12143F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.13364F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.80672F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.26221F));
            this.tlp1.Size = new System.Drawing.Size(268, 733);
            this.tlp1.TabIndex = 564;
            // 
            // btnBLength
            // 
            this.btnBLength.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBLength.BackColor = System.Drawing.Color.Transparent;
            this.btnBLength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBLength.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBLength.FlatAppearance.BorderSize = 0;
            this.btnBLength.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBLength.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBLength.Image = global::Twol.Properties.Resources.APlusPlusB;
            this.btnBLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLength.Location = new System.Drawing.Point(12, 28);
            this.btnBLength.Name = "btnBLength";
            this.btnBLength.Size = new System.Drawing.Size(110, 43);
            this.btnBLength.TabIndex = 351;
            this.btnBLength.UseVisualStyleBackColor = false;
            this.btnBLength.Click += new System.EventHandler(this.btnBLength_Click);
            // 
            // btnALength
            // 
            this.btnALength.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnALength.BackColor = System.Drawing.Color.Transparent;
            this.btnALength.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnALength.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnALength.FlatAppearance.BorderSize = 0;
            this.btnALength.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnALength.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnALength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnALength.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnALength.Image = global::Twol.Properties.Resources.APlusPlusA;
            this.btnALength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnALength.Location = new System.Drawing.Point(12, 135);
            this.btnALength.Name = "btnALength";
            this.btnALength.Size = new System.Drawing.Size(110, 43);
            this.btnALength.TabIndex = 352;
            this.btnALength.UseVisualStyleBackColor = false;
            this.btnALength.Click += new System.EventHandler(this.btnALength_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::Twol.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(23, 645);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 56);
            this.btnCancel.TabIndex = 469;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteCurve
            // 
            this.btnDeleteCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteCurve.FlatAppearance.BorderSize = 0;
            this.btnDeleteCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteCurve.Image = global::Twol.Properties.Resources.Trash;
            this.btnDeleteCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteCurve.Location = new System.Drawing.Point(39, 360);
            this.btnDeleteCurve.Name = "btnDeleteCurve";
            this.btnDeleteCurve.Size = new System.Drawing.Size(56, 41);
            this.btnDeleteCurve.TabIndex = 6;
            this.btnDeleteCurve.UseVisualStyleBackColor = false;
            this.btnDeleteCurve.Click += new System.EventHandler(this.btnDeleteCurve_Click);
            // 
            // btnSelectCurveBk
            // 
            this.btnSelectCurveBk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectCurveBk.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectCurveBk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectCurveBk.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectCurveBk.FlatAppearance.BorderSize = 0;
            this.btnSelectCurveBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCurveBk.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectCurveBk.Image = global::Twol.Properties.Resources.ABLineCycleBk;
            this.btnSelectCurveBk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectCurveBk.Location = new System.Drawing.Point(5, 462);
            this.btnSelectCurveBk.Name = "btnSelectCurveBk";
            this.btnSelectCurveBk.Size = new System.Drawing.Size(123, 68);
            this.btnSelectCurveBk.TabIndex = 472;
            this.btnSelectCurveBk.UseVisualStyleBackColor = false;
            this.btnSelectCurveBk.Click += new System.EventHandler(this.btnSelectCurveBk_Click);
            // 
            // btnSelectCurve
            // 
            this.btnSelectCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectCurve.FlatAppearance.BorderSize = 0;
            this.btnSelectCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSelectCurve.Image = global::Twol.Properties.Resources.ABLineCycle;
            this.btnSelectCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectCurve.Location = new System.Drawing.Point(139, 462);
            this.btnSelectCurve.Name = "btnSelectCurve";
            this.btnSelectCurve.Size = new System.Drawing.Size(124, 68);
            this.btnSelectCurve.TabIndex = 5;
            this.btnSelectCurve.UseVisualStyleBackColor = false;
            this.btnSelectCurve.Click += new System.EventHandler(this.btnSelectCurve_Click);
            // 
            // btnMakeBoundaryCurve
            // 
            this.btnMakeBoundaryCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMakeBoundaryCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeBoundaryCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeBoundaryCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeBoundaryCurve.FlatAppearance.BorderSize = 0;
            this.btnMakeBoundaryCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeBoundaryCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeBoundaryCurve.Image = global::Twol.Properties.Resources.BoundaryCurveLine;
            this.btnMakeBoundaryCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeBoundaryCurve.Location = new System.Drawing.Point(156, 226);
            this.btnMakeBoundaryCurve.Name = "btnMakeBoundaryCurve";
            this.btnMakeBoundaryCurve.Size = new System.Drawing.Size(90, 84);
            this.btnMakeBoundaryCurve.TabIndex = 4;
            this.btnMakeBoundaryCurve.UseVisualStyleBackColor = false;
            this.btnMakeBoundaryCurve.Click += new System.EventHandler(this.btnMakeBoundaryCurve_Click);
            // 
            // cboxFldOrBnd
            // 
            this.cboxFldOrBnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxFldOrBnd.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxFldOrBnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.cboxFldOrBnd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxFldOrBnd.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(220)))));
            this.cboxFldOrBnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.cboxFldOrBnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cboxFldOrBnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxFldOrBnd.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxFldOrBnd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboxFldOrBnd.Image = global::Twol.Properties.Resources.Boundary;
            this.cboxFldOrBnd.Location = new System.Drawing.Point(18, 227);
            this.cboxFldOrBnd.Name = "cboxFldOrBnd";
            this.cboxFldOrBnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxFldOrBnd.Size = new System.Drawing.Size(97, 81);
            this.cboxFldOrBnd.TabIndex = 566;
            this.cboxFldOrBnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxFldOrBnd.UseVisualStyleBackColor = false;
            this.cboxFldOrBnd.Click += new System.EventHandler(this.cboxFldOrBnd_Click);
            // 
            // btnMakeCurve
            // 
            this.btnMakeCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMakeCurve.BackColor = System.Drawing.Color.Transparent;
            this.btnMakeCurve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeCurve.Enabled = false;
            this.btnMakeCurve.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMakeCurve.FlatAppearance.BorderSize = 0;
            this.btnMakeCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeCurve.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnMakeCurve.Image = global::Twol.Properties.Resources.ABTrackCurve;
            this.btnMakeCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMakeCurve.Location = new System.Drawing.Point(152, 337);
            this.btnMakeCurve.Name = "btnMakeCurve";
            this.btnMakeCurve.Size = new System.Drawing.Size(98, 87);
            this.btnMakeCurve.TabIndex = 2;
            this.btnMakeCurve.UseVisualStyleBackColor = false;
            this.btnMakeCurve.Click += new System.EventHandler(this.btnMakeCurve_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOK.Image = global::Twol.Properties.Resources.OK64;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(157, 645);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 56);
            this.btnOK.TabIndex = 0;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBLengthShorter
            // 
            this.btnBLengthShorter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBLengthShorter.BackColor = System.Drawing.Color.Transparent;
            this.btnBLengthShorter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBLengthShorter.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnBLengthShorter.FlatAppearance.BorderSize = 0;
            this.btnBLengthShorter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBLengthShorter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBLengthShorter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBLengthShorter.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnBLengthShorter.Image = global::Twol.Properties.Resources.APlusMinusB;
            this.btnBLengthShorter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBLengthShorter.Location = new System.Drawing.Point(146, 28);
            this.btnBLengthShorter.Name = "btnBLengthShorter";
            this.btnBLengthShorter.Size = new System.Drawing.Size(110, 43);
            this.btnBLengthShorter.TabIndex = 567;
            this.btnBLengthShorter.UseVisualStyleBackColor = false;
            this.btnBLengthShorter.Click += new System.EventHandler(this.btnBLengthShorter_Click);
            // 
            // bntALengthShorter
            // 
            this.bntALengthShorter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bntALengthShorter.BackColor = System.Drawing.Color.Transparent;
            this.bntALengthShorter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntALengthShorter.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.bntALengthShorter.FlatAppearance.BorderSize = 0;
            this.bntALengthShorter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bntALengthShorter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bntALengthShorter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntALengthShorter.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntALengthShorter.Image = global::Twol.Properties.Resources.APlusMinusA;
            this.bntALengthShorter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntALengthShorter.Location = new System.Drawing.Point(146, 135);
            this.bntALengthShorter.Name = "bntALengthShorter";
            this.bntALengthShorter.Size = new System.Drawing.Size(110, 43);
            this.bntALengthShorter.TabIndex = 568;
            this.bntALengthShorter.UseVisualStyleBackColor = false;
            this.bntALengthShorter.Click += new System.EventHandler(this.bntALengthShorter_Click);
            // 
            // FormBuildToolTracks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(972, 733);
            this.ControlBox = false;
            this.Controls.Add(this.tlp1);
            this.Controls.Add(this.oglSelf);
            this.ForeColor = System.Drawing.Color.Black;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1292, 1053);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(992, 753);
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
        private System.Windows.Forms.Button btnMakeCurve;
        private System.Windows.Forms.Button btnSelectCurve;
        private System.Windows.Forms.Button btnDeleteCurve;
        private System.Windows.Forms.Label lblCurveSelected;
        private System.Windows.Forms.Button btnMakeBoundaryCurve;
        private System.Windows.Forms.Button btnBLength;
        private System.Windows.Forms.Button btnALength;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectCurveBk;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.CheckBox cboxFldOrBnd;
        private System.Windows.Forms.Button bntALengthShorter;
        private System.Windows.Forms.Button btnBLengthShorter;
    }
}