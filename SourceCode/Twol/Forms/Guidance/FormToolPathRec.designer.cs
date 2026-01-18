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
            this.btnRecStartStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnOuterInner = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.btnRecStartStop.Location = new System.Drawing.Point(162, 1);
            this.btnRecStartStop.Name = "btnRecStartStop";
            this.btnRecStartStop.Size = new System.Drawing.Size(112, 53);
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
            this.btnOuterInner.Location = new System.Drawing.Point(71, 2);
            this.btnOuterInner.Name = "btnOuterInner";
            this.btnOuterInner.Size = new System.Drawing.Size(69, 53);
            this.btnOuterInner.TabIndex = 538;
            this.btnOuterInner.UseVisualStyleBackColor = false;
            this.btnOuterInner.Click += new System.EventHandler(this.btnOuterInner_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Twol.Properties.Resources.AddNew;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 52);
            this.pictureBox1.TabIndex = 546;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // FormToolPathRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(282, 56);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRecStartStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOuterInner;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}