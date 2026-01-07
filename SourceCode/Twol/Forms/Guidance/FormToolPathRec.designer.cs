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
            this.btnOuterInner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bthOK
            // 
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImage = global::Twol.Properties.Resources.OK64;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.bthOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.bthOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(33, 5);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(53, 46);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // btnRecStartStop
            // 
            this.btnRecStartStop.BackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnRecStartStop.FlatAppearance.BorderSize = 0;
            this.btnRecStartStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnRecStartStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRecStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecStartStop.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRecStartStop.Image = global::Twol.Properties.Resources.BoundaryRecord;
            this.btnRecStartStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRecStartStop.Location = new System.Drawing.Point(223, 1);
            this.btnRecStartStop.Name = "btnRecStartStop";
            this.btnRecStartStop.Size = new System.Drawing.Size(76, 53);
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
            // btnOuterInner
            // 
            this.btnOuterInner.BackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnOuterInner.FlatAppearance.BorderSize = 0;
            this.btnOuterInner.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnOuterInner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOuterInner.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOuterInner.Image = global::Twol.Properties.Resources.Help;
            this.btnOuterInner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOuterInner.Location = new System.Drawing.Point(121, 1);
            this.btnOuterInner.Name = "btnOuterInner";
            this.btnOuterInner.Size = new System.Drawing.Size(69, 53);
            this.btnOuterInner.TabIndex = 538;
            this.btnOuterInner.UseVisualStyleBackColor = false;
            this.btnOuterInner.Click += new System.EventHandler(this.btnOuterInner_Click);
            // 
            // FormToolPathRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(302, 56);
            this.ControlBox = false;
            this.Controls.Add(this.bthOK);
            this.Controls.Add(this.btnOuterInner);
            this.Controls.Add(this.btnRecStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button btnOuterInner;
    }
}