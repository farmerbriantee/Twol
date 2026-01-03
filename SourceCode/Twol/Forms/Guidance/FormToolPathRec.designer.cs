namespace Twol
{
    partial class FormToolPathRec
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
            this.bthOK = new System.Windows.Forms.Button();
            this.btnRecStartStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblOuterInner = new System.Windows.Forms.Label();
            this.lblPointsRec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOuterInner = new System.Windows.Forms.Button();
            this.lblTracks = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportLines = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bthOK
            // 
            this.bthOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImage = global::Twol.Properties.Resources.OK64;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(185, 285);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(87, 65);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // btnRecStartStop
            // 
            this.btnRecStartStop.BackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRecStartStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecStartStop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRecStartStop.Image = global::Twol.Properties.Resources.BoundaryRecord;
            this.btnRecStartStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRecStartStop.Location = new System.Drawing.Point(8, 53);
            this.btnRecStartStop.Name = "btnRecStartStop";
            this.btnRecStartStop.Size = new System.Drawing.Size(116, 65);
            this.btnRecStartStop.TabIndex = 534;
            this.btnRecStartStop.UseVisualStyleBackColor = false;
            this.btnRecStartStop.Click += new System.EventHandler(this.btnRecStartStop_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblOuterInner
            // 
            this.lblOuterInner.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOuterInner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOuterInner.Location = new System.Drawing.Point(6, 232);
            this.lblOuterInner.Name = "lblOuterInner";
            this.lblOuterInner.Size = new System.Drawing.Size(121, 31);
            this.lblOuterInner.TabIndex = 535;
            this.lblOuterInner.Text = "Outer";
            this.lblOuterInner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointsRec
            // 
            this.lblPointsRec.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsRec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPointsRec.Location = new System.Drawing.Point(72, 25);
            this.lblPointsRec.Name = "lblPointsRec";
            this.lblPointsRec.Size = new System.Drawing.Size(63, 22);
            this.lblPointsRec.TabIndex = 536;
            this.lblPointsRec.Text = "32";
            this.lblPointsRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 537;
            this.label2.Text = "Points: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOuterInner
            // 
            this.btnOuterInner.BackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOuterInner.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOuterInner.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOuterInner.Image = global::Twol.Properties.Resources.TramOuter;
            this.btnOuterInner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOuterInner.Location = new System.Drawing.Point(23, 164);
            this.btnOuterInner.Name = "btnOuterInner";
            this.btnOuterInner.Size = new System.Drawing.Size(87, 65);
            this.btnOuterInner.TabIndex = 538;
            this.btnOuterInner.UseVisualStyleBackColor = false;
            this.btnOuterInner.Click += new System.EventHandler(this.btnOuterInner_Click);
            // 
            // lblTracks
            // 
            this.lblTracks.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTracks.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTracks.Location = new System.Drawing.Point(76, 122);
            this.lblTracks.Name = "lblTracks";
            this.lblTracks.Size = new System.Drawing.Size(63, 22);
            this.lblTracks.TabIndex = 539;
            this.lblTracks.Text = "32";
            this.lblTracks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(4, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 540;
            this.label3.Text = "Tracks:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExportLines
            // 
            this.btnExportLines.BackColor = System.Drawing.Color.Transparent;
            this.btnExportLines.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnExportLines.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExportLines.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExportLines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExportLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLines.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnExportLines.Image = global::Twol.Properties.Resources.FileSave;
            this.btnExportLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExportLines.Location = new System.Drawing.Point(185, 164);
            this.btnExportLines.Name = "btnExportLines";
            this.btnExportLines.Size = new System.Drawing.Size(87, 65);
            this.btnExportLines.TabIndex = 541;
            this.btnExportLines.UseVisualStyleBackColor = false;
            this.btnExportLines.Click += new System.EventHandler(this.btnExportLines_Click);
            // 
            // FormToolPathRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.ControlBox = false;
            this.Controls.Add(this.btnExportLines);
            this.Controls.Add(this.lblTracks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOuterInner);
            this.Controls.Add(this.lblPointsRec);
            this.Controls.Add(this.lblOuterInner);
            this.Controls.Add(this.btnRecStartStop);
            this.Controls.Add(this.bthOK);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolPathRec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolPathRec_FormClosing);
            this.Load += new System.EventHandler(this.FormToolPathRec_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormToolPathRec_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bthOK;
        private System.Windows.Forms.Button btnRecStartStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblOuterInner;
        private System.Windows.Forms.Label lblPointsRec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOuterInner;
        private System.Windows.Forms.Label lblTracks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportLines;
    }
}