namespace Twol
{
    partial class FormToolSteer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToolSteer));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGain = new System.Windows.Forms.TabPage();
            this.hsbarMinPWM_Tool = new System.Windows.Forms.HScrollBar();
            this.hsbarHighPWM_Tool = new System.Windows.Forms.HScrollBar();
            this.lblMinPWM_Tool = new System.Windows.Forms.Label();
            this.lblHighPWM_Tool = new System.Windows.Forms.Label();
            this.lblPGain_Tool = new System.Windows.Forms.Label();
            this.hsbarPGain_Tool = new System.Windows.Forms.HScrollBar();
            this.label89 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.tabSteer = new System.Windows.Forms.TabPage();
            this.lblAV_Set = new System.Windows.Forms.Label();
            this.lblAV_Act = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lblActualSteerAngleUpper = new System.Windows.Forms.Label();
            this.btnZeroWAS_Tool = new System.Windows.Forms.Button();
            this.label96 = new System.Windows.Forms.Label();
            this.hsbarZeroWAS_Tool = new System.Windows.Forms.HScrollBar();
            this.lblMaxSteerAngle_Tool = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.lblAckermann_Tool = new System.Windows.Forms.Label();
            this.hsbarCPD_Tool = new System.Windows.Forms.HScrollBar();
            this.lblCPD_Tool = new System.Windows.Forms.Label();
            this.lblZeroWAS_Tool = new System.Windows.Forms.Label();
            this.hsbarMaxSteerAngle_Tool = new System.Windows.Forms.HScrollBar();
            this.label98 = new System.Windows.Forms.Label();
            this.hsbarAckermann_Tool = new System.Windows.Forms.HScrollBar();
            this.label99 = new System.Windows.Forms.Label();
            this.tabPP = new System.Windows.Forms.TabPage();
            this.label82 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblIntegral_Tool = new System.Windows.Forms.Label();
            this.hsbarIntegral_Tool = new System.Windows.Forms.HScrollBar();
            this.label27 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.hsbarAcquireFactor = new System.Windows.Forms.HScrollBar();
            this.lblAcquireFactor = new System.Windows.Forms.Label();
            this.hsbarLookAheadMult = new System.Windows.Forms.HScrollBar();
            this.label19 = new System.Windows.Forms.Label();
            this.lblLookAheadMult = new System.Windows.Forms.Label();
            this.tabPPAdv = new System.Windows.Forms.TabPage();
            this.label51 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.nudDeadZoneDelay = new Twol.NudlessNumericUpDown();
            this.nudDeadZoneHeading = new Twol.NudlessNumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPWMDisplay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExpand = new Twol.RepeatButton();
            this.tabToolSetup = new System.Windows.Forms.TabControl();
            this.tabMode = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxIsRecordToolLine = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxIsFollowPivot = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxIsFollowCurrent = new System.Windows.Forms.CheckBox();
            this.cboxIsPassiveSteering = new System.Windows.Forms.CheckBox();
            this.tabPassive = new System.Windows.Forms.TabPage();
            this.lblPassiveIntegralGain = new System.Windows.Forms.Label();
            this.hsbarPassiveIntegralGain = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurvatureGain = new System.Windows.Forms.Label();
            this.hsbarPassiveCurvature = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tabActive = new System.Windows.Forms.TabPage();
            this.cboxIsSteerNotSlide_Tool = new System.Windows.Forms.CheckBox();
            this.label74 = new System.Windows.Forms.Label();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.nudAntennaHeight_Tool = new Twol.NudlessNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxInvertWAS_Tool = new System.Windows.Forms.CheckBox();
            this.cboxInvertSteer_Tool = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.nudAntennaOffset_Tool = new Twol.NudlessNumericUpDown();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabGain.SuspendLayout();
            this.tabSteer.SuspendLayout();
            this.tabPP.SuspendLayout();
            this.tabPPAdv.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabToolSetup.SuspendLayout();
            this.tabMode.SuspendLayout();
            this.tabPassive.SuspendLayout();
            this.tabActive.SuspendLayout();
            this.tabSetup.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(373, 434);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 347;
            // 
            // tabGain
            // 
            this.tabGain.AutoScroll = true;
            this.tabGain.BackColor = System.Drawing.Color.LightGray;
            this.tabGain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabGain.Controls.Add(this.hsbarMinPWM_Tool);
            this.tabGain.Controls.Add(this.hsbarHighPWM_Tool);
            this.tabGain.Controls.Add(this.lblMinPWM_Tool);
            this.tabGain.Controls.Add(this.lblHighPWM_Tool);
            this.tabGain.Controls.Add(this.lblPGain_Tool);
            this.tabGain.Controls.Add(this.hsbarPGain_Tool);
            this.tabGain.Controls.Add(this.label89);
            this.tabGain.Controls.Add(this.label88);
            this.tabGain.Controls.Add(this.label87);
            this.tabGain.ImageIndex = 1;
            this.tabGain.Location = new System.Drawing.Point(4, 56);
            this.tabGain.Name = "tabGain";
            this.tabGain.Size = new System.Drawing.Size(365, 374);
            this.tabGain.TabIndex = 13;
            // 
            // hsbarMinPWM_Tool
            // 
            this.hsbarMinPWM_Tool.LargeChange = 1;
            this.hsbarMinPWM_Tool.Location = new System.Drawing.Point(67, 305);
            this.hsbarMinPWM_Tool.Maximum = 200;
            this.hsbarMinPWM_Tool.Name = "hsbarMinPWM_Tool";
            this.hsbarMinPWM_Tool.Size = new System.Drawing.Size(292, 41);
            this.hsbarMinPWM_Tool.TabIndex = 557;
            this.hsbarMinPWM_Tool.Value = 10;
            this.hsbarMinPWM_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarMinPWM_Tool_Scroll);
            // 
            // hsbarHighPWM_Tool
            // 
            this.hsbarHighPWM_Tool.LargeChange = 2;
            this.hsbarHighPWM_Tool.Location = new System.Drawing.Point(67, 178);
            this.hsbarHighPWM_Tool.Maximum = 255;
            this.hsbarHighPWM_Tool.Name = "hsbarHighPWM_Tool";
            this.hsbarHighPWM_Tool.Size = new System.Drawing.Size(292, 41);
            this.hsbarHighPWM_Tool.TabIndex = 555;
            this.hsbarHighPWM_Tool.Value = 50;
            this.hsbarHighPWM_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarHighPWM_Tool_Scroll);
            // 
            // lblMinPWM_Tool
            // 
            this.lblMinPWM_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblMinPWM_Tool.Location = new System.Drawing.Point(7, 307);
            this.lblMinPWM_Tool.Name = "lblMinPWM_Tool";
            this.lblMinPWM_Tool.Size = new System.Drawing.Size(61, 35);
            this.lblMinPWM_Tool.TabIndex = 558;
            this.lblMinPWM_Tool.Text = "888";
            this.lblMinPWM_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHighPWM_Tool
            // 
            this.lblHighPWM_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighPWM_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblHighPWM_Tool.Location = new System.Drawing.Point(7, 181);
            this.lblHighPWM_Tool.Name = "lblHighPWM_Tool";
            this.lblHighPWM_Tool.Size = new System.Drawing.Size(61, 35);
            this.lblHighPWM_Tool.TabIndex = 556;
            this.lblHighPWM_Tool.Text = "888";
            this.lblHighPWM_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPGain_Tool
            // 
            this.lblPGain_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPGain_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblPGain_Tool.Location = new System.Drawing.Point(7, 53);
            this.lblPGain_Tool.Name = "lblPGain_Tool";
            this.lblPGain_Tool.Size = new System.Drawing.Size(61, 35);
            this.lblPGain_Tool.TabIndex = 554;
            this.lblPGain_Tool.Text = "888";
            this.lblPGain_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarPGain_Tool
            // 
            this.hsbarPGain_Tool.LargeChange = 1;
            this.hsbarPGain_Tool.Location = new System.Drawing.Point(67, 52);
            this.hsbarPGain_Tool.Maximum = 200;
            this.hsbarPGain_Tool.Minimum = 1;
            this.hsbarPGain_Tool.Name = "hsbarPGain_Tool";
            this.hsbarPGain_Tool.Size = new System.Drawing.Size(292, 40);
            this.hsbarPGain_Tool.TabIndex = 553;
            this.hsbarPGain_Tool.Value = 4;
            this.hsbarPGain_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarPGain_Tool_Scroll);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.Black;
            this.label89.Location = new System.Drawing.Point(82, 24);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(262, 24);
            this.label89.TabIndex = 559;
            this.label89.Text = "Proportional Gain";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.Black;
            this.label88.Location = new System.Drawing.Point(82, 150);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(262, 24);
            this.label88.TabIndex = 560;
            this.label88.Text = "Maximum PWM Limit";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(82, 278);
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
            this.tabSteer.Controls.Add(this.btnZeroWAS_Tool);
            this.tabSteer.Controls.Add(this.label96);
            this.tabSteer.Controls.Add(this.hsbarZeroWAS_Tool);
            this.tabSteer.Controls.Add(this.lblMaxSteerAngle_Tool);
            this.tabSteer.Controls.Add(this.label101);
            this.tabSteer.Controls.Add(this.lblAckermann_Tool);
            this.tabSteer.Controls.Add(this.hsbarCPD_Tool);
            this.tabSteer.Controls.Add(this.lblCPD_Tool);
            this.tabSteer.Controls.Add(this.lblZeroWAS_Tool);
            this.tabSteer.Controls.Add(this.hsbarMaxSteerAngle_Tool);
            this.tabSteer.Controls.Add(this.label98);
            this.tabSteer.Controls.Add(this.hsbarAckermann_Tool);
            this.tabSteer.Controls.Add(this.label99);
            this.tabSteer.ImageIndex = 4;
            this.tabSteer.Location = new System.Drawing.Point(4, 56);
            this.tabSteer.Name = "tabSteer";
            this.tabSteer.Size = new System.Drawing.Size(365, 374);
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
            // btnZeroWAS_Tool
            // 
            this.btnZeroWAS_Tool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZeroWAS_Tool.FlatAppearance.BorderSize = 0;
            this.btnZeroWAS_Tool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroWAS_Tool.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroWAS_Tool.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZeroWAS_Tool.Image = global::Twol.Properties.Resources.SteerZero;
            this.btnZeroWAS_Tool.Location = new System.Drawing.Point(31, 10);
            this.btnZeroWAS_Tool.Name = "btnZeroWAS_Tool";
            this.btnZeroWAS_Tool.Size = new System.Drawing.Size(98, 30);
            this.btnZeroWAS_Tool.TabIndex = 572;
            this.btnZeroWAS_Tool.UseVisualStyleBackColor = true;
            this.btnZeroWAS_Tool.Click += new System.EventHandler(this.btnZeroWAS_Tool_Click);
            // 
            // label96
            // 
            this.label96.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.Black;
            this.label96.Location = new System.Drawing.Point(116, 299);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(200, 24);
            this.label96.TabIndex = 577;
            this.label96.Text = "Max Steer Angle";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarZeroWAS_Tool
            // 
            this.hsbarZeroWAS_Tool.LargeChange = 20;
            this.hsbarZeroWAS_Tool.Location = new System.Drawing.Point(76, 70);
            this.hsbarZeroWAS_Tool.Maximum = 4000;
            this.hsbarZeroWAS_Tool.Minimum = -4000;
            this.hsbarZeroWAS_Tool.Name = "hsbarZeroWAS_Tool";
            this.hsbarZeroWAS_Tool.Size = new System.Drawing.Size(281, 30);
            this.hsbarZeroWAS_Tool.SmallChange = 2;
            this.hsbarZeroWAS_Tool.TabIndex = 565;
            this.hsbarZeroWAS_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarZeroWAS_Tool_Scroll);
            // 
            // lblMaxSteerAngle_Tool
            // 
            this.lblMaxSteerAngle_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSteerAngle_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblMaxSteerAngle_Tool.Location = new System.Drawing.Point(19, 322);
            this.lblMaxSteerAngle_Tool.Name = "lblMaxSteerAngle_Tool";
            this.lblMaxSteerAngle_Tool.Size = new System.Drawing.Size(52, 35);
            this.lblMaxSteerAngle_Tool.TabIndex = 569;
            this.lblMaxSteerAngle_Tool.Text = "888";
            this.lblMaxSteerAngle_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label101
            // 
            this.label101.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.Black;
            this.label101.Location = new System.Drawing.Point(116, 42);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(200, 24);
            this.label101.TabIndex = 566;
            this.label101.Text = "WAS Zero";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAckermann_Tool
            // 
            this.lblAckermann_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckermann_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblAckermann_Tool.Location = new System.Drawing.Point(19, 237);
            this.lblAckermann_Tool.Name = "lblAckermann_Tool";
            this.lblAckermann_Tool.Size = new System.Drawing.Size(52, 35);
            this.lblAckermann_Tool.TabIndex = 574;
            this.lblAckermann_Tool.Text = "888";
            this.lblAckermann_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarCPD_Tool
            // 
            this.hsbarCPD_Tool.LargeChange = 1;
            this.hsbarCPD_Tool.Location = new System.Drawing.Point(76, 155);
            this.hsbarCPD_Tool.Maximum = 255;
            this.hsbarCPD_Tool.Minimum = 1;
            this.hsbarCPD_Tool.Name = "hsbarCPD_Tool";
            this.hsbarCPD_Tool.Size = new System.Drawing.Size(281, 30);
            this.hsbarCPD_Tool.TabIndex = 570;
            this.hsbarCPD_Tool.Value = 20;
            this.hsbarCPD_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarCPD_Tool_Scroll);
            // 
            // lblCPD_Tool
            // 
            this.lblCPD_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPD_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblCPD_Tool.Location = new System.Drawing.Point(19, 152);
            this.lblCPD_Tool.Name = "lblCPD_Tool";
            this.lblCPD_Tool.Size = new System.Drawing.Size(52, 35);
            this.lblCPD_Tool.TabIndex = 571;
            this.lblCPD_Tool.Text = "888";
            this.lblCPD_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblZeroWAS_Tool
            // 
            this.lblZeroWAS_Tool.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroWAS_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblZeroWAS_Tool.Location = new System.Drawing.Point(6, 70);
            this.lblZeroWAS_Tool.Name = "lblZeroWAS_Tool";
            this.lblZeroWAS_Tool.Size = new System.Drawing.Size(70, 35);
            this.lblZeroWAS_Tool.TabIndex = 567;
            this.lblZeroWAS_Tool.Text = "-55.88";
            this.lblZeroWAS_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarMaxSteerAngle_Tool
            // 
            this.hsbarMaxSteerAngle_Tool.LargeChange = 1;
            this.hsbarMaxSteerAngle_Tool.Location = new System.Drawing.Point(76, 325);
            this.hsbarMaxSteerAngle_Tool.Maximum = 80;
            this.hsbarMaxSteerAngle_Tool.Minimum = 10;
            this.hsbarMaxSteerAngle_Tool.Name = "hsbarMaxSteerAngle_Tool";
            this.hsbarMaxSteerAngle_Tool.Size = new System.Drawing.Size(281, 30);
            this.hsbarMaxSteerAngle_Tool.TabIndex = 568;
            this.hsbarMaxSteerAngle_Tool.Value = 10;
            this.hsbarMaxSteerAngle_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarMaxSteerAngle_Tool_Scroll);
            // 
            // label98
            // 
            this.label98.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.Color.Black;
            this.label98.Location = new System.Drawing.Point(116, 212);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(200, 24);
            this.label98.TabIndex = 576;
            this.label98.Text = "Ackermann";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarAckermann_Tool
            // 
            this.hsbarAckermann_Tool.LargeChange = 1;
            this.hsbarAckermann_Tool.Location = new System.Drawing.Point(76, 240);
            this.hsbarAckermann_Tool.Maximum = 200;
            this.hsbarAckermann_Tool.Minimum = 1;
            this.hsbarAckermann_Tool.Name = "hsbarAckermann_Tool";
            this.hsbarAckermann_Tool.Size = new System.Drawing.Size(281, 30);
            this.hsbarAckermann_Tool.TabIndex = 573;
            this.hsbarAckermann_Tool.Value = 100;
            this.hsbarAckermann_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarAckermann_Tool_Scroll);
            // 
            // label99
            // 
            this.label99.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.Color.Black;
            this.label99.Location = new System.Drawing.Point(116, 127);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(200, 24);
            this.label99.TabIndex = 575;
            this.label99.Text = "Counts per Degree";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPP
            // 
            this.tabPP.BackColor = System.Drawing.Color.LightGray;
            this.tabPP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPP.Controls.Add(this.label82);
            this.tabPP.Controls.Add(this.label21);
            this.tabPP.Controls.Add(this.lblIntegral_Tool);
            this.tabPP.Controls.Add(this.hsbarIntegral_Tool);
            this.tabPP.Controls.Add(this.label27);
            this.tabPP.Controls.Add(this.label18);
            this.tabPP.Controls.Add(this.hsbarAcquireFactor);
            this.tabPP.Controls.Add(this.lblAcquireFactor);
            this.tabPP.Controls.Add(this.hsbarLookAheadMult);
            this.tabPP.Controls.Add(this.label19);
            this.tabPP.Controls.Add(this.lblLookAheadMult);
            this.tabPP.ForeColor = System.Drawing.Color.Black;
            this.tabPP.ImageIndex = 0;
            this.tabPP.Location = new System.Drawing.Point(4, 56);
            this.tabPP.Name = "tabPP";
            this.tabPP.Size = new System.Drawing.Size(365, 374);
            this.tabPP.TabIndex = 16;
            // 
            // label82
            // 
            this.label82.Enabled = false;
            this.label82.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.Location = new System.Drawing.Point(78, 129);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(273, 26);
            this.label82.TabIndex = 548;
            this.label82.Text = "Acquire Factor";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(100, 322);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(238, 46);
            this.label21.TabIndex = 361;
            this.label21.Text = "It will slowly increase steer angle to reduce cross track error";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIntegral_Tool
            // 
            this.lblIntegral_Tool.Enabled = false;
            this.lblIntegral_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntegral_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblIntegral_Tool.Location = new System.Drawing.Point(3, 278);
            this.lblIntegral_Tool.Name = "lblIntegral_Tool";
            this.lblIntegral_Tool.Size = new System.Drawing.Size(60, 35);
            this.lblIntegral_Tool.TabIndex = 352;
            this.lblIntegral_Tool.Text = "888";
            this.lblIntegral_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarIntegral_Tool
            // 
            this.hsbarIntegral_Tool.Enabled = false;
            this.hsbarIntegral_Tool.LargeChange = 1;
            this.hsbarIntegral_Tool.Location = new System.Drawing.Point(68, 276);
            this.hsbarIntegral_Tool.Name = "hsbarIntegral_Tool";
            this.hsbarIntegral_Tool.Size = new System.Drawing.Size(292, 40);
            this.hsbarIntegral_Tool.TabIndex = 351;
            this.hsbarIntegral_Tool.Value = 5;
            this.hsbarIntegral_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarIntegral_Tool_Scroll);
            // 
            // label27
            // 
            this.label27.Enabled = false;
            this.label27.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(78, 247);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(273, 26);
            this.label27.TabIndex = 350;
            this.label27.Text = "Integral";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label27.UseCompatibleTextRendering = true;
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
            // hsbarAcquireFactor
            // 
            this.hsbarAcquireFactor.Enabled = false;
            this.hsbarAcquireFactor.LargeChange = 1;
            this.hsbarAcquireFactor.Location = new System.Drawing.Point(68, 159);
            this.hsbarAcquireFactor.Maximum = 300;
            this.hsbarAcquireFactor.Minimum = 20;
            this.hsbarAcquireFactor.Name = "hsbarAcquireFactor";
            this.hsbarAcquireFactor.Size = new System.Drawing.Size(292, 40);
            this.hsbarAcquireFactor.TabIndex = 508;
            this.hsbarAcquireFactor.Value = 75;
            this.hsbarAcquireFactor.ValueChanged += new System.EventHandler(this.hsbarAcquireFactor_ValueChanged);
            // 
            // lblAcquireFactor
            // 
            this.lblAcquireFactor.Enabled = false;
            this.lblAcquireFactor.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcquireFactor.ForeColor = System.Drawing.Color.Black;
            this.lblAcquireFactor.Location = new System.Drawing.Point(3, 161);
            this.lblAcquireFactor.Name = "lblAcquireFactor";
            this.lblAcquireFactor.Size = new System.Drawing.Size(60, 35);
            this.lblAcquireFactor.TabIndex = 509;
            this.lblAcquireFactor.Text = "888";
            this.lblAcquireFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarLookAheadMult
            // 
            this.hsbarLookAheadMult.Enabled = false;
            this.hsbarLookAheadMult.LargeChange = 1;
            this.hsbarLookAheadMult.Location = new System.Drawing.Point(68, 42);
            this.hsbarLookAheadMult.Maximum = 60;
            this.hsbarLookAheadMult.Minimum = 5;
            this.hsbarLookAheadMult.Name = "hsbarLookAheadMult";
            this.hsbarLookAheadMult.Size = new System.Drawing.Size(292, 40);
            this.hsbarLookAheadMult.TabIndex = 298;
            this.hsbarLookAheadMult.Value = 6;
            // 
            // label19
            // 
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(78, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(273, 26);
            this.label19.TabIndex = 301;
            this.label19.Text = "Speed Factor";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLookAheadMult
            // 
            this.lblLookAheadMult.Enabled = false;
            this.lblLookAheadMult.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAheadMult.ForeColor = System.Drawing.Color.Black;
            this.lblLookAheadMult.Location = new System.Drawing.Point(3, 44);
            this.lblLookAheadMult.Name = "lblLookAheadMult";
            this.lblLookAheadMult.Size = new System.Drawing.Size(60, 35);
            this.lblLookAheadMult.TabIndex = 299;
            this.lblLookAheadMult.Text = "888";
            this.lblLookAheadMult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPPAdv
            // 
            this.tabPPAdv.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPPAdv.Controls.Add(this.label51);
            this.tabPPAdv.Controls.Add(this.label54);
            this.tabPPAdv.Controls.Add(this.label49);
            this.tabPPAdv.Controls.Add(this.nudDeadZoneDelay);
            this.tabPPAdv.Controls.Add(this.nudDeadZoneHeading);
            this.tabPPAdv.ImageIndex = 2;
            this.tabPPAdv.Location = new System.Drawing.Point(4, 56);
            this.tabPPAdv.Name = "tabPPAdv";
            this.tabPPAdv.Padding = new System.Windows.Forms.Padding(3);
            this.tabPPAdv.Size = new System.Drawing.Size(365, 374);
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
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(195, 112);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(165, 46);
            this.label54.TabIndex = 543;
            this.label54.Text = "On Delay (sec)";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // nudDeadZoneDelay
            // 
            this.nudDeadZoneDelay.Location = new System.Drawing.Point(224, 70);
            this.nudDeadZoneDelay.Maximum = 10D;
            this.nudDeadZoneDelay.Minimum = 1D;
            this.nudDeadZoneDelay.Name = "nudDeadZoneDelay";
            this.nudDeadZoneDelay.Size = new System.Drawing.Size(107, 36);
            this.nudDeadZoneDelay.TabIndex = 542;
            this.nudDeadZoneDelay.ValueChanged += new System.EventHandler(this.nudDeadZoneDelay_ValueChanged);
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
            this.panel2.Controls.Add(this.lblPWMDisplay);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnExpand);
            this.panel2.Location = new System.Drawing.Point(4, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 59);
            this.panel2.TabIndex = 324;
            // 
            // lblPWMDisplay
            // 
            this.lblPWMDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lblPWMDisplay.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWMDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPWMDisplay.Location = new System.Drawing.Point(64, 11);
            this.lblPWMDisplay.Name = "lblPWMDisplay";
            this.lblPWMDisplay.Size = new System.Drawing.Size(182, 37);
            this.lblPWMDisplay.TabIndex = 330;
            this.lblPWMDisplay.Text = "255";
            this.lblPWMDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(9, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 23);
            this.label9.TabIndex = 331;
            this.label9.Text = "PWM:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExpand
            // 
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpand.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpand.Image = global::Twol.Properties.Resources.ArrowRight;
            this.btnExpand.Location = new System.Drawing.Point(251, 10);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(110, 37);
            this.btnExpand.TabIndex = 329;
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.expandWindow_Click);
            // 
            // tabToolSetup
            // 
            this.tabToolSetup.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabToolSetup.Controls.Add(this.tabMode);
            this.tabToolSetup.Controls.Add(this.tabPassive);
            this.tabToolSetup.Controls.Add(this.tabActive);
            this.tabToolSetup.Controls.Add(this.tabSetup);
            this.tabToolSetup.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabToolSetup.ImageList = this.imageList2;
            this.tabToolSetup.ItemSize = new System.Drawing.Size(160, 54);
            this.tabToolSetup.Location = new System.Drawing.Point(373, 5);
            this.tabToolSetup.Name = "tabToolSetup";
            this.tabToolSetup.SelectedIndex = 0;
            this.tabToolSetup.Size = new System.Drawing.Size(672, 502);
            this.tabToolSetup.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabToolSetup.TabIndex = 528;
            // 
            // tabMode
            // 
            this.tabMode.Controls.Add(this.label5);
            this.tabMode.Controls.Add(this.cboxIsRecordToolLine);
            this.tabMode.Controls.Add(this.label4);
            this.tabMode.Controls.Add(this.cboxIsFollowPivot);
            this.tabMode.Controls.Add(this.label1);
            this.tabMode.Controls.Add(this.cboxIsFollowCurrent);
            this.tabMode.Controls.Add(this.cboxIsPassiveSteering);
            this.tabMode.Location = new System.Drawing.Point(4, 58);
            this.tabMode.Name = "tabMode";
            this.tabMode.Size = new System.Drawing.Size(664, 440);
            this.tabMode.TabIndex = 6;
            this.tabMode.Text = "Mode";
            this.tabMode.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(55, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 24);
            this.label5.TabIndex = 593;
            this.label5.Text = "Record Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsRecordToolLine
            // 
            this.cboxIsRecordToolLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsRecordToolLine.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsRecordToolLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsRecordToolLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsRecordToolLine.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsRecordToolLine.ForeColor = System.Drawing.Color.Black;
            this.cboxIsRecordToolLine.Location = new System.Drawing.Point(78, 274);
            this.cboxIsRecordToolLine.Name = "cboxIsRecordToolLine";
            this.cboxIsRecordToolLine.Size = new System.Drawing.Size(217, 70);
            this.cboxIsRecordToolLine.TabIndex = 592;
            this.cboxIsRecordToolLine.Text = "Record Tool Line";
            this.cboxIsRecordToolLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsRecordToolLine.UseVisualStyleBackColor = false;
            this.cboxIsRecordToolLine.Click += new System.EventHandler(this.cboxIsRecordToolLine_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(55, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 24);
            this.label4.TabIndex = 591;
            this.label4.Text = "Passive Modes";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsFollowPivot
            // 
            this.cboxIsFollowPivot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsFollowPivot.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsFollowPivot.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsFollowPivot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsFollowPivot.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsFollowPivot.ForeColor = System.Drawing.Color.Black;
            this.cboxIsFollowPivot.Location = new System.Drawing.Point(398, 162);
            this.cboxIsFollowPivot.Name = "cboxIsFollowPivot";
            this.cboxIsFollowPivot.Size = new System.Drawing.Size(217, 70);
            this.cboxIsFollowPivot.TabIndex = 587;
            this.cboxIsFollowPivot.Text = "Vehicle Pivot";
            this.cboxIsFollowPivot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsFollowPivot.UseVisualStyleBackColor = false;
            this.cboxIsFollowPivot.Click += new System.EventHandler(this.cboxIsFollowPivot_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(362, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 590;
            this.label1.Text = "Active Modes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsFollowCurrent
            // 
            this.cboxIsFollowCurrent.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsFollowCurrent.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsFollowCurrent.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsFollowCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsFollowCurrent.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsFollowCurrent.ForeColor = System.Drawing.Color.Black;
            this.cboxIsFollowCurrent.Location = new System.Drawing.Point(398, 61);
            this.cboxIsFollowCurrent.Name = "cboxIsFollowCurrent";
            this.cboxIsFollowCurrent.Size = new System.Drawing.Size(217, 70);
            this.cboxIsFollowCurrent.TabIndex = 585;
            this.cboxIsFollowCurrent.Text = "Current Line";
            this.cboxIsFollowCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsFollowCurrent.UseVisualStyleBackColor = false;
            this.cboxIsFollowCurrent.Click += new System.EventHandler(this.cboxIsFollowCurrent_Click);
            // 
            // cboxIsPassiveSteering
            // 
            this.cboxIsPassiveSteering.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsPassiveSteering.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsPassiveSteering.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsPassiveSteering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsPassiveSteering.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsPassiveSteering.ForeColor = System.Drawing.Color.Black;
            this.cboxIsPassiveSteering.Location = new System.Drawing.Point(78, 61);
            this.cboxIsPassiveSteering.Name = "cboxIsPassiveSteering";
            this.cboxIsPassiveSteering.Size = new System.Drawing.Size(217, 70);
            this.cboxIsPassiveSteering.TabIndex = 587;
            this.cboxIsPassiveSteering.Text = "Curvature PID";
            this.cboxIsPassiveSteering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsPassiveSteering.UseVisualStyleBackColor = false;
            this.cboxIsPassiveSteering.Click += new System.EventHandler(this.cboxIsPassiveSteering_Click);
            // 
            // tabPassive
            // 
            this.tabPassive.BackColor = System.Drawing.Color.LightGray;
            this.tabPassive.Controls.Add(this.lblPassiveIntegralGain);
            this.tabPassive.Controls.Add(this.hsbarPassiveIntegralGain);
            this.tabPassive.Controls.Add(this.label7);
            this.tabPassive.Controls.Add(this.lblCurvatureGain);
            this.tabPassive.Controls.Add(this.hsbarPassiveCurvature);
            this.tabPassive.Controls.Add(this.label6);
            this.tabPassive.Location = new System.Drawing.Point(4, 58);
            this.tabPassive.Name = "tabPassive";
            this.tabPassive.Size = new System.Drawing.Size(664, 440);
            this.tabPassive.TabIndex = 5;
            this.tabPassive.Text = "Passive";
            this.tabPassive.Enter += new System.EventHandler(this.tabPassive_Enter);
            // 
            // lblPassiveIntegralGain
            // 
            this.lblPassiveIntegralGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassiveIntegralGain.ForeColor = System.Drawing.Color.Black;
            this.lblPassiveIntegralGain.Location = new System.Drawing.Point(215, 181);
            this.lblPassiveIntegralGain.Name = "lblPassiveIntegralGain";
            this.lblPassiveIntegralGain.Size = new System.Drawing.Size(93, 35);
            this.lblPassiveIntegralGain.TabIndex = 564;
            this.lblPassiveIntegralGain.Text = "888";
            this.lblPassiveIntegralGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarPassiveIntegralGain
            // 
            this.hsbarPassiveIntegralGain.LargeChange = 1;
            this.hsbarPassiveIntegralGain.Location = new System.Drawing.Point(311, 180);
            this.hsbarPassiveIntegralGain.Maximum = 10;
            this.hsbarPassiveIntegralGain.Minimum = 1;
            this.hsbarPassiveIntegralGain.Name = "hsbarPassiveIntegralGain";
            this.hsbarPassiveIntegralGain.Size = new System.Drawing.Size(325, 40);
            this.hsbarPassiveIntegralGain.TabIndex = 563;
            this.hsbarPassiveIntegralGain.Value = 4;
            this.hsbarPassiveIntegralGain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarPassiveIntegralGain_Scroll);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(342, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 24);
            this.label7.TabIndex = 565;
            this.label7.Text = "Integral  Gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurvatureGain
            // 
            this.lblCurvatureGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurvatureGain.ForeColor = System.Drawing.Color.Black;
            this.lblCurvatureGain.Location = new System.Drawing.Point(247, 69);
            this.lblCurvatureGain.Name = "lblCurvatureGain";
            this.lblCurvatureGain.Size = new System.Drawing.Size(61, 35);
            this.lblCurvatureGain.TabIndex = 561;
            this.lblCurvatureGain.Text = "888";
            this.lblCurvatureGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarPassiveCurvature
            // 
            this.hsbarPassiveCurvature.LargeChange = 1;
            this.hsbarPassiveCurvature.Location = new System.Drawing.Point(311, 68);
            this.hsbarPassiveCurvature.Maximum = 200;
            this.hsbarPassiveCurvature.Name = "hsbarPassiveCurvature";
            this.hsbarPassiveCurvature.Size = new System.Drawing.Size(325, 40);
            this.hsbarPassiveCurvature.TabIndex = 560;
            this.hsbarPassiveCurvature.Value = 4;
            this.hsbarPassiveCurvature.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarPassiveCurvature_Scroll);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(342, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 24);
            this.label6.TabIndex = 562;
            this.label6.Text = "Curvature Gain";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabActive
            // 
            this.tabActive.Controls.Add(this.cboxIsSteerNotSlide_Tool);
            this.tabActive.Controls.Add(this.label74);
            this.tabActive.Location = new System.Drawing.Point(4, 58);
            this.tabActive.Name = "tabActive";
            this.tabActive.Size = new System.Drawing.Size(664, 440);
            this.tabActive.TabIndex = 7;
            this.tabActive.Text = "Active";
            this.tabActive.UseVisualStyleBackColor = true;
            // 
            // cboxIsSteerNotSlide_Tool
            // 
            this.cboxIsSteerNotSlide_Tool.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsSteerNotSlide_Tool.BackColor = System.Drawing.Color.White;
            this.cboxIsSteerNotSlide_Tool.BackgroundImage = global::Twol.Properties.Resources.ConS_ModulesSteer;
            this.cboxIsSteerNotSlide_Tool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cboxIsSteerNotSlide_Tool.Checked = true;
            this.cboxIsSteerNotSlide_Tool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsSteerNotSlide_Tool.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxIsSteerNotSlide_Tool.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxIsSteerNotSlide_Tool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsSteerNotSlide_Tool.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsSteerNotSlide_Tool.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxIsSteerNotSlide_Tool.Location = new System.Drawing.Point(101, 105);
            this.cboxIsSteerNotSlide_Tool.Name = "cboxIsSteerNotSlide_Tool";
            this.cboxIsSteerNotSlide_Tool.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsSteerNotSlide_Tool.Size = new System.Drawing.Size(122, 78);
            this.cboxIsSteerNotSlide_Tool.TabIndex = 578;
            this.cboxIsSteerNotSlide_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSteerNotSlide_Tool.UseVisualStyleBackColor = false;
            this.cboxIsSteerNotSlide_Tool.Click += new System.EventHandler(this.cboxIsSteerNotSlide_Click);
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(82, 61);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(158, 41);
            this.label74.TabIndex = 579;
            this.label74.Text = "Steering\r\nNot Sliding";
            this.label74.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tabSetup
            // 
            this.tabSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.tabSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSetup.Controls.Add(this.nudAntennaHeight_Tool);
            this.tabSetup.Controls.Add(this.label2);
            this.tabSetup.Controls.Add(this.cboxInvertWAS_Tool);
            this.tabSetup.Controls.Add(this.cboxInvertSteer_Tool);
            this.tabSetup.Controls.Add(this.label3);
            this.tabSetup.Controls.Add(this.label31);
            this.tabSetup.Controls.Add(this.label83);
            this.tabSetup.Controls.Add(this.nudAntennaOffset_Tool);
            this.tabSetup.ImageIndex = 1;
            this.tabSetup.Location = new System.Drawing.Point(4, 58);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(664, 440);
            this.tabSetup.TabIndex = 4;
            // 
            // nudAntennaHeight_Tool
            // 
            this.nudAntennaHeight_Tool.Location = new System.Drawing.Point(49, 64);
            this.nudAntennaHeight_Tool.Maximum = 5D;
            this.nudAntennaHeight_Tool.Mode = Twol.UnitMode.Small;
            this.nudAntennaHeight_Tool.Name = "nudAntennaHeight_Tool";
            this.nudAntennaHeight_Tool.Size = new System.Drawing.Size(143, 56);
            this.nudAntennaHeight_Tool.TabIndex = 580;
            this.nudAntennaHeight_Tool.ValueChanged += new System.EventHandler(this.nudAntennaHeight_Tool_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 41);
            this.label2.TabIndex = 581;
            this.label2.Text = "Antenna Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxInvertWAS_Tool
            // 
            this.cboxInvertWAS_Tool.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxInvertWAS_Tool.BackColor = System.Drawing.Color.White;
            this.cboxInvertWAS_Tool.BackgroundImage = global::Twol.Properties.Resources.ConSt_InvertWAS;
            this.cboxInvertWAS_Tool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cboxInvertWAS_Tool.Checked = true;
            this.cboxInvertWAS_Tool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxInvertWAS_Tool.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxInvertWAS_Tool.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxInvertWAS_Tool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxInvertWAS_Tool.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxInvertWAS_Tool.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxInvertWAS_Tool.Location = new System.Drawing.Point(334, 66);
            this.cboxInvertWAS_Tool.Name = "cboxInvertWAS_Tool";
            this.cboxInvertWAS_Tool.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxInvertWAS_Tool.Size = new System.Drawing.Size(82, 78);
            this.cboxInvertWAS_Tool.TabIndex = 516;
            this.cboxInvertWAS_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxInvertWAS_Tool.UseVisualStyleBackColor = false;
            this.cboxInvertWAS_Tool.Click += new System.EventHandler(this.cboxInvertWAS_Tool_Click);
            // 
            // cboxInvertSteer_Tool
            // 
            this.cboxInvertSteer_Tool.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxInvertSteer_Tool.BackColor = System.Drawing.Color.White;
            this.cboxInvertSteer_Tool.BackgroundImage = global::Twol.Properties.Resources.ConSt_InvertDirection;
            this.cboxInvertSteer_Tool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cboxInvertSteer_Tool.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxInvertSteer_Tool.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine;
            this.cboxInvertSteer_Tool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxInvertSteer_Tool.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxInvertSteer_Tool.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboxInvertSteer_Tool.Location = new System.Drawing.Point(510, 64);
            this.cboxInvertSteer_Tool.Name = "cboxInvertSteer_Tool";
            this.cboxInvertSteer_Tool.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxInvertSteer_Tool.Size = new System.Drawing.Size(82, 78);
            this.cboxInvertSteer_Tool.TabIndex = 517;
            this.cboxInvertSteer_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxInvertSteer_Tool.UseVisualStyleBackColor = false;
            this.cboxInvertSteer_Tool.Click += new System.EventHandler(this.cboxInvertSteer_Tool_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 41);
            this.label3.TabIndex = 583;
            this.label3.Text = "Antenna Offset";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(295, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(158, 41);
            this.label31.TabIndex = 519;
            this.label31.Text = "Invert WAS";
            this.label31.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.Black;
            this.label83.Location = new System.Drawing.Point(473, 20);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(158, 41);
            this.label83.TabIndex = 518;
            this.label83.Text = "Invert \r\nMotor Dir";
            this.label83.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudAntennaOffset_Tool
            // 
            this.nudAntennaOffset_Tool.Location = new System.Drawing.Point(49, 180);
            this.nudAntennaOffset_Tool.Maximum = 5D;
            this.nudAntennaOffset_Tool.Minimum = -5D;
            this.nudAntennaOffset_Tool.Mode = Twol.UnitMode.Small;
            this.nudAntennaOffset_Tool.Name = "nudAntennaOffset_Tool";
            this.nudAntennaOffset_Tool.Size = new System.Drawing.Size(143, 56);
            this.nudAntennaOffset_Tool.TabIndex = 582;
            this.nudAntennaOffset_Tool.ValueChanged += new System.EventHandler(this.nudAntennaOffset_Tool_ValueChanged);
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
            // FormToolSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1046, 508);
            this.Controls.Add(this.tabToolSetup);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolSteer";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool Steer Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormSteer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGain.ResumeLayout(false);
            this.tabSteer.ResumeLayout(false);
            this.tabSteer.PerformLayout();
            this.tabPP.ResumeLayout(false);
            this.tabPPAdv.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabToolSetup.ResumeLayout(false);
            this.tabMode.ResumeLayout(false);
            this.tabPassive.ResumeLayout(false);
            this.tabActive.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.HScrollBar hsbarLookAheadMult;
        private System.Windows.Forms.Label lblLookAheadMult;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGain;
        private System.Windows.Forms.TabPage tabPP;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabSteer;
        private System.Windows.Forms.Label lblActualSteerAngleUpper;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.HScrollBar hsbarIntegral_Tool;
        private System.Windows.Forms.Label lblIntegral_Tool;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAV_Set;
        private System.Windows.Forms.Label lblAV_Act;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private RepeatButton btnExpand;
        private System.Windows.Forms.TabControl tabToolSetup;
        private System.Windows.Forms.Label label49;
        private NudlessNumericUpDown nudDeadZoneHeading;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label54;
        private NudlessNumericUpDown nudDeadZoneDelay;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lblAcquireFactor;
        private System.Windows.Forms.HScrollBar hsbarAcquireFactor;
        private System.Windows.Forms.TabPage tabPPAdv;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.HScrollBar hsbarMinPWM_Tool;
        private System.Windows.Forms.HScrollBar hsbarPGain_Tool;
        private System.Windows.Forms.Label lblPGain_Tool;
        private System.Windows.Forms.Label lblHighPWM_Tool;
        private System.Windows.Forms.Label lblMinPWM_Tool;
        private System.Windows.Forms.HScrollBar hsbarHighPWM_Tool;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.CheckBox cboxInvertWAS_Tool;
        private System.Windows.Forms.CheckBox cboxInvertSteer_Tool;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label lblMaxSteerAngle_Tool;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.HScrollBar hsbarAckermann_Tool;
        private System.Windows.Forms.HScrollBar hsbarMaxSteerAngle_Tool;
        private System.Windows.Forms.Label lblAckermann_Tool;
        private System.Windows.Forms.Button btnZeroWAS_Tool;
        private System.Windows.Forms.HScrollBar hsbarCPD_Tool;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label lblCPD_Tool;
        private System.Windows.Forms.HScrollBar hsbarZeroWAS_Tool;
        private System.Windows.Forms.Label lblZeroWAS_Tool;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.CheckBox cboxIsSteerNotSlide_Tool;
        private System.Windows.Forms.Label label2;
        private NudlessNumericUpDown nudAntennaHeight_Tool;
        private System.Windows.Forms.Label label3;
        private NudlessNumericUpDown nudAntennaOffset_Tool;
        private System.Windows.Forms.Label lblPWMDisplay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cboxIsFollowCurrent;
        private System.Windows.Forms.TabPage tabPassive;
        private System.Windows.Forms.Label lblCurvatureGain;
        private System.Windows.Forms.HScrollBar hsbarPassiveCurvature;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPassiveIntegralGain;
        private System.Windows.Forms.HScrollBar hsbarPassiveIntegralGain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabMode;
        private System.Windows.Forms.CheckBox cboxIsPassiveSteering;
        private System.Windows.Forms.CheckBox cboxIsFollowPivot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboxIsRecordToolLine;
    }
}