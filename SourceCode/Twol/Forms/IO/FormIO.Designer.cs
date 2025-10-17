namespace Twol
{
    partial class FormIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIO));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGain = new System.Windows.Forms.TabPage();
            this.lblGain = new System.Windows.Forms.Label();
            this.nudAntennaHeight_Tool = new Twol.NudlessNumericUpDown();
            this.hsbarMinPWM_Tool = new System.Windows.Forms.HScrollBar();
            this.lblMinPWM_Tool = new System.Windows.Forms.Label();
            this.cboxGPSTool = new System.Windows.Forms.CheckBox();
            this.label87 = new System.Windows.Forms.Label();
            this.tabSteer = new System.Windows.Forms.TabPage();
            this.lblAV_Set = new System.Windows.Forms.Label();
            this.lblAV_Act = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lblActualSteerAngleUpper = new System.Windows.Forms.Label();
            this.tabPP = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPPAdv = new System.Windows.Forms.TabPage();
            this.label51 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.nudDeadZoneHeading = new Twol.NudlessNumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExpand = new Twol.RepeatButton();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnStartStopNtrip = new System.Windows.Forms.Button();
            this.lblWatch = new System.Windows.Forms.Label();
            this.lblNTRIPBytes = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGPS = new System.Windows.Forms.Button();
            this.btnGPSTool = new System.Windows.Forms.Button();
            this.btnSteer = new System.Windows.Forms.Button();
            this.btnMachine = new System.Windows.Forms.Button();
            this.btnIMU = new System.Windows.Forms.Button();
            this.btnUDP = new System.Windows.Forms.Button();
            this.btnProfiles = new System.Windows.Forms.Button();
            this.lbl_IO_Profile = new System.Windows.Forms.Label();
            this.btnMinimizeMainForm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGain.SuspendLayout();
            this.tabSteer.SuspendLayout();
            this.tabPP.SuspendLayout();
            this.tabPPAdv.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabGain);
            this.tabControl1.Controls.Add(this.tabSteer);
            this.tabControl1.Controls.Add(this.tabPP);
            this.tabControl1.Controls.Add(this.tabPPAdv);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(90, 52);
            this.tabControl1.Location = new System.Drawing.Point(2, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 402);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 347;
            // 
            // tabGain
            // 
            this.tabGain.AutoScroll = true;
            this.tabGain.BackColor = System.Drawing.Color.LightGray;
            this.tabGain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabGain.Controls.Add(this.lblGain);
            this.tabGain.Controls.Add(this.nudAntennaHeight_Tool);
            this.tabGain.Controls.Add(this.hsbarMinPWM_Tool);
            this.tabGain.Controls.Add(this.lblMinPWM_Tool);
            this.tabGain.Controls.Add(this.cboxGPSTool);
            this.tabGain.Controls.Add(this.label87);
            this.tabGain.ImageIndex = 1;
            this.tabGain.Location = new System.Drawing.Point(4, 56);
            this.tabGain.Name = "tabGain";
            this.tabGain.Size = new System.Drawing.Size(365, 342);
            this.tabGain.TabIndex = 13;
            // 
            // lblGain
            // 
            this.lblGain.AutoSize = true;
            this.lblGain.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGain.ForeColor = System.Drawing.Color.Black;
            this.lblGain.Location = new System.Drawing.Point(35, 14);
            this.lblGain.Name = "lblGain";
            this.lblGain.Size = new System.Drawing.Size(60, 25);
            this.lblGain.TabIndex = 339;
            this.lblGain.Text = "Gain";
            this.lblGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudAntennaHeight_Tool
            // 
            this.nudAntennaHeight_Tool.Location = new System.Drawing.Point(127, 63);
            this.nudAntennaHeight_Tool.Maximum = 5D;
            this.nudAntennaHeight_Tool.Mode = Twol.UnitMode.Small;
            this.nudAntennaHeight_Tool.Name = "nudAntennaHeight_Tool";
            this.nudAntennaHeight_Tool.Size = new System.Drawing.Size(143, 56);
            this.nudAntennaHeight_Tool.TabIndex = 580;
            this.nudAntennaHeight_Tool.ValueChanged += new System.EventHandler(this.nudAntennaHeight_Tool_ValueChanged);
            // 
            // hsbarMinPWM_Tool
            // 
            this.hsbarMinPWM_Tool.LargeChange = 1;
            this.hsbarMinPWM_Tool.Location = new System.Drawing.Point(67, 272);
            this.hsbarMinPWM_Tool.Maximum = 200;
            this.hsbarMinPWM_Tool.Name = "hsbarMinPWM_Tool";
            this.hsbarMinPWM_Tool.Size = new System.Drawing.Size(292, 41);
            this.hsbarMinPWM_Tool.TabIndex = 557;
            this.hsbarMinPWM_Tool.Value = 10;
            this.hsbarMinPWM_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarMinPWM_Tool_Scroll);
            // 
            // lblMinPWM_Tool
            // 
            this.lblMinPWM_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblMinPWM_Tool.Location = new System.Drawing.Point(7, 273);
            this.lblMinPWM_Tool.Name = "lblMinPWM_Tool";
            this.lblMinPWM_Tool.Size = new System.Drawing.Size(61, 35);
            this.lblMinPWM_Tool.TabIndex = 558;
            this.lblMinPWM_Tool.Text = "888";
            this.lblMinPWM_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxGPSTool
            // 
            this.cboxGPSTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxGPSTool.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxGPSTool.Checked = true;
            this.cboxGPSTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxGPSTool.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxGPSTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxGPSTool.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxGPSTool.ForeColor = System.Drawing.Color.Black;
            this.cboxGPSTool.Location = new System.Drawing.Point(86, 147);
            this.cboxGPSTool.Name = "cboxGPSTool";
            this.cboxGPSTool.Size = new System.Drawing.Size(120, 47);
            this.cboxGPSTool.TabIndex = 485;
            this.cboxGPSTool.Text = "Tool On";
            this.cboxGPSTool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxGPSTool.UseVisualStyleBackColor = false;
            this.cboxGPSTool.Click += new System.EventHandler(this.cboxGPSTool_Click);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(82, 244);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(262, 24);
            this.label87.TabIndex = 561;
            this.label87.Text = "Minimum PWM to Move";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSteer
            // 
            this.tabSteer.AutoScroll = true;
            this.tabSteer.BackColor = System.Drawing.Color.LightGray;
            this.tabSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabSteer.Controls.Add(this.lblAV_Set);
            this.tabSteer.Controls.Add(this.lblAV_Act);
            this.tabSteer.Controls.Add(this.label36);
            this.tabSteer.Controls.Add(this.label38);
            this.tabSteer.Controls.Add(this.lblActualSteerAngleUpper);
            this.tabSteer.ImageIndex = 4;
            this.tabSteer.Location = new System.Drawing.Point(4, 56);
            this.tabSteer.Name = "tabSteer";
            this.tabSteer.Size = new System.Drawing.Size(365, 342);
            this.tabSteer.TabIndex = 5;
            // 
            // lblAV_Set
            // 
            this.lblAV_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAV_Set.AutoSize = true;
            this.lblAV_Set.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAV_Set.Location = new System.Drawing.Point(-334, 18);
            this.lblAV_Set.Name = "lblAV_Set";
            this.lblAV_Set.Size = new System.Drawing.Size(51, 19);
            this.lblAV_Set.TabIndex = 529;
            this.lblAV_Set.Text = "-55.8";
            this.lblAV_Set.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAV_Act
            // 
            this.lblAV_Act.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAV_Act.AutoSize = true;
            this.lblAV_Act.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAV_Act.Location = new System.Drawing.Point(-334, 42);
            this.lblAV_Act.Name = "lblAV_Act";
            this.lblAV_Act.Size = new System.Drawing.Size(54, 19);
            this.lblAV_Act.TabIndex = 528;
            this.lblAV_Act.Text = "66.89";
            this.lblAV_Act.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(-378, 44);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 16);
            this.label36.TabIndex = 530;
            this.label36.Text = "AV Act:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(-379, 20);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(51, 16);
            this.label38.TabIndex = 531;
            this.label38.Text = "AV Set:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActualSteerAngleUpper
            // 
            this.lblActualSteerAngleUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualSteerAngleUpper.AutoSize = true;
            this.lblActualSteerAngleUpper.BackColor = System.Drawing.Color.Transparent;
            this.lblActualSteerAngleUpper.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualSteerAngleUpper.ForeColor = System.Drawing.Color.Black;
            this.lblActualSteerAngleUpper.Location = new System.Drawing.Point(-573, 16);
            this.lblActualSteerAngleUpper.Name = "lblActualSteerAngleUpper";
            this.lblActualSteerAngleUpper.Size = new System.Drawing.Size(39, 19);
            this.lblActualSteerAngleUpper.TabIndex = 324;
            this.lblActualSteerAngleUpper.Text = "255";
            this.lblActualSteerAngleUpper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPP
            // 
            this.tabPP.BackColor = System.Drawing.Color.LightGray;
            this.tabPP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPP.Controls.Add(this.label20);
            this.tabPP.Controls.Add(this.label18);
            this.tabPP.ForeColor = System.Drawing.Color.Black;
            this.tabPP.ImageIndex = 0;
            this.tabPP.Location = new System.Drawing.Point(4, 56);
            this.tabPP.Name = "tabPP";
            this.tabPP.Size = new System.Drawing.Size(365, 342);
            this.tabPP.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label20.Location = new System.Drawing.Point(579, 228);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(204, 30);
            this.label20.TabIndex = 302;
            this.label20.Text = "Look Ahead Min";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(561, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(204, 30);
            this.label18.TabIndex = 300;
            this.label18.Text = "Look Ahead";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPPAdv
            // 
            this.tabPPAdv.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPPAdv.Controls.Add(this.label51);
            this.tabPPAdv.Controls.Add(this.label49);
            this.tabPPAdv.Controls.Add(this.nudDeadZoneHeading);
            this.tabPPAdv.ImageIndex = 2;
            this.tabPPAdv.Location = new System.Drawing.Point(4, 56);
            this.tabPPAdv.Name = "tabPPAdv";
            this.tabPPAdv.Padding = new System.Windows.Forms.Padding(3);
            this.tabPPAdv.Size = new System.Drawing.Size(365, 342);
            this.tabPPAdv.TabIndex = 17;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(20, 30);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(329, 25);
            this.label51.TabIndex = 541;
            this.label51.Text = "Dead Zone";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label49.Location = new System.Drawing.Point(26, 112);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(165, 46);
            this.label49.TabIndex = 539;
            this.label49.Text = "Heading (Degree)";
            this.label49.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudDeadZoneHeading
            // 
            this.nudDeadZoneHeading.DecimalPlaces = 1;
            this.nudDeadZoneHeading.Location = new System.Drawing.Point(56, 71);
            this.nudDeadZoneHeading.Maximum = 5D;
            this.nudDeadZoneHeading.Minimum = 0.1D;
            this.nudDeadZoneHeading.Name = "nudDeadZoneHeading";
            this.nudDeadZoneHeading.Size = new System.Drawing.Size(107, 36);
            this.nudDeadZoneHeading.TabIndex = 538;
            this.nudDeadZoneHeading.ValueChanged += new System.EventHandler(this.nudDeadZoneHeading_ValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Sf_PPTab.png");
            this.imageList1.Images.SetKeyName(1, "ST_GainTab.png");
            this.imageList1.Images.SetKeyName(2, "ST_NerdAdv.png");
            this.imageList1.Images.SetKeyName(3, "ST_StanleyTab.png");
            this.imageList1.Images.SetKeyName(4, "ST_SteerTab.png");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnExpand);
            this.panel2.Location = new System.Drawing.Point(4, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 100);
            this.panel2.TabIndex = 324;
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpand.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpand.Image = global::Twol.Properties.Resources.ArrowRight;
            this.btnExpand.Location = new System.Drawing.Point(299, 60);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(62, 37);
            this.btnExpand.TabIndex = 329;
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "ConS_Alarm.png");
            this.imageList2.Images.SetKeyName(1, "ConS_ImplementConfig.png");
            this.imageList2.Images.SetKeyName(2, "ConS_ModulesSteer.png");
            this.imageList2.Images.SetKeyName(3, "ConS_Pins.png");
            this.imageList2.Images.SetKeyName(4, "Sensors.png");
            this.imageList2.Images.SetKeyName(5, "Con_ImplementMenu.png");
            // 
            // btnStartStopNtrip
            // 
            this.btnStartStopNtrip.BackColor = System.Drawing.Color.LightGray;
            this.btnStartStopNtrip.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnStartStopNtrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStopNtrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStopNtrip.ForeColor = System.Drawing.Color.Black;
            this.btnStartStopNtrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartStopNtrip.Location = new System.Drawing.Point(406, 78);
            this.btnStartStopNtrip.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStopNtrip.Name = "btnStartStopNtrip";
            this.btnStartStopNtrip.Size = new System.Drawing.Size(80, 27);
            this.btnStartStopNtrip.TabIndex = 186;
            this.btnStartStopNtrip.Text = "StartStop";
            this.btnStartStopNtrip.UseVisualStyleBackColor = false;
            // 
            // lblWatch
            // 
            this.lblWatch.BackColor = System.Drawing.Color.Transparent;
            this.lblWatch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWatch.Location = new System.Drawing.Point(392, 36);
            this.lblWatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWatch.Name = "lblWatch";
            this.lblWatch.Size = new System.Drawing.Size(105, 18);
            this.lblWatch.TabIndex = 188;
            this.lblWatch.Text = "Watch";
            this.lblWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNTRIPBytes
            // 
            this.lblNTRIPBytes.BackColor = System.Drawing.Color.Transparent;
            this.lblNTRIPBytes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTRIPBytes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNTRIPBytes.Location = new System.Drawing.Point(392, 5);
            this.lblNTRIPBytes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNTRIPBytes.Name = "lblNTRIPBytes";
            this.lblNTRIPBytes.Size = new System.Drawing.Size(105, 18);
            this.lblNTRIPBytes.TabIndex = 187;
            this.lblNTRIPBytes.Text = "999,999,999";
            this.lblNTRIPBytes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIP
            // 
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIP.Location = new System.Drawing.Point(392, 145);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(119, 64);
            this.lblIP.TabIndex = 465;
            this.lblIP.Text = "288.288.288.288";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::Twol.Properties.Resources.Nmea;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(521, 426);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 32);
            this.button1.TabIndex = 514;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnGPS
            // 
            this.btnGPS.BackColor = System.Drawing.Color.Transparent;
            this.btnGPS.BackgroundImage = global::Twol.Properties.Resources.B_GPS;
            this.btnGPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGPS.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnGPS.FlatAppearance.BorderSize = 0;
            this.btnGPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGPS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPS.ForeColor = System.Drawing.Color.White;
            this.btnGPS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGPS.Location = new System.Drawing.Point(406, 234);
            this.btnGPS.Margin = new System.Windows.Forms.Padding(4);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(80, 65);
            this.btnGPS.TabIndex = 516;
            this.btnGPS.UseVisualStyleBackColor = false;
            // 
            // btnGPSTool
            // 
            this.btnGPSTool.BackColor = System.Drawing.Color.Transparent;
            this.btnGPSTool.BackgroundImage = global::Twol.Properties.Resources.B_GPSTool;
            this.btnGPSTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGPSTool.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnGPSTool.FlatAppearance.BorderSize = 0;
            this.btnGPSTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGPSTool.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPSTool.ForeColor = System.Drawing.Color.White;
            this.btnGPSTool.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGPSTool.Location = new System.Drawing.Point(406, 309);
            this.btnGPSTool.Margin = new System.Windows.Forms.Padding(4);
            this.btnGPSTool.Name = "btnGPSTool";
            this.btnGPSTool.Size = new System.Drawing.Size(80, 65);
            this.btnGPSTool.TabIndex = 531;
            this.btnGPSTool.UseVisualStyleBackColor = false;
            // 
            // btnSteer
            // 
            this.btnSteer.BackColor = System.Drawing.Color.Transparent;
            this.btnSteer.BackgroundImage = global::Twol.Properties.Resources.B_Autosteer;
            this.btnSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSteer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSteer.FlatAppearance.BorderSize = 0;
            this.btnSteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSteer.ForeColor = System.Drawing.Color.White;
            this.btnSteer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSteer.Location = new System.Drawing.Point(536, 90);
            this.btnSteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSteer.Name = "btnSteer";
            this.btnSteer.Size = new System.Drawing.Size(80, 65);
            this.btnSteer.TabIndex = 518;
            this.btnSteer.UseVisualStyleBackColor = false;
            // 
            // btnMachine
            // 
            this.btnMachine.BackColor = System.Drawing.Color.Transparent;
            this.btnMachine.BackgroundImage = global::Twol.Properties.Resources.B_Machine;
            this.btnMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMachine.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnMachine.FlatAppearance.BorderSize = 0;
            this.btnMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMachine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMachine.ForeColor = System.Drawing.Color.White;
            this.btnMachine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMachine.Location = new System.Drawing.Point(536, 165);
            this.btnMachine.Margin = new System.Windows.Forms.Padding(4);
            this.btnMachine.Name = "btnMachine";
            this.btnMachine.Size = new System.Drawing.Size(80, 65);
            this.btnMachine.TabIndex = 517;
            this.btnMachine.UseVisualStyleBackColor = false;
            // 
            // btnIMU
            // 
            this.btnIMU.BackColor = System.Drawing.Color.Transparent;
            this.btnIMU.BackgroundImage = global::Twol.Properties.Resources.B_IMU;
            this.btnIMU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIMU.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnIMU.FlatAppearance.BorderSize = 0;
            this.btnIMU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIMU.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMU.ForeColor = System.Drawing.Color.White;
            this.btnIMU.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIMU.Location = new System.Drawing.Point(536, 240);
            this.btnIMU.Margin = new System.Windows.Forms.Padding(4);
            this.btnIMU.Name = "btnIMU";
            this.btnIMU.Size = new System.Drawing.Size(80, 65);
            this.btnIMU.TabIndex = 515;
            this.btnIMU.UseVisualStyleBackColor = false;
            // 
            // btnUDP
            // 
            this.btnUDP.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUDP.BackgroundImage = global::Twol.Properties.Resources.B_UDP;
            this.btnUDP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUDP.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnUDP.FlatAppearance.BorderSize = 0;
            this.btnUDP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUDP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUDP.ForeColor = System.Drawing.Color.White;
            this.btnUDP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUDP.Location = new System.Drawing.Point(395, 391);
            this.btnUDP.Margin = new System.Windows.Forms.Padding(4);
            this.btnUDP.Name = "btnUDP";
            this.btnUDP.Size = new System.Drawing.Size(109, 85);
            this.btnUDP.TabIndex = 185;
            this.btnUDP.UseVisualStyleBackColor = false;
            // 
            // btnProfiles
            // 
            this.btnProfiles.BackColor = System.Drawing.Color.Gainsboro;
            this.btnProfiles.BackgroundImage = global::Twol.Properties.Resources.VehFileSave;
            this.btnProfiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProfiles.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnProfiles.FlatAppearance.BorderSize = 0;
            this.btnProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfiles.ForeColor = System.Drawing.Color.White;
            this.btnProfiles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProfiles.Location = new System.Drawing.Point(521, 313);
            this.btnProfiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnProfiles.Name = "btnProfiles";
            this.btnProfiles.Size = new System.Drawing.Size(114, 57);
            this.btnProfiles.TabIndex = 532;
            this.btnProfiles.UseVisualStyleBackColor = false;
            // 
            // lbl_IO_Profile
            // 
            this.lbl_IO_Profile.BackColor = System.Drawing.Color.Transparent;
            this.lbl_IO_Profile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IO_Profile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_IO_Profile.Location = new System.Drawing.Point(373, 473);
            this.lbl_IO_Profile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_IO_Profile.Name = "lbl_IO_Profile";
            this.lbl_IO_Profile.Size = new System.Drawing.Size(257, 30);
            this.lbl_IO_Profile.TabIndex = 533;
            this.lbl_IO_Profile.Text = "Profile";
            this.lbl_IO_Profile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimizeMainForm
            // 
            this.btnMinimizeMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeMainForm.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimizeMainForm.FlatAppearance.BorderSize = 0;
            this.btnMinimizeMainForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeMainForm.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeMainForm.ForeColor = System.Drawing.Color.DimGray;
            this.btnMinimizeMainForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinimizeMainForm.Location = new System.Drawing.Point(779, 20);
            this.btnMinimizeMainForm.Name = "btnMinimizeMainForm";
            this.btnMinimizeMainForm.Size = new System.Drawing.Size(62, 38);
            this.btnMinimizeMainForm.TabIndex = 534;
            this.btnMinimizeMainForm.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Image = global::Twol.Properties.Resources.WindowMinimize;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(536, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 38);
            this.button2.TabIndex = 535;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(846, 542);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnMinimizeMainForm);
            this.Controls.Add(this.btnProfiles);
            this.Controls.Add(this.btnGPS);
            this.Controls.Add(this.btnGPSTool);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.btnSteer);
            this.Controls.Add(this.btnStartStopNtrip);
            this.Controls.Add(this.btnMachine);
            this.Controls.Add(this.btnIMU);
            this.Controls.Add(this.lblWatch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblNTRIPBytes);
            this.Controls.Add(this.btnUDP);
            this.Controls.Add(this.lbl_IO_Profile);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIO";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool Steer Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormIO_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGain.ResumeLayout(false);
            this.tabGain.PerformLayout();
            this.tabSteer.ResumeLayout(false);
            this.tabSteer.PerformLayout();
            this.tabPP.ResumeLayout(false);
            this.tabPPAdv.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGain;
        private System.Windows.Forms.TabPage tabPP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabSteer;
        private System.Windows.Forms.Label lblActualSteerAngleUpper;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGain;
        private System.Windows.Forms.Label lblAV_Set;
        private System.Windows.Forms.Label lblAV_Act;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private RepeatButton btnExpand;
        private System.Windows.Forms.Label label49;
        private NudlessNumericUpDown nudDeadZoneHeading;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TabPage tabPPAdv;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.CheckBox cboxGPSTool;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.HScrollBar hsbarMinPWM_Tool;
        private System.Windows.Forms.Label lblMinPWM_Tool;
        private NudlessNumericUpDown nudAntennaHeight_Tool;
        private System.Windows.Forms.Button btnStartStopNtrip;
        private System.Windows.Forms.Label lblWatch;
        private System.Windows.Forms.Label lblNTRIPBytes;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnGPS;
        public System.Windows.Forms.Button btnGPSTool;
        public System.Windows.Forms.Button btnSteer;
        public System.Windows.Forms.Button btnMachine;
        public System.Windows.Forms.Button btnIMU;
        private System.Windows.Forms.Button btnUDP;
        private System.Windows.Forms.Button btnProfiles;
        private System.Windows.Forms.Label lbl_IO_Profile;
        private System.Windows.Forms.Button btnMinimizeMainForm;
        private System.Windows.Forms.Button button2;
    }
}