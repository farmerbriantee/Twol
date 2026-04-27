namespace Twol
{
    partial class FormNMEA_Data
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
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.lblSatsTracked = new System.Windows.Forms.Label();
            this.lblElevation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHDOP = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.tboxVTG = new System.Windows.Forms.TextBox();
            this.tboxGGA = new System.Windows.Forms.TextBox();
            this.tboxHDT = new System.Windows.Forms.TextBox();
            this.tboxAVR = new System.Windows.Forms.TextBox();
            this.tboxPAOGI = new System.Windows.Forms.TextBox();
            this.tboxHPD = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tboxPANDA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxKSXT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tboxRMC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFix2FixHeading = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblIMUHeading = new System.Windows.Forms.Label();
            this.lblEastingField = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(276, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Sats";
            // 
            // lblFixQuality
            // 
            this.lblFixQuality.AutoSize = true;
            this.lblFixQuality.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixQuality.Location = new System.Drawing.Point(198, 52);
            this.lblFixQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFixQuality.Name = "lblFixQuality";
            this.lblFixQuality.Size = new System.Drawing.Size(70, 19);
            this.lblFixQuality.TabIndex = 2;
            this.lblFixQuality.Text = "FixQual";
            this.lblFixQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSatsTracked
            // 
            this.lblSatsTracked.AutoSize = true;
            this.lblSatsTracked.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatsTracked.Location = new System.Drawing.Point(330, 28);
            this.lblSatsTracked.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSatsTracked.Name = "lblSatsTracked";
            this.lblSatsTracked.Size = new System.Drawing.Size(44, 19);
            this.lblSatsTracked.TabIndex = 4;
            this.lblSatsTracked.Text = "Sats";
            this.lblSatsTracked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblElevation
            // 
            this.lblElevation.AutoSize = true;
            this.lblElevation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElevation.Location = new System.Drawing.Point(443, 5);
            this.lblElevation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblElevation.Name = "lblElevation";
            this.lblElevation.Size = new System.Drawing.Size(85, 19);
            this.lblElevation.TabIndex = 14;
            this.lblElevation.Text = "Elevation";
            this.lblElevation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(410, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "Elev";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(279, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "HDOP";
            // 
            // lblHDOP
            // 
            this.lblHDOP.AutoSize = true;
            this.lblHDOP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDOP.Location = new System.Drawing.Point(330, 7);
            this.lblHDOP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHDOP.Name = "lblHDOP";
            this.lblHDOP.Size = new System.Drawing.Size(56, 19);
            this.lblHDOP.TabIndex = 17;
            this.lblHDOP.Text = "HDOP";
            this.lblHDOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(396, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 19);
            this.label17.TabIndex = 116;
            this.label17.Text = "Speed";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(443, 52);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(59, 19);
            this.lblSpeed.TabIndex = 115;
            this.lblSpeed.Text = "Speed";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(4, 206);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 13);
            this.label29.TabIndex = 496;
            this.label29.Text = "AVR";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(3, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 501;
            this.label19.Text = "GGA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(5, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 502;
            this.label11.Text = "OGI";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(5, 156);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 503;
            this.label26.Text = "VTG";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(4, 181);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 13);
            this.label30.TabIndex = 505;
            this.label30.Text = "HDT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(4, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 509;
            this.label4.Text = "HPD";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(36, 5);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(131, 19);
            this.lblLongitude.TabIndex = 13;
            this.lblLongitude.Text = "-111.12345678";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(2, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(2, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lat";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(36, 28);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(77, 19);
            this.lblLatitude.TabIndex = 12;
            this.lblLatitude.Text = "Latitude";
            // 
            // tboxVTG
            // 
            this.tboxVTG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxVTG.BackColor = System.Drawing.SystemColors.Window;
            this.tboxVTG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxVTG.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxVTG.Location = new System.Drawing.Point(35, 152);
            this.tboxVTG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxVTG.Name = "tboxVTG";
            this.tboxVTG.ReadOnly = true;
            this.tboxVTG.Size = new System.Drawing.Size(561, 23);
            this.tboxVTG.TabIndex = 497;
            this.tboxVTG.Text = "$GPVTG,0,T,034.4,M,1,N,1.852,K";
            // 
            // tboxGGA
            // 
            this.tboxGGA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxGGA.BackColor = System.Drawing.SystemColors.Window;
            this.tboxGGA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxGGA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxGGA.Location = new System.Drawing.Point(35, 127);
            this.tboxGGA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxGGA.Name = "tboxGGA";
            this.tboxGGA.ReadOnly = true;
            this.tboxGGA.Size = new System.Drawing.Size(561, 23);
            this.tboxGGA.TabIndex = 498;
            this.tboxGGA.Text = "$GPGGA,055129.00,5326.1729618,N,111,09.6028200,W,4,12,0.9,300,M,46.9,M,,,";
            // 
            // tboxHDT
            // 
            this.tboxHDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxHDT.BackColor = System.Drawing.SystemColors.Window;
            this.tboxHDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxHDT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHDT.Location = new System.Drawing.Point(35, 177);
            this.tboxHDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxHDT.Name = "tboxHDT";
            this.tboxHDT.ReadOnly = true;
            this.tboxHDT.Size = new System.Drawing.Size(561, 23);
            this.tboxHDT.TabIndex = 499;
            this.tboxHDT.Text = "$GNHDT,123.456,T * 00";
            // 
            // tboxAVR
            // 
            this.tboxAVR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxAVR.BackColor = System.Drawing.SystemColors.Window;
            this.tboxAVR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxAVR.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxAVR.Location = new System.Drawing.Point(35, 202);
            this.tboxAVR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxAVR.Name = "tboxAVR";
            this.tboxAVR.ReadOnly = true;
            this.tboxAVR.Size = new System.Drawing.Size(561, 23);
            this.tboxAVR.TabIndex = 500;
            this.tboxAVR.Text = "$PTNL,AVR,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03";
            // 
            // tboxPAOGI
            // 
            this.tboxPAOGI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxPAOGI.BackColor = System.Drawing.SystemColors.Window;
            this.tboxPAOGI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxPAOGI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPAOGI.Location = new System.Drawing.Point(35, 77);
            this.tboxPAOGI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxPAOGI.Name = "tboxPAOGI";
            this.tboxPAOGI.ReadOnly = true;
            this.tboxPAOGI.Size = new System.Drawing.Size(561, 23);
            this.tboxPAOGI.TabIndex = 504;
            this.tboxPAOGI.Text = "$PAOGI,055129.00,5326.1729618,N,111,09.6028200,W,4,12,0.9,300,M,46.9,M,,,";
            // 
            // tboxHPD
            // 
            this.tboxHPD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxHPD.BackColor = System.Drawing.SystemColors.Window;
            this.tboxHPD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxHPD.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxHPD.Location = new System.Drawing.Point(35, 227);
            this.tboxHPD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxHPD.Name = "tboxHPD";
            this.tboxHPD.ReadOnly = true;
            this.tboxHPD.Size = new System.Drawing.Size(561, 23);
            this.tboxHPD.TabIndex = 510;
            this.tboxHPD.Text = "$PTNL,AVR,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(443, 28);
            this.lblAge.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(41, 19);
            this.lblAge.TabIndex = 515;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(411, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 19);
            this.label12.TabIndex = 516;
            this.label12.Text = "Age";
            // 
            // tboxPANDA
            // 
            this.tboxPANDA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxPANDA.BackColor = System.Drawing.SystemColors.Window;
            this.tboxPANDA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxPANDA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPANDA.Location = new System.Drawing.Point(36, 102);
            this.tboxPANDA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxPANDA.Name = "tboxPANDA";
            this.tboxPANDA.ReadOnly = true;
            this.tboxPANDA.Size = new System.Drawing.Size(560, 23);
            this.tboxPANDA.TabIndex = 518;
            this.tboxPANDA.Text = "$PANDA,145331.50,+35.9990,Yaw,-7.8209,Tilt,-0.4305,Roll,444.232,3,1.2,17 * 03";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(5, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 517;
            this.label5.Text = "NDA";
            // 
            // tboxKSXT
            // 
            this.tboxKSXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxKSXT.BackColor = System.Drawing.SystemColors.Window;
            this.tboxKSXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxKSXT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxKSXT.Location = new System.Drawing.Point(35, 252);
            this.tboxKSXT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxKSXT.Name = "tboxKSXT";
            this.tboxKSXT.ReadOnly = true;
            this.tboxKSXT.Size = new System.Drawing.Size(561, 23);
            this.tboxKSXT.TabIndex = 528;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(4, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 527;
            this.label13.Text = "SXT";
            // 
            // tboxRMC
            // 
            this.tboxRMC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxRMC.BackColor = System.Drawing.SystemColors.Window;
            this.tboxRMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxRMC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxRMC.Location = new System.Drawing.Point(35, 277);
            this.tboxRMC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tboxRMC.Name = "tboxRMC";
            this.tboxRMC.ReadOnly = true;
            this.tboxRMC.Size = new System.Drawing.Size(561, 23);
            this.tboxRMC.TabIndex = 530;
            this.tboxRMC.Text = "$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 529;
            this.label1.Text = "RMC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(176, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 19);
            this.label10.TabIndex = 540;
            this.label10.Text = "Fix2";
            // 
            // lblFix2FixHeading
            // 
            this.lblFix2FixHeading.AutoSize = true;
            this.lblFix2FixHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblFix2FixHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFix2FixHeading.ForeColor = System.Drawing.Color.Black;
            this.lblFix2FixHeading.Location = new System.Drawing.Point(212, 4);
            this.lblFix2FixHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFix2FixHeading.Name = "lblFix2FixHeading";
            this.lblFix2FixHeading.Size = new System.Drawing.Size(19, 19);
            this.lblFix2FixHeading.TabIndex = 539;
            this.lblFix2FixHeading.Text = "0";
            this.lblFix2FixHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(176, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 19);
            this.label14.TabIndex = 538;
            this.label14.Text = "IMU";
            // 
            // lblIMUHeading
            // 
            this.lblIMUHeading.AutoSize = true;
            this.lblIMUHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblIMUHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMUHeading.ForeColor = System.Drawing.Color.Black;
            this.lblIMUHeading.Location = new System.Drawing.Point(212, 28);
            this.lblIMUHeading.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIMUHeading.Name = "lblIMUHeading";
            this.lblIMUHeading.Size = new System.Drawing.Size(19, 19);
            this.lblIMUHeading.TabIndex = 537;
            this.lblIMUHeading.Text = "0";
            this.lblIMUHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEastingField
            // 
            this.lblEastingField.AutoSize = true;
            this.lblEastingField.BackColor = System.Drawing.Color.Transparent;
            this.lblEastingField.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEastingField.ForeColor = System.Drawing.Color.Black;
            this.lblEastingField.Location = new System.Drawing.Point(42, 51);
            this.lblEastingField.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEastingField.Name = "lblEastingField";
            this.lblEastingField.Size = new System.Drawing.Size(153, 19);
            this.lblEastingField.TabIndex = 534;
            this.lblEastingField.Text = "-2000.45,-200043";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(-2, 51);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 19);
            this.label28.TabIndex = 531;
            this.label28.Text = "E,N";
            // 
            // FormNMEA_Data
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(596, 167);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFix2FixHeading);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblIMUHeading);
            this.Controls.Add(this.lblEastingField);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tboxRMC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxKSXT);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tboxPANDA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tboxHPD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tboxPAOGI);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tboxAVR);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.tboxHDT);
            this.Controls.Add(this.tboxGGA);
            this.Controls.Add(this.tboxVTG);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblHDOP);
            this.Controls.Add(this.lblElevation);
            this.Controls.Add(this.lblSatsTracked);
            this.Controls.Add(this.lblFixQuality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 110);
            this.Name = "FormNMEA_Data";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle GPS Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNMEA_Data_FormClosing);
            this.Load += new System.EventHandler(this.FormNMEA_Data_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSatsTracked;
        private System.Windows.Forms.Label lblElevation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHDOP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.TextBox tboxVTG;
        private System.Windows.Forms.TextBox tboxGGA;
        private System.Windows.Forms.TextBox tboxHDT;
        private System.Windows.Forms.TextBox tboxAVR;
        private System.Windows.Forms.TextBox tboxPAOGI;
        private System.Windows.Forms.TextBox tboxHPD;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tboxPANDA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxKSXT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tboxRMC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFix2FixHeading;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblIMUHeading;
        private System.Windows.Forms.Label lblEastingField;
        private System.Windows.Forms.Label label28;
    }
}