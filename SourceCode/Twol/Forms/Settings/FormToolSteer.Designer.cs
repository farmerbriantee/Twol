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
            this.lblIntegral_Tool = new System.Windows.Forms.Label();
            this.hsbarPGain_Tool = new System.Windows.Forms.HScrollBar();
            this.label89 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.hsbarIntegral_Tool = new System.Windows.Forms.HScrollBar();
            this.label27 = new System.Windows.Forms.Label();
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
            this.hsbarCPD_Tool = new System.Windows.Forms.HScrollBar();
            this.lblCPD_Tool = new System.Windows.Forms.Label();
            this.lblZeroWAS_Tool = new System.Windows.Forms.Label();
            this.hsbarMaxSteerAngle_Tool = new System.Windows.Forms.HScrollBar();
            this.label99 = new System.Windows.Forms.Label();
            this.tabDeadzone = new System.Windows.Forms.TabPage();
            this.hsbarPassiveIntegralGain = new System.Windows.Forms.HScrollBar();
            this.label51 = new System.Windows.Forms.Label();
            this.hsbarPassiveCurvature = new System.Windows.Forms.HScrollBar();
            this.label54 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPassiveIntegralGain = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurvatureGain = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblAckermann_Tool = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.hsbarAckermann_Tool = new System.Windows.Forms.HScrollBar();
            this.label82 = new System.Windows.Forms.Label();
            this.hsbarAcquireFactor = new System.Windows.Forms.HScrollBar();
            this.lblAcquireFactor = new System.Windows.Forms.Label();
            this.hsbarLookAheadMult = new System.Windows.Forms.HScrollBar();
            this.label19 = new System.Windows.Forms.Label();
            this.lblLookAheadMult = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPWMDisplay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabToolSetup = new System.Windows.Forms.TabControl();
            this.tabModes = new System.Windows.Forms.TabPage();
            this.cboxIsRecordToolLine = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxIsPassiveSteering = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxIsFollowCurrent = new System.Windows.Forms.CheckBox();
            this.cboxIsFollowPivot = new System.Windows.Forms.CheckBox();
            this.tabActive = new System.Windows.Forms.TabPage();
            this.cboxPassesPerReference = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxRecordSourceTool = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.lblManualPWM_Percent = new System.Windows.Forms.Label();
            this.cboxIsSteerNotSlide_Tool = new System.Windows.Forms.CheckBox();
            this.label74 = new System.Windows.Forms.Label();
            this.cboxInvertWAS_Tool = new System.Windows.Forms.CheckBox();
            this.cboxInvertSteer_Tool = new System.Windows.Forms.CheckBox();
            this.hsbarManualPWM_Percent = new System.Windows.Forms.HScrollBar();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblManualSecondsOn = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.hsbarManualSecondsOn = new System.Windows.Forms.HScrollBar();
            this.tabAntenna = new System.Windows.Forms.TabPage();
            this.lblInvertRoll = new System.Windows.Forms.Label();
            this.lblRollZeroOffset = new System.Windows.Forms.Label();
            this.lblZeroRoll = new System.Windows.Forms.Label();
            this.lblHeadingOffset = new System.Windows.Forms.Label();
            this.lblRemoveOffset = new System.Windows.Forms.Label();
            this.cboxDataInvertRoll = new System.Windows.Forms.CheckBox();
            this.btnZeroRoll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveZeroOffset = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.nudToolGuidanceSpacing = new Twol.NudlessNumericUpDown();
            this.nudNudge = new Twol.NudlessNumericUpDown();
            this.btnRollOffsetUp = new Twol.RepeatButton();
            this.btnRollOffsetDown = new Twol.RepeatButton();
            this.nudDualHeadingOffset = new Twol.NudlessNumericUpDown();
            this.nudAntennaHeight_Tool = new Twol.NudlessNumericUpDown();
            this.nudAntennaOffset_Tool = new Twol.NudlessNumericUpDown();
            this.btnExpand = new Twol.RepeatButton();
            this.nudDeadZoneDelay = new Twol.NudlessNumericUpDown();
            this.nudDeadzoneWidth = new Twol.NudlessNumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabGain.SuspendLayout();
            this.tabSteer.SuspendLayout();
            this.tabDeadzone.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabToolSetup.SuspendLayout();
            this.tabModes.SuspendLayout();
            this.tabActive.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabAntenna.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabDeadzone);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 48);
            this.tabControl1.Location = new System.Drawing.Point(2, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 443);
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
            this.tabGain.Controls.Add(this.lblIntegral_Tool);
            this.tabGain.Controls.Add(this.hsbarPGain_Tool);
            this.tabGain.Controls.Add(this.label89);
            this.tabGain.Controls.Add(this.label88);
            this.tabGain.Controls.Add(this.label87);
            this.tabGain.Controls.Add(this.hsbarIntegral_Tool);
            this.tabGain.Controls.Add(this.label27);
            this.tabGain.ImageIndex = 1;
            this.tabGain.Location = new System.Drawing.Point(4, 52);
            this.tabGain.Name = "tabGain";
            this.tabGain.Size = new System.Drawing.Size(365, 387);
            this.tabGain.TabIndex = 13;
            // 
            // hsbarMinPWM_Tool
            // 
            this.hsbarMinPWM_Tool.LargeChange = 1;
            this.hsbarMinPWM_Tool.Location = new System.Drawing.Point(57, 338);
            this.hsbarMinPWM_Tool.Maximum = 200;
            this.hsbarMinPWM_Tool.Name = "hsbarMinPWM_Tool";
            this.hsbarMinPWM_Tool.Size = new System.Drawing.Size(302, 40);
            this.hsbarMinPWM_Tool.TabIndex = 557;
            this.hsbarMinPWM_Tool.Value = 10;
            this.hsbarMinPWM_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarMinPWM_Tool_Scroll);
            // 
            // hsbarHighPWM_Tool
            // 
            this.hsbarHighPWM_Tool.LargeChange = 2;
            this.hsbarHighPWM_Tool.Location = new System.Drawing.Point(57, 238);
            this.hsbarHighPWM_Tool.Maximum = 255;
            this.hsbarHighPWM_Tool.Name = "hsbarHighPWM_Tool";
            this.hsbarHighPWM_Tool.Size = new System.Drawing.Size(302, 40);
            this.hsbarHighPWM_Tool.TabIndex = 555;
            this.hsbarHighPWM_Tool.Value = 50;
            this.hsbarHighPWM_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarHighPWM_Tool_Scroll);
            // 
            // lblMinPWM_Tool
            // 
            this.lblMinPWM_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPWM_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblMinPWM_Tool.Location = new System.Drawing.Point(4, 340);
            this.lblMinPWM_Tool.Name = "lblMinPWM_Tool";
            this.lblMinPWM_Tool.Size = new System.Drawing.Size(56, 35);
            this.lblMinPWM_Tool.TabIndex = 558;
            this.lblMinPWM_Tool.Text = "888";
            this.lblMinPWM_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHighPWM_Tool
            // 
            this.lblHighPWM_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighPWM_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblHighPWM_Tool.Location = new System.Drawing.Point(4, 239);
            this.lblHighPWM_Tool.Name = "lblHighPWM_Tool";
            this.lblHighPWM_Tool.Size = new System.Drawing.Size(56, 35);
            this.lblHighPWM_Tool.TabIndex = 556;
            this.lblHighPWM_Tool.Text = "888";
            this.lblHighPWM_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPGain_Tool
            // 
            this.lblPGain_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPGain_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblPGain_Tool.Location = new System.Drawing.Point(4, 37);
            this.lblPGain_Tool.Name = "lblPGain_Tool";
            this.lblPGain_Tool.Size = new System.Drawing.Size(56, 35);
            this.lblPGain_Tool.TabIndex = 554;
            this.lblPGain_Tool.Text = "888";
            this.lblPGain_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIntegral_Tool
            // 
            this.lblIntegral_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntegral_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblIntegral_Tool.Location = new System.Drawing.Point(4, 138);
            this.lblIntegral_Tool.Name = "lblIntegral_Tool";
            this.lblIntegral_Tool.Size = new System.Drawing.Size(56, 35);
            this.lblIntegral_Tool.TabIndex = 352;
            this.lblIntegral_Tool.Text = "888";
            this.lblIntegral_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsbarPGain_Tool
            // 
            this.hsbarPGain_Tool.LargeChange = 1;
            this.hsbarPGain_Tool.Location = new System.Drawing.Point(57, 36);
            this.hsbarPGain_Tool.Maximum = 255;
            this.hsbarPGain_Tool.Minimum = 1;
            this.hsbarPGain_Tool.Name = "hsbarPGain_Tool";
            this.hsbarPGain_Tool.Size = new System.Drawing.Size(302, 40);
            this.hsbarPGain_Tool.TabIndex = 553;
            this.hsbarPGain_Tool.Value = 4;
            this.hsbarPGain_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarPGain_Tool_Scroll);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.Black;
            this.label89.Location = new System.Drawing.Point(82, 8);
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
            this.label88.Location = new System.Drawing.Point(82, 210);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(262, 24);
            this.label88.TabIndex = 560;
            this.label88.Text = "Maximum PWM";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(82, 310);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(262, 24);
            this.label87.TabIndex = 561;
            this.label87.Text = "Minimum PWM to Move";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarIntegral_Tool
            // 
            this.hsbarIntegral_Tool.LargeChange = 1;
            this.hsbarIntegral_Tool.Location = new System.Drawing.Point(57, 135);
            this.hsbarIntegral_Tool.Maximum = 255;
            this.hsbarIntegral_Tool.Name = "hsbarIntegral_Tool";
            this.hsbarIntegral_Tool.Size = new System.Drawing.Size(302, 40);
            this.hsbarIntegral_Tool.TabIndex = 351;
            this.hsbarIntegral_Tool.Value = 5;
            this.hsbarIntegral_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarIntegral_Tool_Scroll);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(77, 105);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(273, 26);
            this.label27.TabIndex = 350;
            this.label27.Text = "Integral Gain";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label27.UseCompatibleTextRendering = true;
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
            this.tabSteer.Controls.Add(this.hsbarCPD_Tool);
            this.tabSteer.Controls.Add(this.lblCPD_Tool);
            this.tabSteer.Controls.Add(this.lblZeroWAS_Tool);
            this.tabSteer.Controls.Add(this.hsbarMaxSteerAngle_Tool);
            this.tabSteer.Controls.Add(this.label99);
            this.tabSteer.ImageIndex = 4;
            this.tabSteer.Location = new System.Drawing.Point(4, 52);
            this.tabSteer.Name = "tabSteer";
            this.tabSteer.Size = new System.Drawing.Size(365, 387);
            this.tabSteer.TabIndex = 5;
            // 
            // lblAV_Set
            // 
            this.lblAV_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAV_Set.AutoSize = true;
            this.lblAV_Set.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAV_Set.Location = new System.Drawing.Point(-418, 18);
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
            this.lblAV_Act.Location = new System.Drawing.Point(-418, 42);
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
            this.label36.Location = new System.Drawing.Point(-462, 44);
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
            this.label38.Location = new System.Drawing.Point(-463, 20);
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
            this.lblActualSteerAngleUpper.Location = new System.Drawing.Point(-657, 16);
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
            this.btnZeroWAS_Tool.Location = new System.Drawing.Point(170, 33);
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
            this.label96.Text = "Actuator Limits %";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarZeroWAS_Tool
            // 
            this.hsbarZeroWAS_Tool.LargeChange = 20;
            this.hsbarZeroWAS_Tool.Location = new System.Drawing.Point(76, 118);
            this.hsbarZeroWAS_Tool.Maximum = 4000;
            this.hsbarZeroWAS_Tool.Minimum = -4000;
            this.hsbarZeroWAS_Tool.Name = "hsbarZeroWAS_Tool";
            this.hsbarZeroWAS_Tool.Size = new System.Drawing.Size(281, 40);
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
            this.label101.Location = new System.Drawing.Point(116, 90);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(200, 24);
            this.label101.TabIndex = 566;
            this.label101.Text = "Actuator Center";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarCPD_Tool
            // 
            this.hsbarCPD_Tool.LargeChange = 1;
            this.hsbarCPD_Tool.Location = new System.Drawing.Point(76, 222);
            this.hsbarCPD_Tool.Maximum = 255;
            this.hsbarCPD_Tool.Minimum = 1;
            this.hsbarCPD_Tool.Name = "hsbarCPD_Tool";
            this.hsbarCPD_Tool.Size = new System.Drawing.Size(281, 40);
            this.hsbarCPD_Tool.TabIndex = 570;
            this.hsbarCPD_Tool.Value = 20;
            this.hsbarCPD_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarCPD_Tool_Scroll);
            // 
            // lblCPD_Tool
            // 
            this.lblCPD_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPD_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblCPD_Tool.Location = new System.Drawing.Point(19, 219);
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
            this.lblZeroWAS_Tool.Location = new System.Drawing.Point(6, 118);
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
            this.hsbarMaxSteerAngle_Tool.Minimum = 10;
            this.hsbarMaxSteerAngle_Tool.Name = "hsbarMaxSteerAngle_Tool";
            this.hsbarMaxSteerAngle_Tool.Size = new System.Drawing.Size(281, 40);
            this.hsbarMaxSteerAngle_Tool.TabIndex = 568;
            this.hsbarMaxSteerAngle_Tool.Value = 10;
            this.hsbarMaxSteerAngle_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarMaxSteerAngle_Tool_Scroll);
            // 
            // label99
            // 
            this.label99.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.Color.Black;
            this.label99.Location = new System.Drawing.Point(116, 194);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(200, 24);
            this.label99.TabIndex = 575;
            this.label99.Text = "Counts per Unit";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDeadzone
            // 
            this.tabDeadzone.BackColor = System.Drawing.Color.Gainsboro;
            this.tabDeadzone.Controls.Add(this.hsbarPassiveIntegralGain);
            this.tabDeadzone.Controls.Add(this.label51);
            this.tabDeadzone.Controls.Add(this.hsbarPassiveCurvature);
            this.tabDeadzone.Controls.Add(this.label54);
            this.tabDeadzone.Controls.Add(this.label49);
            this.tabDeadzone.Controls.Add(this.label6);
            this.tabDeadzone.Controls.Add(this.lblPassiveIntegralGain);
            this.tabDeadzone.Controls.Add(this.label7);
            this.tabDeadzone.Controls.Add(this.lblCurvatureGain);
            this.tabDeadzone.Controls.Add(this.nudDeadZoneDelay);
            this.tabDeadzone.Controls.Add(this.nudDeadzoneWidth);
            this.tabDeadzone.ImageIndex = 2;
            this.tabDeadzone.Location = new System.Drawing.Point(4, 52);
            this.tabDeadzone.Name = "tabDeadzone";
            this.tabDeadzone.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeadzone.Size = new System.Drawing.Size(365, 387);
            this.tabDeadzone.TabIndex = 17;
            // 
            // hsbarPassiveIntegralGain
            // 
            this.hsbarPassiveIntegralGain.LargeChange = 1;
            this.hsbarPassiveIntegralGain.Location = new System.Drawing.Point(67, 330);
            this.hsbarPassiveIntegralGain.Maximum = 25;
            this.hsbarPassiveIntegralGain.Name = "hsbarPassiveIntegralGain";
            this.hsbarPassiveIntegralGain.Size = new System.Drawing.Size(292, 40);
            this.hsbarPassiveIntegralGain.TabIndex = 563;
            this.hsbarPassiveIntegralGain.Value = 4;
            this.hsbarPassiveIntegralGain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarPassiveIntegralGain_Scroll);
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(20, 22);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(329, 25);
            this.label51.TabIndex = 541;
            this.label51.Text = "Dead Zone";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarPassiveCurvature
            // 
            this.hsbarPassiveCurvature.LargeChange = 1;
            this.hsbarPassiveCurvature.Location = new System.Drawing.Point(67, 219);
            this.hsbarPassiveCurvature.Maximum = 500;
            this.hsbarPassiveCurvature.Name = "hsbarPassiveCurvature";
            this.hsbarPassiveCurvature.Size = new System.Drawing.Size(292, 40);
            this.hsbarPassiveCurvature.TabIndex = 560;
            this.hsbarPassiveCurvature.Value = 4;
            this.hsbarPassiveCurvature.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarPassiveCurvature_Scroll);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(221, 95);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(112, 28);
            this.label54.TabIndex = 543;
            this.label54.Text = "On Delay";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label49.Location = new System.Drawing.Point(53, 95);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(112, 28);
            this.label49.TabIndex = 539;
            this.label49.Text = "XTE";
            this.label49.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(74, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 24);
            this.label6.TabIndex = 562;
            this.label6.Text = "Passive Curve Gain";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassiveIntegralGain
            // 
            this.lblPassiveIntegralGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassiveIntegralGain.ForeColor = System.Drawing.Color.Black;
            this.lblPassiveIntegralGain.Location = new System.Drawing.Point(3, 332);
            this.lblPassiveIntegralGain.Name = "lblPassiveIntegralGain";
            this.lblPassiveIntegralGain.Size = new System.Drawing.Size(57, 35);
            this.lblPassiveIntegralGain.TabIndex = 564;
            this.lblPassiveIntegralGain.Text = "2.5";
            this.lblPassiveIntegralGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(74, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 24);
            this.label7.TabIndex = 565;
            this.label7.Text = "Passive Integral Gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurvatureGain
            // 
            this.lblCurvatureGain.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurvatureGain.ForeColor = System.Drawing.Color.Black;
            this.lblCurvatureGain.Location = new System.Drawing.Point(3, 221);
            this.lblCurvatureGain.Name = "lblCurvatureGain";
            this.lblCurvatureGain.Size = new System.Drawing.Size(57, 35);
            this.lblCurvatureGain.TabIndex = 561;
            this.lblCurvatureGain.Text = "100";
            this.lblCurvatureGain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Sf_PPTab.png");
            this.imageList1.Images.SetKeyName(1, "ST_GainTab.png");
            this.imageList1.Images.SetKeyName(2, "ConS_ImplementHitch.png");
            this.imageList1.Images.SetKeyName(3, "ST_StanleyTab.png");
            this.imageList1.Images.SetKeyName(4, "ST_SteerTab.png");
            // 
            // lblAckermann_Tool
            // 
            this.lblAckermann_Tool.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAckermann_Tool.ForeColor = System.Drawing.Color.Black;
            this.lblAckermann_Tool.Location = new System.Drawing.Point(6, 695);
            this.lblAckermann_Tool.Name = "lblAckermann_Tool";
            this.lblAckermann_Tool.Size = new System.Drawing.Size(52, 35);
            this.lblAckermann_Tool.TabIndex = 574;
            this.lblAckermann_Tool.Text = "888";
            this.lblAckermann_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label98
            // 
            this.label98.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.Color.Black;
            this.label98.Location = new System.Drawing.Point(103, 670);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(200, 24);
            this.label98.TabIndex = 576;
            this.label98.Text = "Ackermann";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarAckermann_Tool
            // 
            this.hsbarAckermann_Tool.LargeChange = 1;
            this.hsbarAckermann_Tool.Location = new System.Drawing.Point(63, 698);
            this.hsbarAckermann_Tool.Maximum = 200;
            this.hsbarAckermann_Tool.Minimum = 1;
            this.hsbarAckermann_Tool.Name = "hsbarAckermann_Tool";
            this.hsbarAckermann_Tool.Size = new System.Drawing.Size(281, 30);
            this.hsbarAckermann_Tool.TabIndex = 573;
            this.hsbarAckermann_Tool.Value = 100;
            this.hsbarAckermann_Tool.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarAckermann_Tool_Scroll);
            // 
            // label82
            // 
            this.label82.Enabled = false;
            this.label82.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.Location = new System.Drawing.Point(508, 666);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(273, 26);
            this.label82.TabIndex = 548;
            this.label82.Text = "Acquire Factor";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbarAcquireFactor
            // 
            this.hsbarAcquireFactor.Enabled = false;
            this.hsbarAcquireFactor.LargeChange = 1;
            this.hsbarAcquireFactor.Location = new System.Drawing.Point(498, 696);
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
            this.lblAcquireFactor.Location = new System.Drawing.Point(433, 698);
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
            this.hsbarLookAheadMult.Location = new System.Drawing.Point(498, 626);
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
            this.label19.Location = new System.Drawing.Point(508, 601);
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
            this.lblLookAheadMult.Location = new System.Drawing.Point(433, 628);
            this.lblLookAheadMult.Name = "lblLookAheadMult";
            this.lblLookAheadMult.Size = new System.Drawing.Size(60, 35);
            this.lblLookAheadMult.TabIndex = 299;
            this.lblLookAheadMult.Text = "888";
            this.lblLookAheadMult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lblPWMDisplay);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnExpand);
            this.panel2.Location = new System.Drawing.Point(4, 448);
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
            // tabToolSetup
            // 
            this.tabToolSetup.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabToolSetup.Controls.Add(this.tabModes);
            this.tabToolSetup.Controls.Add(this.tabActive);
            this.tabToolSetup.Controls.Add(this.tabSetup);
            this.tabToolSetup.Controls.Add(this.tabAntenna);
            this.tabToolSetup.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabToolSetup.ImageList = this.imageList2;
            this.tabToolSetup.ItemSize = new System.Drawing.Size(141, 48);
            this.tabToolSetup.Location = new System.Drawing.Point(373, 5);
            this.tabToolSetup.Name = "tabToolSetup";
            this.tabToolSetup.SelectedIndex = 0;
            this.tabToolSetup.Size = new System.Drawing.Size(579, 502);
            this.tabToolSetup.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabToolSetup.TabIndex = 528;
            // 
            // tabModes
            // 
            this.tabModes.BackColor = System.Drawing.Color.Gainsboro;
            this.tabModes.Controls.Add(this.cboxIsRecordToolLine);
            this.tabModes.Controls.Add(this.label4);
            this.tabModes.Controls.Add(this.label8);
            this.tabModes.Controls.Add(this.cboxIsPassiveSteering);
            this.tabModes.Controls.Add(this.label1);
            this.tabModes.Controls.Add(this.cboxRecordSourceTool);
            this.tabModes.Controls.Add(this.cboxIsFollowCurrent);
            this.tabModes.Controls.Add(this.cboxIsFollowPivot);
            this.tabModes.Location = new System.Drawing.Point(4, 52);
            this.tabModes.Name = "tabModes";
            this.tabModes.Size = new System.Drawing.Size(571, 446);
            this.tabModes.TabIndex = 5;
            this.tabModes.Text = "Modes";
            this.tabModes.Click += new System.EventHandler(this.tabModes_Click);
            this.tabModes.Enter += new System.EventHandler(this.tabPassive_Enter);
            // 
            // cboxIsRecordToolLine
            // 
            this.cboxIsRecordToolLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsRecordToolLine.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsRecordToolLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsRecordToolLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsRecordToolLine.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsRecordToolLine.ForeColor = System.Drawing.Color.Black;
            this.cboxIsRecordToolLine.Location = new System.Drawing.Point(332, 173);
            this.cboxIsRecordToolLine.Name = "cboxIsRecordToolLine";
            this.cboxIsRecordToolLine.Size = new System.Drawing.Size(217, 70);
            this.cboxIsRecordToolLine.TabIndex = 592;
            this.cboxIsRecordToolLine.Text = "Record Tool Lines";
            this.cboxIsRecordToolLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsRecordToolLine.UseVisualStyleBackColor = false;
            this.cboxIsRecordToolLine.Click += new System.EventHandler(this.cboxIsRecordToolLine_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(28, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 30);
            this.label4.TabIndex = 591;
            this.label4.Text = "Passive Mode";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsPassiveSteering
            // 
            this.cboxIsPassiveSteering.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsPassiveSteering.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsPassiveSteering.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsPassiveSteering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsPassiveSteering.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsPassiveSteering.ForeColor = System.Drawing.Color.Black;
            this.cboxIsPassiveSteering.Location = new System.Drawing.Point(51, 342);
            this.cboxIsPassiveSteering.Name = "cboxIsPassiveSteering";
            this.cboxIsPassiveSteering.Size = new System.Drawing.Size(217, 70);
            this.cboxIsPassiveSteering.TabIndex = 587;
            this.cboxIsPassiveSteering.Text = "Curvature PID";
            this.cboxIsPassiveSteering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsPassiveSteering.UseVisualStyleBackColor = false;
            this.cboxIsPassiveSteering.Click += new System.EventHandler(this.cboxIsPassiveSteering_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 30);
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
            this.cboxIsFollowCurrent.Location = new System.Drawing.Point(51, 72);
            this.cboxIsFollowCurrent.Name = "cboxIsFollowCurrent";
            this.cboxIsFollowCurrent.Size = new System.Drawing.Size(217, 70);
            this.cboxIsFollowCurrent.TabIndex = 585;
            this.cboxIsFollowCurrent.Text = "Guidance Line";
            this.cboxIsFollowCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsFollowCurrent.UseVisualStyleBackColor = false;
            this.cboxIsFollowCurrent.Click += new System.EventHandler(this.cboxIsFollowCurrent_Click);
            // 
            // cboxIsFollowPivot
            // 
            this.cboxIsFollowPivot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsFollowPivot.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxIsFollowPivot.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxIsFollowPivot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsFollowPivot.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsFollowPivot.ForeColor = System.Drawing.Color.Black;
            this.cboxIsFollowPivot.Location = new System.Drawing.Point(51, 173);
            this.cboxIsFollowPivot.Name = "cboxIsFollowPivot";
            this.cboxIsFollowPivot.Size = new System.Drawing.Size(217, 70);
            this.cboxIsFollowPivot.TabIndex = 587;
            this.cboxIsFollowPivot.Text = "Vehicle Pivot";
            this.cboxIsFollowPivot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsFollowPivot.UseVisualStyleBackColor = false;
            this.cboxIsFollowPivot.Click += new System.EventHandler(this.cboxIsFollowPivot_Click);
            // 
            // tabActive
            // 
            this.tabActive.BackColor = System.Drawing.Color.Gainsboro;
            this.tabActive.Controls.Add(this.cboxPassesPerReference);
            this.tabActive.Controls.Add(this.label12);
            this.tabActive.Controls.Add(this.label14);
            this.tabActive.Controls.Add(this.label10);
            this.tabActive.Controls.Add(this.label5);
            this.tabActive.Controls.Add(this.nudToolGuidanceSpacing);
            this.tabActive.Controls.Add(this.nudNudge);
            this.tabActive.Location = new System.Drawing.Point(4, 52);
            this.tabActive.Name = "tabActive";
            this.tabActive.Size = new System.Drawing.Size(571, 446);
            this.tabActive.TabIndex = 7;
            this.tabActive.Text = "Active";
            // 
            // cboxPassesPerReference
            // 
            this.cboxPassesPerReference.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboxPassesPerReference.BackColor = System.Drawing.Color.Lavender;
            this.cboxPassesPerReference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPassesPerReference.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxPassesPerReference.FormattingEnabled = true;
            this.cboxPassesPerReference.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cboxPassesPerReference.Location = new System.Drawing.Point(87, 94);
            this.cboxPassesPerReference.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboxPassesPerReference.MaxDropDownItems = 5;
            this.cboxPassesPerReference.Name = "cboxPassesPerReference";
            this.cboxPassesPerReference.Size = new System.Drawing.Size(99, 53);
            this.cboxPassesPerReference.TabIndex = 602;
            this.cboxPassesPerReference.SelectedIndexChanged += new System.EventHandler(this.cboxPassesPerReference_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Firebrick;
            this.label12.Location = new System.Drawing.Point(65, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 23);
            this.label12.TabIndex = 601;
            this.label12.Text = "0 = Off";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(36, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(201, 59);
            this.label14.TabIndex = 600;
            this.label14.Text = "Passes Per Recorded Track";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(308, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 24);
            this.label8.TabIndex = 596;
            this.label8.Text = "Record Source";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxRecordSourceTool
            // 
            this.cboxRecordSourceTool.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxRecordSourceTool.BackColor = System.Drawing.Color.AliceBlue;
            this.cboxRecordSourceTool.Checked = true;
            this.cboxRecordSourceTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxRecordSourceTool.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxRecordSourceTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxRecordSourceTool.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRecordSourceTool.ForeColor = System.Drawing.Color.Black;
            this.cboxRecordSourceTool.Location = new System.Drawing.Point(332, 72);
            this.cboxRecordSourceTool.Name = "cboxRecordSourceTool";
            this.cboxRecordSourceTool.Size = new System.Drawing.Size(217, 70);
            this.cboxRecordSourceTool.TabIndex = 595;
            this.cboxRecordSourceTool.Text = "Tool GPS";
            this.cboxRecordSourceTool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxRecordSourceTool.UseVisualStyleBackColor = false;
            this.cboxRecordSourceTool.Click += new System.EventHandler(this.cboxRecordSourceTool_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(36, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 41);
            this.label10.TabIndex = 590;
            this.label10.Text = "Tool Width";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(358, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 41);
            this.label5.TabIndex = 588;
            this.label5.Text = "Nudge";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tabSetup
            // 
            this.tabSetup.BackColor = System.Drawing.Color.Gainsboro;
            this.tabSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSetup.Controls.Add(this.lblManualPWM_Percent);
            this.tabSetup.Controls.Add(this.cboxIsSteerNotSlide_Tool);
            this.tabSetup.Controls.Add(this.label74);
            this.tabSetup.Controls.Add(this.cboxInvertWAS_Tool);
            this.tabSetup.Controls.Add(this.cboxInvertSteer_Tool);
            this.tabSetup.Controls.Add(this.hsbarManualPWM_Percent);
            this.tabSetup.Controls.Add(this.label13);
            this.tabSetup.Controls.Add(this.label11);
            this.tabSetup.Controls.Add(this.label31);
            this.tabSetup.Controls.Add(this.lblManualSecondsOn);
            this.tabSetup.Controls.Add(this.label83);
            this.tabSetup.Controls.Add(this.hsbarManualSecondsOn);
            this.tabSetup.ImageIndex = 0;
            this.tabSetup.Location = new System.Drawing.Point(4, 52);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(571, 446);
            this.tabSetup.TabIndex = 4;
            // 
            // lblManualPWM_Percent
            // 
            this.lblManualPWM_Percent.Enabled = false;
            this.lblManualPWM_Percent.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualPWM_Percent.ForeColor = System.Drawing.Color.Black;
            this.lblManualPWM_Percent.Location = new System.Drawing.Point(13, 197);
            this.lblManualPWM_Percent.Name = "lblManualPWM_Percent";
            this.lblManualPWM_Percent.Size = new System.Drawing.Size(60, 35);
            this.lblManualPWM_Percent.TabIndex = 586;
            this.lblManualPWM_Percent.Text = "888";
            this.lblManualPWM_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cboxIsSteerNotSlide_Tool.Location = new System.Drawing.Point(437, 358);
            this.cboxIsSteerNotSlide_Tool.Name = "cboxIsSteerNotSlide_Tool";
            this.cboxIsSteerNotSlide_Tool.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxIsSteerNotSlide_Tool.Size = new System.Drawing.Size(99, 69);
            this.cboxIsSteerNotSlide_Tool.TabIndex = 578;
            this.cboxIsSteerNotSlide_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsSteerNotSlide_Tool.UseVisualStyleBackColor = false;
            this.cboxIsSteerNotSlide_Tool.Click += new System.EventHandler(this.cboxIsSteerNotSlide_Click);
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(407, 307);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(158, 48);
            this.label74.TabIndex = 579;
            this.label74.Text = "Steering Not Sliding";
            this.label74.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.cboxInvertWAS_Tool.Location = new System.Drawing.Point(437, 52);
            this.cboxInvertWAS_Tool.Name = "cboxInvertWAS_Tool";
            this.cboxInvertWAS_Tool.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxInvertWAS_Tool.Size = new System.Drawing.Size(99, 69);
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
            this.cboxInvertSteer_Tool.Location = new System.Drawing.Point(437, 205);
            this.cboxInvertSteer_Tool.Name = "cboxInvertSteer_Tool";
            this.cboxInvertSteer_Tool.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxInvertSteer_Tool.Size = new System.Drawing.Size(99, 69);
            this.cboxInvertSteer_Tool.TabIndex = 517;
            this.cboxInvertSteer_Tool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxInvertSteer_Tool.UseVisualStyleBackColor = false;
            this.cboxInvertSteer_Tool.Click += new System.EventHandler(this.cboxInvertSteer_Tool_Click);
            // 
            // hsbarManualPWM_Percent
            // 
            this.hsbarManualPWM_Percent.LargeChange = 1;
            this.hsbarManualPWM_Percent.Location = new System.Drawing.Point(78, 195);
            this.hsbarManualPWM_Percent.Minimum = 10;
            this.hsbarManualPWM_Percent.Name = "hsbarManualPWM_Percent";
            this.hsbarManualPWM_Percent.Size = new System.Drawing.Size(292, 40);
            this.hsbarManualPWM_Percent.TabIndex = 585;
            this.hsbarManualPWM_Percent.Value = 50;
            this.hsbarManualPWM_Percent.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarManualPWM_Percent_Scroll);
            // 
            // label13
            // 
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(88, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(273, 26);
            this.label13.TabIndex = 584;
            this.label13.Text = "Manual Steer PWM %";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.Enabled = false;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(88, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(273, 26);
            this.label11.TabIndex = 581;
            this.label11.Text = "Manual Steer Seconds On";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(407, 14);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(158, 36);
            this.label31.TabIndex = 519;
            this.label31.Text = "Invert WAS";
            this.label31.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblManualSecondsOn
            // 
            this.lblManualSecondsOn.Enabled = false;
            this.lblManualSecondsOn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualSecondsOn.ForeColor = System.Drawing.Color.Black;
            this.lblManualSecondsOn.Location = new System.Drawing.Point(13, 89);
            this.lblManualSecondsOn.Name = "lblManualSecondsOn";
            this.lblManualSecondsOn.Size = new System.Drawing.Size(60, 35);
            this.lblManualSecondsOn.TabIndex = 583;
            this.lblManualSecondsOn.Text = "888";
            this.lblManualSecondsOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.Black;
            this.label83.Location = new System.Drawing.Point(407, 153);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(158, 50);
            this.label83.TabIndex = 518;
            this.label83.Text = "Invert \r\nMotor Dir";
            this.label83.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // hsbarManualSecondsOn
            // 
            this.hsbarManualSecondsOn.LargeChange = 1;
            this.hsbarManualSecondsOn.Location = new System.Drawing.Point(78, 87);
            this.hsbarManualSecondsOn.Maximum = 10;
            this.hsbarManualSecondsOn.Minimum = 1;
            this.hsbarManualSecondsOn.Name = "hsbarManualSecondsOn";
            this.hsbarManualSecondsOn.Size = new System.Drawing.Size(292, 40);
            this.hsbarManualSecondsOn.TabIndex = 582;
            this.hsbarManualSecondsOn.Value = 2;
            this.hsbarManualSecondsOn.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbarManualSecondsOn_Scroll);
            // 
            // tabAntenna
            // 
            this.tabAntenna.BackColor = System.Drawing.Color.Gainsboro;
            this.tabAntenna.Controls.Add(this.btnRollOffsetUp);
            this.tabAntenna.Controls.Add(this.btnRollOffsetDown);
            this.tabAntenna.Controls.Add(this.lblInvertRoll);
            this.tabAntenna.Controls.Add(this.lblRollZeroOffset);
            this.tabAntenna.Controls.Add(this.lblZeroRoll);
            this.tabAntenna.Controls.Add(this.lblHeadingOffset);
            this.tabAntenna.Controls.Add(this.lblRemoveOffset);
            this.tabAntenna.Controls.Add(this.cboxDataInvertRoll);
            this.tabAntenna.Controls.Add(this.btnZeroRoll);
            this.tabAntenna.Controls.Add(this.label3);
            this.tabAntenna.Controls.Add(this.label2);
            this.tabAntenna.Controls.Add(this.btnRemoveZeroOffset);
            this.tabAntenna.Controls.Add(this.nudDualHeadingOffset);
            this.tabAntenna.Controls.Add(this.nudAntennaHeight_Tool);
            this.tabAntenna.Controls.Add(this.nudAntennaOffset_Tool);
            this.tabAntenna.ImageIndex = 1;
            this.tabAntenna.Location = new System.Drawing.Point(4, 52);
            this.tabAntenna.Name = "tabAntenna";
            this.tabAntenna.Size = new System.Drawing.Size(571, 446);
            this.tabAntenna.TabIndex = 9;
            // 
            // lblInvertRoll
            // 
            this.lblInvertRoll.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvertRoll.ForeColor = System.Drawing.Color.Black;
            this.lblInvertRoll.Location = new System.Drawing.Point(69, 28);
            this.lblInvertRoll.Name = "lblInvertRoll";
            this.lblInvertRoll.Size = new System.Drawing.Size(148, 23);
            this.lblInvertRoll.TabIndex = 538;
            this.lblInvertRoll.Text = "Invert Roll";
            this.lblInvertRoll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblRollZeroOffset
            // 
            this.lblRollZeroOffset.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.lblRollZeroOffset.ForeColor = System.Drawing.Color.Black;
            this.lblRollZeroOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRollZeroOffset.Location = new System.Drawing.Point(227, 354);
            this.lblRollZeroOffset.Name = "lblRollZeroOffset";
            this.lblRollZeroOffset.Size = new System.Drawing.Size(100, 33);
            this.lblRollZeroOffset.TabIndex = 529;
            this.lblRollZeroOffset.Text = "label11";
            this.lblRollZeroOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZeroRoll
            // 
            this.lblZeroRoll.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZeroRoll.ForeColor = System.Drawing.Color.Black;
            this.lblZeroRoll.Location = new System.Drawing.Point(70, 314);
            this.lblZeroRoll.Name = "lblZeroRoll";
            this.lblZeroRoll.Size = new System.Drawing.Size(148, 23);
            this.lblZeroRoll.TabIndex = 537;
            this.lblZeroRoll.Text = "Zero Roll";
            this.lblZeroRoll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblHeadingOffset
            // 
            this.lblHeadingOffset.BackColor = System.Drawing.Color.Transparent;
            this.lblHeadingOffset.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHeadingOffset.ForeColor = System.Drawing.Color.Black;
            this.lblHeadingOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeadingOffset.Location = new System.Drawing.Point(380, 4);
            this.lblHeadingOffset.Name = "lblHeadingOffset";
            this.lblHeadingOffset.Size = new System.Drawing.Size(186, 54);
            this.lblHeadingOffset.TabIndex = 539;
            this.lblHeadingOffset.Text = "Heading Offset (Degree)";
            this.lblHeadingOffset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblRemoveOffset
            // 
            this.lblRemoveOffset.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveOffset.ForeColor = System.Drawing.Color.Black;
            this.lblRemoveOffset.Location = new System.Drawing.Point(18, 155);
            this.lblRemoveOffset.Name = "lblRemoveOffset";
            this.lblRemoveOffset.Size = new System.Drawing.Size(243, 40);
            this.lblRemoveOffset.TabIndex = 536;
            this.lblRemoveOffset.Text = "Remove Offset";
            this.lblRemoveOffset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cboxDataInvertRoll
            // 
            this.cboxDataInvertRoll.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxDataInvertRoll.BackColor = System.Drawing.Color.White;
            this.cboxDataInvertRoll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cboxDataInvertRoll.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.cboxDataInvertRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxDataInvertRoll.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDataInvertRoll.ForeColor = System.Drawing.Color.Black;
            this.cboxDataInvertRoll.Image = global::Twol.Properties.Resources.ConDa_InvertRoll;
            this.cboxDataInvertRoll.Location = new System.Drawing.Point(74, 55);
            this.cboxDataInvertRoll.Name = "cboxDataInvertRoll";
            this.cboxDataInvertRoll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxDataInvertRoll.Size = new System.Drawing.Size(130, 72);
            this.cboxDataInvertRoll.TabIndex = 532;
            this.cboxDataInvertRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxDataInvertRoll.UseVisualStyleBackColor = false;
            // 
            // btnZeroRoll
            // 
            this.btnZeroRoll.BackColor = System.Drawing.Color.White;
            this.btnZeroRoll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZeroRoll.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnZeroRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroRoll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroRoll.ForeColor = System.Drawing.Color.Black;
            this.btnZeroRoll.Image = global::Twol.Properties.Resources.ConDa_RollSetZero;
            this.btnZeroRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroRoll.Location = new System.Drawing.Point(75, 339);
            this.btnZeroRoll.Name = "btnZeroRoll";
            this.btnZeroRoll.Size = new System.Drawing.Size(130, 72);
            this.btnZeroRoll.TabIndex = 530;
            this.btnZeroRoll.UseVisualStyleBackColor = false;
            this.btnZeroRoll.Click += new System.EventHandler(this.btnZeroRoll_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(394, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 41);
            this.label3.TabIndex = 583;
            this.label3.Text = "Antenna Offset";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(394, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 58);
            this.label2.TabIndex = 581;
            this.label2.Text = "Antenna Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnRemoveZeroOffset
            // 
            this.btnRemoveZeroOffset.BackColor = System.Drawing.Color.White;
            this.btnRemoveZeroOffset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRemoveZeroOffset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnRemoveZeroOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveZeroOffset.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveZeroOffset.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveZeroOffset.Image = global::Twol.Properties.Resources.ConDa_RemoveOffset;
            this.btnRemoveZeroOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveZeroOffset.Location = new System.Drawing.Point(75, 197);
            this.btnRemoveZeroOffset.Name = "btnRemoveZeroOffset";
            this.btnRemoveZeroOffset.Size = new System.Drawing.Size(130, 72);
            this.btnRemoveZeroOffset.TabIndex = 531;
            this.btnRemoveZeroOffset.UseVisualStyleBackColor = false;
            this.btnRemoveZeroOffset.Click += new System.EventHandler(this.btnRemoveZeroOffset_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "ConS_ImplementConfig.png");
            this.imageList2.Images.SetKeyName(1, "ConS_ImplementAntenna.png");
            this.imageList2.Images.SetKeyName(2, "ModeActive.png");
            this.imageList2.Images.SetKeyName(3, "ModePassive.png");
            // 
            // nudToolGuidanceSpacing
            // 
            this.nudToolGuidanceSpacing.DecimalPlaces = 1;
            this.nudToolGuidanceSpacing.Location = new System.Drawing.Point(29, 228);
            this.nudToolGuidanceSpacing.Maximum = 2000D;
            this.nudToolGuidanceSpacing.Mode = Twol.UnitMode.Small;
            this.nudToolGuidanceSpacing.Name = "nudToolGuidanceSpacing";
            this.nudToolGuidanceSpacing.Size = new System.Drawing.Size(215, 64);
            this.nudToolGuidanceSpacing.TabIndex = 589;
            this.nudToolGuidanceSpacing.ValueChanged += new System.EventHandler(this.nudToolGuidanceSpacing_ValueChanged);
            // 
            // nudNudge
            // 
            this.nudNudge.Location = new System.Drawing.Point(366, 88);
            this.nudNudge.Maximum = 500D;
            this.nudNudge.Minimum = -500D;
            this.nudNudge.Mode = Twol.UnitMode.Small;
            this.nudNudge.Name = "nudNudge";
            this.nudNudge.Size = new System.Drawing.Size(143, 56);
            this.nudNudge.TabIndex = 587;
            this.nudNudge.ValueChanged += new System.EventHandler(this.nudNudge_ValueChanged);
            // 
            // btnRollOffsetUp
            // 
            this.btnRollOffsetUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRollOffsetUp.FlatAppearance.BorderSize = 0;
            this.btnRollOffsetUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollOffsetUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollOffsetUp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRollOffsetUp.Image = global::Twol.Properties.Resources.UpArrow64;
            this.btnRollOffsetUp.Location = new System.Drawing.Point(289, 271);
            this.btnRollOffsetUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRollOffsetUp.Name = "btnRollOffsetUp";
            this.btnRollOffsetUp.Size = new System.Drawing.Size(59, 69);
            this.btnRollOffsetUp.TabIndex = 534;
            this.btnRollOffsetUp.UseVisualStyleBackColor = true;
            this.btnRollOffsetUp.Click += new System.EventHandler(this.btnRollOffsetUp_Click);
            // 
            // btnRollOffsetDown
            // 
            this.btnRollOffsetDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRollOffsetDown.FlatAppearance.BorderSize = 0;
            this.btnRollOffsetDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollOffsetDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollOffsetDown.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRollOffsetDown.Image = global::Twol.Properties.Resources.DnArrow64;
            this.btnRollOffsetDown.Location = new System.Drawing.Point(217, 271);
            this.btnRollOffsetDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRollOffsetDown.Name = "btnRollOffsetDown";
            this.btnRollOffsetDown.Size = new System.Drawing.Size(59, 69);
            this.btnRollOffsetDown.TabIndex = 533;
            this.btnRollOffsetDown.UseVisualStyleBackColor = true;
            this.btnRollOffsetDown.Click += new System.EventHandler(this.btnRollOffsetDown_Click);
            // 
            // nudDualHeadingOffset
            // 
            this.nudDualHeadingOffset.DecimalPlaces = 1;
            this.nudDualHeadingOffset.Location = new System.Drawing.Point(402, 63);
            this.nudDualHeadingOffset.Minimum = -100D;
            this.nudDualHeadingOffset.Name = "nudDualHeadingOffset";
            this.nudDualHeadingOffset.Size = new System.Drawing.Size(143, 56);
            this.nudDualHeadingOffset.TabIndex = 540;
            this.nudDualHeadingOffset.ValueChanged += new System.EventHandler(this.nudDualHeadingOffset_ValueChanged);
            // 
            // nudAntennaHeight_Tool
            // 
            this.nudAntennaHeight_Tool.Location = new System.Drawing.Point(402, 205);
            this.nudAntennaHeight_Tool.Maximum = 5D;
            this.nudAntennaHeight_Tool.Mode = Twol.UnitMode.Small;
            this.nudAntennaHeight_Tool.Name = "nudAntennaHeight_Tool";
            this.nudAntennaHeight_Tool.Size = new System.Drawing.Size(143, 56);
            this.nudAntennaHeight_Tool.TabIndex = 580;
            this.nudAntennaHeight_Tool.ValueChanged += new System.EventHandler(this.nudAntennaHeight_Tool_ValueChanged);
            // 
            // nudAntennaOffset_Tool
            // 
            this.nudAntennaOffset_Tool.Location = new System.Drawing.Point(402, 347);
            this.nudAntennaOffset_Tool.Maximum = 5D;
            this.nudAntennaOffset_Tool.Minimum = -5D;
            this.nudAntennaOffset_Tool.Mode = Twol.UnitMode.Small;
            this.nudAntennaOffset_Tool.Name = "nudAntennaOffset_Tool";
            this.nudAntennaOffset_Tool.Size = new System.Drawing.Size(143, 56);
            this.nudAntennaOffset_Tool.TabIndex = 582;
            this.nudAntennaOffset_Tool.ValueChanged += new System.EventHandler(this.nudAntennaOffset_Tool_ValueChanged);
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
            // nudDeadZoneDelay
            // 
            this.nudDeadZoneDelay.Location = new System.Drawing.Point(224, 53);
            this.nudDeadZoneDelay.Maximum = 10D;
            this.nudDeadZoneDelay.Name = "nudDeadZoneDelay";
            this.nudDeadZoneDelay.Size = new System.Drawing.Size(107, 36);
            this.nudDeadZoneDelay.TabIndex = 542;
            this.nudDeadZoneDelay.ValueChanged += new System.EventHandler(this.nudDeadZoneDelay_ValueChanged);
            // 
            // nudDeadzoneWidth
            // 
            this.nudDeadzoneWidth.Location = new System.Drawing.Point(56, 54);
            this.nudDeadzoneWidth.Maximum = 5D;
            this.nudDeadzoneWidth.Minimum = 0.1D;
            this.nudDeadzoneWidth.Mode = Twol.UnitMode.Small;
            this.nudDeadzoneWidth.Name = "nudDeadzoneWidth";
            this.nudDeadzoneWidth.Size = new System.Drawing.Size(107, 36);
            this.nudDeadzoneWidth.TabIndex = 538;
            this.nudDeadzoneWidth.ValueChanged += new System.EventHandler(this.nudDeadzoneWidth_ValueChanged);
            // 
            // FormToolSteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(951, 817);
            this.Controls.Add(this.label82);
            this.Controls.Add(this.tabToolSetup);
            this.Controls.Add(this.hsbarAcquireFactor);
            this.Controls.Add(this.lblAcquireFactor);
            this.Controls.Add(this.hsbarLookAheadMult);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblLookAheadMult);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.hsbarAckermann_Tool);
            this.Controls.Add(this.label98);
            this.Controls.Add(this.lblAckermann_Tool);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolSteer";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool Steer Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolSteer_FormClosing);
            this.Load += new System.EventHandler(this.FormToolSteer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGain.ResumeLayout(false);
            this.tabSteer.ResumeLayout(false);
            this.tabSteer.PerformLayout();
            this.tabDeadzone.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabToolSetup.ResumeLayout(false);
            this.tabModes.ResumeLayout(false);
            this.tabActive.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabAntenna.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.HScrollBar hsbarLookAheadMult;
        private System.Windows.Forms.Label lblLookAheadMult;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGain;
        private System.Windows.Forms.Label label19;
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
        private NudlessNumericUpDown nudDeadzoneWidth;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.Label label54;
        private NudlessNumericUpDown nudDeadZoneDelay;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lblAcquireFactor;
        private System.Windows.Forms.HScrollBar hsbarAcquireFactor;
        private System.Windows.Forms.TabPage tabDeadzone;
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
        private System.Windows.Forms.TabPage tabModes;
        private System.Windows.Forms.Label lblCurvatureGain;
        private System.Windows.Forms.HScrollBar hsbarPassiveCurvature;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPassiveIntegralGain;
        private System.Windows.Forms.HScrollBar hsbarPassiveIntegralGain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cboxIsPassiveSteering;
        private System.Windows.Forms.CheckBox cboxIsFollowPivot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabActive;
        private System.Windows.Forms.CheckBox cboxIsRecordToolLine;
        private System.Windows.Forms.Label lblManualPWM_Percent;
        private System.Windows.Forms.HScrollBar hsbarManualPWM_Percent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblManualSecondsOn;
        private System.Windows.Forms.HScrollBar hsbarManualSecondsOn;
        private System.Windows.Forms.Label label11;
        private NudlessNumericUpDown nudNudge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cboxRecordSourceTool;
        private NudlessNumericUpDown nudToolGuidanceSpacing;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboxPassesPerReference;
        private RepeatButton btnRollOffsetUp;
        private RepeatButton btnRollOffsetDown;
        private System.Windows.Forms.Label lblRollZeroOffset;
        private System.Windows.Forms.Button btnZeroRoll;
        private System.Windows.Forms.Button btnRemoveZeroOffset;
        private System.Windows.Forms.CheckBox cboxDataInvertRoll;
        private System.Windows.Forms.Label lblInvertRoll;
        private System.Windows.Forms.Label lblZeroRoll;
        private System.Windows.Forms.Label lblRemoveOffset;
        private System.Windows.Forms.TabPage tabAntenna;
        private NudlessNumericUpDown nudDualHeadingOffset;
        private System.Windows.Forms.Label lblHeadingOffset;
    }
}