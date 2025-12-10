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
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHDOP = new System.Windows.Forms.Label();
            this.lblEastingField = new System.Windows.Forms.Label();
            this.lblNorthingField = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblHz = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTimeSlice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFrameTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbludpWatchCounts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFix2FixHeading = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblIMUHeading = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblFuzeHeading = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAngularVelocity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblMPerTile = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOriX = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblOriY = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCam = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(252, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Sats";
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.ForeColor = System.Drawing.Color.White;
            this.lblSatsTracked.Location = new System.Drawing.Point(304, 213);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(41, 18);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.White;
            this.lblLatitude.Location = new System.Drawing.Point(5, 24);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(70, 18);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.White;
            this.lblLongitude.Location = new System.Drawing.Point(5, 45);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(119, 18);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "-128.1234567";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.ForeColor = System.Drawing.Color.White;
            this.lblAltitude.Location = new System.Drawing.Point(304, 193);
            this.lblAltitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(67, 18);
            this.lblAltitude.TabIndex = 14;
            this.lblAltitude.Text = "Altitude";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(270, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Elev";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(257, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.ForeColor = System.Drawing.Color.White;
            this.lblHDOP.Location = new System.Drawing.Point(304, 233);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(52, 18);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "HDOP";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEastingField
            // 
            this.lblEastingField.AutoSize = true;
            this.lblEastingField.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEastingField.ForeColor = System.Drawing.Color.White;
            this.lblEastingField.Location = new System.Drawing.Point(34, 88);
            this.lblEastingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEastingField.Name = "lblEastingField";
            this.lblEastingField.Size = new System.Drawing.Size(63, 18);
            this.lblEastingField.TabIndex = 477;
            this.lblEastingField.Text = "Easting";
            // 
            // lblNorthingField
            // 
            this.lblNorthingField.AutoSize = true;
            this.lblNorthingField.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthingField.ForeColor = System.Drawing.Color.White;
            this.lblNorthingField.Location = new System.Drawing.Point(34, 68);
            this.lblNorthingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthingField.Name = "lblNorthingField";
            this.lblNorthingField.Size = new System.Drawing.Size(74, 18);
            this.lblNorthingField.TabIndex = 476;
            this.lblNorthingField.Text = "Northing";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(17, 88);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(16, 18);
            this.label27.TabIndex = 475;
            this.label27.Text = "E";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(15, 68);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(18, 18);
            this.label28.TabIndex = 474;
            this.label28.Text = "N";
            // 
            // lblHz
            // 
            this.lblHz.AutoSize = true;
            this.lblHz.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHz.ForeColor = System.Drawing.Color.White;
            this.lblHz.Location = new System.Drawing.Point(311, 132);
            this.lblHz.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHz.Name = "lblHz";
            this.lblHz.Size = new System.Drawing.Size(46, 18);
            this.lblHz.TabIndex = 506;
            this.lblHz.Text = "msec";
            this.lblHz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(288, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 18);
            this.label4.TabIndex = 509;
            this.label4.Text = "Hz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(256, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 18);
            this.label10.TabIndex = 511;
            this.label10.Text = "Raw Hz";
            // 
            // lblTimeSlice
            // 
            this.lblTimeSlice.AutoSize = true;
            this.lblTimeSlice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSlice.ForeColor = System.Drawing.Color.White;
            this.lblTimeSlice.Location = new System.Drawing.Point(311, 114);
            this.lblTimeSlice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeSlice.Name = "lblTimeSlice";
            this.lblTimeSlice.Size = new System.Drawing.Size(46, 18);
            this.lblTimeSlice.TabIndex = 510;
            this.lblTimeSlice.Text = "msec";
            this.lblTimeSlice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(9, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 18);
            this.label11.TabIndex = 513;
            this.label11.Text = "Frame";
            // 
            // lblFrameTime
            // 
            this.lblFrameTime.AutoSize = true;
            this.lblFrameTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameTime.ForeColor = System.Drawing.Color.White;
            this.lblFrameTime.Location = new System.Drawing.Point(57, 1);
            this.lblFrameTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFrameTime.Name = "lblFrameTime";
            this.lblFrameTime.Size = new System.Drawing.Size(46, 18);
            this.lblFrameTime.TabIndex = 512;
            this.lblFrameTime.Text = "msec";
            this.lblFrameTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(260, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 515;
            this.label2.Text = "Missed";
            // 
            // lbludpWatchCounts
            // 
            this.lbludpWatchCounts.AutoSize = true;
            this.lbludpWatchCounts.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbludpWatchCounts.ForeColor = System.Drawing.Color.White;
            this.lbludpWatchCounts.Location = new System.Drawing.Point(311, 156);
            this.lbludpWatchCounts.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbludpWatchCounts.Name = "lbludpWatchCounts";
            this.lbludpWatchCounts.Size = new System.Drawing.Size(46, 18);
            this.lbludpWatchCounts.TabIndex = 514;
            this.lbludpWatchCounts.Text = "msec";
            this.lbludpWatchCounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(253, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 519;
            this.label5.Text = "Fix2Fix";
            // 
            // lblFix2FixHeading
            // 
            this.lblFix2FixHeading.AutoSize = true;
            this.lblFix2FixHeading.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFix2FixHeading.ForeColor = System.Drawing.Color.White;
            this.lblFix2FixHeading.Location = new System.Drawing.Point(304, 1);
            this.lblFix2FixHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFix2FixHeading.Name = "lblFix2FixHeading";
            this.lblFix2FixHeading.Size = new System.Drawing.Size(53, 18);
            this.lblFix2FixHeading.TabIndex = 518;
            this.lblFix2FixHeading.Text = "359.1";
            this.lblFix2FixHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(269, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 18);
            this.label13.TabIndex = 517;
            this.label13.Text = "IMU";
            // 
            // lblIMUHeading
            // 
            this.lblIMUHeading.AutoSize = true;
            this.lblIMUHeading.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUHeading.ForeColor = System.Drawing.Color.White;
            this.lblIMUHeading.Location = new System.Drawing.Point(304, 22);
            this.lblIMUHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIMUHeading.Name = "lblIMUHeading";
            this.lblIMUHeading.Size = new System.Drawing.Size(53, 18);
            this.lblIMUHeading.TabIndex = 516;
            this.lblIMUHeading.Text = "321.6";
            this.lblIMUHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(245, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 521;
            this.label15.Text = "Heading";
            // 
            // lblFuzeHeading
            // 
            this.lblFuzeHeading.AutoSize = true;
            this.lblFuzeHeading.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuzeHeading.ForeColor = System.Drawing.Color.White;
            this.lblFuzeHeading.Location = new System.Drawing.Point(304, 43);
            this.lblFuzeHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFuzeHeading.Name = "lblFuzeHeading";
            this.lblFuzeHeading.Size = new System.Drawing.Size(53, 18);
            this.lblFuzeHeading.TabIndex = 520;
            this.lblFuzeHeading.Text = "344.0";
            this.lblFuzeHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(279, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 18);
            this.label12.TabIndex = 523;
            this.label12.Text = "AV";
            // 
            // lblAngularVelocity
            // 
            this.lblAngularVelocity.AutoSize = true;
            this.lblAngularVelocity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngularVelocity.ForeColor = System.Drawing.Color.White;
            this.lblAngularVelocity.Location = new System.Drawing.Point(304, 69);
            this.lblAngularVelocity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAngularVelocity.Name = "lblAngularVelocity";
            this.lblAngularVelocity.Size = new System.Drawing.Size(43, 18);
            this.lblAngularVelocity.TabIndex = 522;
            this.lblAngularVelocity.Text = "3.56";
            this.lblAngularVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 18);
            this.label1.TabIndex = 525;
            this.label1.Text = "X";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.ForeColor = System.Drawing.Color.White;
            this.lblX.Location = new System.Drawing.Point(31, 167);
            this.lblX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(44, 19);
            this.lblX.TabIndex = 524;
            this.lblX.Text = "3.56";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 18);
            this.label7.TabIndex = 527;
            this.label7.Text = "Y";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.ForeColor = System.Drawing.Color.White;
            this.lblY.Location = new System.Drawing.Point(31, 187);
            this.lblY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(44, 19);
            this.lblY.TabIndex = 526;
            this.lblY.Text = "3.56";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMPerTile
            // 
            this.lblMPerTile.AutoSize = true;
            this.lblMPerTile.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPerTile.ForeColor = System.Drawing.Color.White;
            this.lblMPerTile.Location = new System.Drawing.Point(72, 213);
            this.lblMPerTile.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMPerTile.Name = "lblMPerTile";
            this.lblMPerTile.Size = new System.Drawing.Size(33, 18);
            this.lblMPerTile.TabIndex = 528;
            this.lblMPerTile.Text = "0.1";
            this.lblMPerTile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(24, 211);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 18);
            this.label14.TabIndex = 529;
            this.label14.Text = "m/Tile";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.ForeColor = System.Drawing.Color.White;
            this.lblZ.Location = new System.Drawing.Point(58, 120);
            this.lblZ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(33, 18);
            this.lblZ.TabIndex = 530;
            this.lblZ.Text = "0.1";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(9, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 18);
            this.label16.TabIndex = 531;
            this.label16.Text = "Zoom";
            // 
            // lblOriX
            // 
            this.lblOriX.AutoSize = true;
            this.lblOriX.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriX.ForeColor = System.Drawing.Color.White;
            this.lblOriX.Location = new System.Drawing.Point(72, 238);
            this.lblOriX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOriX.Name = "lblOriX";
            this.lblOriX.Size = new System.Drawing.Size(33, 18);
            this.lblOriX.TabIndex = 532;
            this.lblOriX.Text = "0.1";
            this.lblOriX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(4, 237);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 18);
            this.label18.TabIndex = 533;
            this.label18.Text = "Ori_To_X";
            // 
            // lblOriY
            // 
            this.lblOriY.AutoSize = true;
            this.lblOriY.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriY.ForeColor = System.Drawing.Color.White;
            this.lblOriY.Location = new System.Drawing.Point(72, 261);
            this.lblOriY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOriY.Name = "lblOriY";
            this.lblOriY.Size = new System.Drawing.Size(33, 18);
            this.lblOriY.TabIndex = 534;
            this.lblOriY.Text = "0.1";
            this.lblOriY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 260);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 18);
            this.label20.TabIndex = 535;
            this.label20.Text = "Ori_To_Y";
            // 
            // lblCam
            // 
            this.lblCam.AutoSize = true;
            this.lblCam.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam.ForeColor = System.Drawing.Color.White;
            this.lblCam.Location = new System.Drawing.Point(57, 143);
            this.lblCam.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCam.Name = "lblCam";
            this.lblCam.Size = new System.Drawing.Size(33, 18);
            this.lblCam.TabIndex = 536;
            this.lblCam.Text = "0.1";
            this.lblCam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(16, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 18);
            this.label17.TabIndex = 537;
            this.label17.Text = "Cam";
            // 
            // FormGPSData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(178, 418);
            this.Controls.Add(this.lblCam);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblOriY);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblOriX);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblZ);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblMPerTile);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblAngularVelocity);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblFuzeHeading);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFix2FixHeading);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblIMUHeading);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbludpWatchCounts);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFrameTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTimeSlice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHz);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblEastingField);
            this.Controls.Add(this.lblNorthingField);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblAltitude);
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
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHDOP;
        private System.Windows.Forms.Label lblEastingField;
        private System.Windows.Forms.Label lblNorthingField;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblHz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTimeSlice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFrameTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbludpWatchCounts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFix2FixHeading;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblIMUHeading;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblFuzeHeading;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAngularVelocity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblMPerTile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblOriX;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblOriY;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCam;
        private System.Windows.Forms.Label label17;
    }
}