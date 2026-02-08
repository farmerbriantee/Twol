namespace Twol
{
    partial class FormToolManual
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
            this.btnToolLeft = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnToolRight = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblManualPWM_Percent = new System.Windows.Forms.Label();
            this.hsbarManualPWM_Percent = new System.Windows.Forms.HScrollBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblManualSecondsOn = new System.Windows.Forms.Label();
            this.hsbarManualSecondsOn = new System.Windows.Forms.HScrollBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToolLeft
            // 
            this.btnToolLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnToolLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnToolLeft.FlatAppearance.BorderSize = 0;
            this.btnToolLeft.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnToolLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToolLeft.Image = global::Twol.Properties.Resources.ArrowLeft;
            this.btnToolLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToolLeft.Location = new System.Drawing.Point(47, 2);
            this.btnToolLeft.Name = "btnToolLeft";
            this.btnToolLeft.Size = new System.Drawing.Size(74, 52);
            this.btnToolLeft.TabIndex = 543;
            this.btnToolLeft.UseVisualStyleBackColor = false;
            this.btnToolLeft.Click += new System.EventHandler(this.btnToolLeft_Click);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnZero.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnZero.FlatAppearance.BorderSize = 0;
            this.btnZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZero.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnZero.Image = global::Twol.Properties.Resources.SteerZero;
            this.btnZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZero.Location = new System.Drawing.Point(134, 2);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(74, 52);
            this.btnZero.TabIndex = 544;
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnToolRight
            // 
            this.btnToolRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.btnToolRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnToolRight.FlatAppearance.BorderSize = 0;
            this.btnToolRight.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnToolRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToolRight.Image = global::Twol.Properties.Resources.ArrowRight;
            this.btnToolRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToolRight.Location = new System.Drawing.Point(221, 2);
            this.btnToolRight.Name = "btnToolRight";
            this.btnToolRight.Size = new System.Drawing.Size(74, 52);
            this.btnToolRight.TabIndex = 542;
            this.btnToolRight.UseVisualStyleBackColor = false;
            this.btnToolRight.Click += new System.EventHandler(this.btnToolRight_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Twol.Properties.Resources.AddNew;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 52);
            this.pictureBox1.TabIndex = 545;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // lblManualPWM_Percent
            // 
            this.lblManualPWM_Percent.BackColor = System.Drawing.Color.Gainsboro;
            this.lblManualPWM_Percent.Enabled = false;
            this.lblManualPWM_Percent.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualPWM_Percent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lblManualPWM_Percent.Location = new System.Drawing.Point(96, 164);
            this.lblManualPWM_Percent.Name = "lblManualPWM_Percent";
            this.lblManualPWM_Percent.Size = new System.Drawing.Size(54, 26);
            this.lblManualPWM_Percent.TabIndex = 592;
            this.lblManualPWM_Percent.Text = "888";
            this.lblManualPWM_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarManualPWM_Percent
            // 
            this.hsbarManualPWM_Percent.LargeChange = 1;
            this.hsbarManualPWM_Percent.Location = new System.Drawing.Point(9, 194);
            this.hsbarManualPWM_Percent.Minimum = 10;
            this.hsbarManualPWM_Percent.Name = "hsbarManualPWM_Percent";
            this.hsbarManualPWM_Percent.Size = new System.Drawing.Size(333, 40);
            this.hsbarManualPWM_Percent.TabIndex = 591;
            this.hsbarManualPWM_Percent.Value = 50;
            this.hsbarManualPWM_Percent.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarManualPWM_Percent_Scroll);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label13.Location = new System.Drawing.Point(149, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 26);
            this.label13.TabIndex = 590;
            this.label13.Text = "PWM %";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gainsboro;
            this.label11.Enabled = false;
            this.label11.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label11.Location = new System.Drawing.Point(147, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 26);
            this.label11.TabIndex = 587;
            this.label11.Text = "Seconds";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // lblManualSecondsOn
            // 
            this.lblManualSecondsOn.BackColor = System.Drawing.Color.Gainsboro;
            this.lblManualSecondsOn.Enabled = false;
            this.lblManualSecondsOn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualSecondsOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lblManualSecondsOn.Location = new System.Drawing.Point(94, 74);
            this.lblManualSecondsOn.Name = "lblManualSecondsOn";
            this.lblManualSecondsOn.Size = new System.Drawing.Size(54, 26);
            this.lblManualSecondsOn.TabIndex = 589;
            this.lblManualSecondsOn.Text = "888";
            this.lblManualSecondsOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarManualSecondsOn
            // 
            this.hsbarManualSecondsOn.LargeChange = 1;
            this.hsbarManualSecondsOn.Location = new System.Drawing.Point(9, 105);
            this.hsbarManualSecondsOn.Maximum = 10;
            this.hsbarManualSecondsOn.Minimum = 1;
            this.hsbarManualSecondsOn.Name = "hsbarManualSecondsOn";
            this.hsbarManualSecondsOn.Size = new System.Drawing.Size(333, 40);
            this.hsbarManualSecondsOn.TabIndex = 588;
            this.hsbarManualSecondsOn.Value = 2;
            this.hsbarManualSecondsOn.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarManualSecondsOn_Scroll);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Twol.Properties.Resources.MapGray;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(314, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 593;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FormToolManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(351, 56);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblManualPWM_Percent);
            this.Controls.Add(this.hsbarManualPWM_Percent);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblManualSecondsOn);
            this.Controls.Add(this.hsbarManualSecondsOn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnToolLeft);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnToolRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolManual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolManual_FormClosing);
            this.Load += new System.EventHandler(this.FormToolManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnToolRight;
        private System.Windows.Forms.Button btnToolLeft;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblManualPWM_Percent;
        private System.Windows.Forms.HScrollBar hsbarManualPWM_Percent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblManualSecondsOn;
        private System.Windows.Forms.HScrollBar hsbarManualSecondsOn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}