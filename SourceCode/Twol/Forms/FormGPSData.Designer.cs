namespace Twol
{
    partial class FormGPSData
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblSatsTracked = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblElevation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHDOP = new System.Windows.Forms.Label();
            this.lblEastingField = new System.Windows.Forms.Label();
            this.lblNorthingField = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblHz = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTimeSlice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFrameTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFix2FixHeading = new System.Windows.Forms.Label();
            this.lblIMUHeading = new System.Windows.Forms.Label();
            this.lblFuzeHeading = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sats";
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.ForeColor = System.Drawing.Color.White;
            this.lblSatsTracked.Location = new System.Drawing.Point(57, 246);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(25, 26);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "0";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitude
            // 
            this.lblLatitude.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.White;
            this.lblLatitude.Location = new System.Drawing.Point(3, 3);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(170, 26);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "0";
            this.lblLatitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLongitude
            // 
            this.lblLongitude.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.White;
            this.lblLongitude.Location = new System.Drawing.Point(5, 28);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(166, 26);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "0";
            this.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblElevation
            // 
            this.lblElevation.AutoSize = true;
            this.lblElevation.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElevation.ForeColor = System.Drawing.Color.White;
            this.lblElevation.Location = new System.Drawing.Point(57, 214);
            this.lblElevation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblElevation.Name = "lblElevation";
            this.lblElevation.Size = new System.Drawing.Size(25, 26);
            this.lblElevation.TabIndex = 14;
            this.lblElevation.Text = "0";
            this.lblElevation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(4, 214);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "Elev";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.ForeColor = System.Drawing.Color.White;
            this.lblHDOP.Location = new System.Drawing.Point(126, 246);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(25, 26);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "0";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEastingField
            // 
            this.lblEastingField.AutoSize = true;
            this.lblEastingField.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEastingField.ForeColor = System.Drawing.Color.White;
            this.lblEastingField.Location = new System.Drawing.Point(57, 87);
            this.lblEastingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEastingField.Name = "lblEastingField";
            this.lblEastingField.Size = new System.Drawing.Size(25, 26);
            this.lblEastingField.TabIndex = 477;
            this.lblEastingField.Text = "0";
            // 
            // lblNorthingField
            // 
            this.lblNorthingField.AutoSize = true;
            this.lblNorthingField.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthingField.ForeColor = System.Drawing.Color.White;
            this.lblNorthingField.Location = new System.Drawing.Point(57, 59);
            this.lblNorthingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthingField.Name = "lblNorthingField";
            this.lblNorthingField.Size = new System.Drawing.Size(25, 26);
            this.lblNorthingField.TabIndex = 476;
            this.lblNorthingField.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(32, 87);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(25, 26);
            this.label27.TabIndex = 475;
            this.label27.Text = "E";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(30, 59);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 26);
            this.label28.TabIndex = 474;
            this.label28.Text = "N";
            // 
            // lblHz
            // 
            this.lblHz.AutoSize = true;
            this.lblHz.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHz.ForeColor = System.Drawing.Color.White;
            this.lblHz.Location = new System.Drawing.Point(126, 183);
            this.lblHz.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(25, 26);
            this.lblHz.TabIndex = 506;
            this.lblHz.Text = "0";
            this.lblHz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 26);
            this.label4.TabIndex = 509;
            this.label4.Text = "Hz";
            // 
            // lblTimeSlice
            // 
            this.lblTimeSlice.AutoSize = true;
            this.lblTimeSlice.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSlice.ForeColor = System.Drawing.Color.White;
            this.lblTimeSlice.Location = new System.Drawing.Point(57, 183);
            this.lblTimeSlice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeSlice.Name = "lblTimeSlice";
            this.lblTimeSlice.Size = new System.Drawing.Size(25, 26);
            this.lblTimeSlice.TabIndex = 510;
            this.lblTimeSlice.Text = "0";
            this.lblTimeSlice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(6, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 26);
            this.label11.TabIndex = 513;
            this.label11.Text = "Frame";
            // 
            // lblFrameTime
            // 
            this.lblFrameTime.AutoSize = true;
            this.lblFrameTime.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameTime.ForeColor = System.Drawing.Color.White;
            this.lblFrameTime.Location = new System.Drawing.Point(78, 292);
            this.lblFrameTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFrameTime.Name = "lblFrameTime";
            this.lblFrameTime.Size = new System.Drawing.Size(25, 26);
            this.lblFrameTime.TabIndex = 512;
            this.lblFrameTime.Text = "0";
            this.lblFrameTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 26);
            this.label5.TabIndex = 519;
            this.label5.Text = "Fix2";
            // 
            // lblFix2FixHeading
            // 
            this.lblFix2FixHeading.AutoSize = true;
            this.lblFix2FixHeading.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFix2FixHeading.ForeColor = System.Drawing.Color.White;
            this.lblFix2FixHeading.Location = new System.Drawing.Point(57, 125);
            this.lblFix2FixHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFix2FixHeading.Name = "lblFix2FixHeading";
            this.lblFix2FixHeading.Size = new System.Drawing.Size(25, 26);
            this.lblFix2FixHeading.TabIndex = 518;
            this.lblFix2FixHeading.Text = "0";
            this.lblFix2FixHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIMUHeading
            // 
            this.lblIMUHeading.AutoSize = true;
            this.lblIMUHeading.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUHeading.ForeColor = System.Drawing.Color.White;
            this.lblIMUHeading.Location = new System.Drawing.Point(57, 151);
            this.lblIMUHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIMUHeading.Name = "lblIMUHeading";
            this.lblIMUHeading.Size = new System.Drawing.Size(25, 26);
            this.lblIMUHeading.TabIndex = 516;
            this.lblIMUHeading.Text = "0";
            this.lblIMUHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFuzeHeading
            // 
            this.lblFuzeHeading.AutoSize = true;
            this.lblFuzeHeading.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuzeHeading.ForeColor = System.Drawing.Color.White;
            this.lblFuzeHeading.Location = new System.Drawing.Point(126, 125);
            this.lblFuzeHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFuzeHeading.Name = "lblFuzeHeading";
            this.lblFuzeHeading.Size = new System.Drawing.Size(25, 26);
            this.lblFuzeHeading.TabIndex = 520;
            this.lblFuzeHeading.Text = "0";
            this.lblFuzeHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(6, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 26);
            this.label13.TabIndex = 517;
            this.label13.Text = "IMU";
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(193, 336);
            this.Controls.Add(this.lblFuzeHeading);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFix2FixHeading);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblIMUHeading);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFrameTime);
            this.Controls.Add(this.lblTimeSlice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHz);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblEastingField);
            this.Controls.Add(this.lblNorthingField);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblElevation);
            this.Controls.Add(this.lblSatsTracked);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGPSData";
            this.ShowInTaskbar = false;
            this.Text = "System Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPSData_FormClosing);
            this.Load += new System.EventHandler(this.FormGPSData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSatsTracked;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblElevation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHDOP;
        private System.Windows.Forms.Label lblEastingField;
        private System.Windows.Forms.Label lblNorthingField;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblHz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTimeSlice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFrameTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFix2FixHeading;
        private System.Windows.Forms.Label lblIMUHeading;
        private System.Windows.Forms.Label lblFuzeHeading;
        private System.Windows.Forms.Label label13;
    }
}