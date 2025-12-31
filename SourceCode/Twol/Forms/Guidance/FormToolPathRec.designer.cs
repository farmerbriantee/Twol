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
            this.bthOK = new System.Windows.Forms.Button();
            this.btnRecStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bthOK
            // 
            this.bthOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImage = global::Twol.Properties.Resources.OK64;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(12, 175);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(74, 65);
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
            this.btnRecStartStop.Location = new System.Drawing.Point(12, 12);
            this.btnRecStartStop.Name = "btnRecStartStop";
            this.btnRecStartStop.Size = new System.Drawing.Size(87, 65);
            this.btnRecStartStop.TabIndex = 534;
            this.btnRecStartStop.UseVisualStyleBackColor = false;
            this.btnRecStartStop.Click += new System.EventHandler(this.btnRecStartStop_Click);
            // 
            // FormToolPathRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(120, 252);
            this.ControlBox = false;
            this.Controls.Add(this.btnRecStartStop);
            this.Controls.Add(this.bthOK);
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
    }
}