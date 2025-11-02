namespace Twol
{
    partial class FormUDP
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblNetworkHelp = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tboxNets = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblNoAdapter = new System.Windows.Forms.Label();
            this.cboxUp = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSubTimer = new System.Windows.Forms.Label();
            this.cboxIsLoopbackOn = new System.Windows.Forms.CheckBox();
            this.btnSerialMonitor = new System.Windows.Forms.Button();
            this.btnNetworkCPL = new System.Windows.Forms.Button();
            this.btnUDPOff = new System.Windows.Forms.Button();
            this.btnSendSubnet = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.pboxSendSteer = new System.Windows.Forms.PictureBox();
            this.nudThirdIP = new Twol.NudlessNumericUpDown();
            this.nudSecondIP = new Twol.NudlessNumericUpDown();
            this.nudFirstIP = new Twol.NudlessNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSendSteer)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(418, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 23);
            this.label6.TabIndex = 144;
            this.label6.Text = "Current Subnet";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNetworkHelp
            // 
            this.lblNetworkHelp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblNetworkHelp.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNetworkHelp.Location = new System.Drawing.Point(348, 325);
            this.lblNetworkHelp.Name = "lblNetworkHelp";
            this.lblNetworkHelp.Size = new System.Drawing.Size(279, 46);
            this.lblNetworkHelp.TabIndex = 143;
            this.lblNetworkHelp.Text = "192 . 168 . 123  .  x";
            this.lblNetworkHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 23);
            this.label1.TabIndex = 147;
            this.label1.Text = "Enter New Subnet Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(418, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 35);
            this.label2.TabIndex = 152;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 35);
            this.label3.TabIndex = 153;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 157;
            this.label8.Text = "Set Subnet";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tboxNets
            // 
            this.tboxNets.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNets.Location = new System.Drawing.Point(16, 45);
            this.tboxNets.Multiline = true;
            this.tboxNets.Name = "tboxNets";
            this.tboxNets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxNets.Size = new System.Drawing.Size(261, 430);
            this.tboxNets.TabIndex = 162;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 163;
            this.label4.Text = "Hostname:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.BackColor = System.Drawing.Color.Gainsboro;
            this.lblHostname.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostname.Location = new System.Drawing.Point(112, 13);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(94, 23);
            this.lblHostname.TabIndex = 165;
            this.lblHostname.Text = "Hostname";
            this.lblHostname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoAdapter
            // 
            this.lblNoAdapter.AutoSize = true;
            this.lblNoAdapter.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoAdapter.ForeColor = System.Drawing.Color.Red;
            this.lblNoAdapter.Location = new System.Drawing.Point(338, 294);
            this.lblNoAdapter.Name = "lblNoAdapter";
            this.lblNoAdapter.Size = new System.Drawing.Size(298, 25);
            this.lblNoAdapter.TabIndex = 166;
            this.lblNoAdapter.Text = "No Adapter For This Subnet";
            this.lblNoAdapter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxUp
            // 
            this.cboxUp.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxUp.BackColor = System.Drawing.Color.White;
            this.cboxUp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxUp.Checked = true;
            this.cboxUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.cboxUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxUp.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxUp.Location = new System.Drawing.Point(78, 487);
            this.cboxUp.Name = "cboxUp";
            this.cboxUp.Size = new System.Drawing.Size(171, 50);
            this.cboxUp.TabIndex = 168;
            this.cboxUp.Text = "Up";
            this.cboxUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxUp.UseVisualStyleBackColor = false;
            this.cboxUp.Click += new System.EventHandler(this.cboxUp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 501);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 23);
            this.label9.TabIndex = 513;
            this.label9.Text = "Filter";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(179, 629);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 18);
            this.label10.TabIndex = 523;
            this.label10.Text = "UDP Monitor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 522);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 525;
            this.label5.Text = "UDP Off";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 628);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 18);
            this.label12.TabIndex = 526;
            this.label12.Text = "Network Prop";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(551, 522);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 18);
            this.label13.TabIndex = 532;
            this.label13.Text = "Plugins";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSubTimer
            // 
            this.lblSubTimer.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTimer.Location = new System.Drawing.Point(328, 6);
            this.lblSubTimer.Name = "lblSubTimer";
            this.lblSubTimer.Size = new System.Drawing.Size(318, 37);
            this.lblSubTimer.TabIndex = 533;
            this.lblSubTimer.Text = "Scanning";
            this.lblSubTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxIsLoopbackOn
            // 
            this.cboxIsLoopbackOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsLoopbackOn.BackColor = System.Drawing.Color.LightSalmon;
            this.cboxIsLoopbackOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsLoopbackOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsLoopbackOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsLoopbackOn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsLoopbackOn.Image = global::Twol.Properties.Resources.Plugin;
            this.cboxIsLoopbackOn.Location = new System.Drawing.Point(525, 437);
            this.cboxIsLoopbackOn.Name = "cboxIsLoopbackOn";
            this.cboxIsLoopbackOn.Size = new System.Drawing.Size(102, 79);
            this.cboxIsLoopbackOn.TabIndex = 531;
            this.cboxIsLoopbackOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsLoopbackOn.UseVisualStyleBackColor = false;
            this.cboxIsLoopbackOn.Click += new System.EventHandler(this.cboxIsLoopbackOn_Click);
            // 
            // btnSerialMonitor
            // 
            this.btnSerialMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialMonitor.FlatAppearance.BorderSize = 0;
            this.btnSerialMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialMonitor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialMonitor.Image = global::Twol.Properties.Resources.ScanNetwork;
            this.btnSerialMonitor.Location = new System.Drawing.Point(186, 568);
            this.btnSerialMonitor.Name = "btnSerialMonitor";
            this.btnSerialMonitor.Size = new System.Drawing.Size(76, 65);
            this.btnSerialMonitor.TabIndex = 522;
            this.btnSerialMonitor.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialMonitor.UseVisualStyleBackColor = true;
            this.btnSerialMonitor.Click += new System.EventHandler(this.btnSerialMonitor_Click);
            // 
            // btnNetworkCPL
            // 
            this.btnNetworkCPL.BackgroundImage = global::Twol.Properties.Resources.DeviceManager;
            this.btnNetworkCPL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNetworkCPL.FlatAppearance.BorderSize = 0;
            this.btnNetworkCPL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNetworkCPL.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNetworkCPL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNetworkCPL.Location = new System.Drawing.Point(39, 568);
            this.btnNetworkCPL.Name = "btnNetworkCPL";
            this.btnNetworkCPL.Size = new System.Drawing.Size(76, 65);
            this.btnNetworkCPL.TabIndex = 521;
            this.btnNetworkCPL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNetworkCPL.UseVisualStyleBackColor = true;
            this.btnNetworkCPL.Click += new System.EventHandler(this.btnNetworkCPL_Click);
            // 
            // btnUDPOff
            // 
            this.btnUDPOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUDPOff.FlatAppearance.BorderSize = 0;
            this.btnUDPOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUDPOff.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUDPOff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUDPOff.Image = global::Twol.Properties.Resources.EthernetOff;
            this.btnUDPOff.Location = new System.Drawing.Point(343, 437);
            this.btnUDPOff.Margin = new System.Windows.Forms.Padding(0);
            this.btnUDPOff.Name = "btnUDPOff";
            this.btnUDPOff.Size = new System.Drawing.Size(106, 79);
            this.btnUDPOff.TabIndex = 151;
            this.btnUDPOff.UseVisualStyleBackColor = true;
            this.btnUDPOff.Click += new System.EventHandler(this.btnUDPOff_Click);
            // 
            // btnSendSubnet
            // 
            this.btnSendSubnet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendSubnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSubnet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSubnet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendSubnet.Image = global::Twol.Properties.Resources.SubnetSend;
            this.btnSendSubnet.Location = new System.Drawing.Point(441, 164);
            this.btnSendSubnet.Name = "btnSendSubnet";
            this.btnSendSubnet.Size = new System.Drawing.Size(92, 79);
            this.btnSendSubnet.TabIndex = 151;
            this.btnSendSubnet.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSendSubnet.UseVisualStyleBackColor = true;
            this.btnSendSubnet.Click += new System.EventHandler(this.btnSendSubnet_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::Twol.Properties.Resources.OK64;
            this.btnSerialCancel.Location = new System.Drawing.Point(592, 573);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(92, 79);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // pboxSendSteer
            // 
            this.pboxSendSteer.BackgroundImage = global::Twol.Properties.Resources.ConSt_Mandatory;
            this.pboxSendSteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxSendSteer.Location = new System.Drawing.Point(539, 185);
            this.pboxSendSteer.Name = "pboxSendSteer";
            this.pboxSendSteer.Size = new System.Drawing.Size(38, 39);
            this.pboxSendSteer.TabIndex = 510;
            this.pboxSendSteer.TabStop = false;
            this.pboxSendSteer.Visible = false;
            // 
            // nudThirdIP
            // 
            this.nudThirdIP.Location = new System.Drawing.Point(556, 95);
            this.nudThirdIP.Maximum = 255D;
            this.nudThirdIP.Name = "nudThirdIP";
            this.nudThirdIP.Size = new System.Drawing.Size(90, 40);
            this.nudThirdIP.TabIndex = 530;
            this.nudThirdIP.ValueChanged += new System.EventHandler(this.nudFirstIP_ValueChanged);
            // 
            // nudSecondIP
            // 
            this.nudSecondIP.Location = new System.Drawing.Point(442, 95);
            this.nudSecondIP.Maximum = 255D;
            this.nudSecondIP.Name = "nudSecondIP";
            this.nudSecondIP.Size = new System.Drawing.Size(90, 40);
            this.nudSecondIP.TabIndex = 529;
            this.nudSecondIP.ValueChanged += new System.EventHandler(this.nudFirstIP_ValueChanged);
            // 
            // nudFirstIP
            // 
            this.nudFirstIP.Location = new System.Drawing.Point(328, 95);
            this.nudFirstIP.Maximum = 255D;
            this.nudFirstIP.Name = "nudFirstIP";
            this.nudFirstIP.Size = new System.Drawing.Size(90, 40);
            this.nudFirstIP.TabIndex = 528;
            this.nudFirstIP.ValueChanged += new System.EventHandler(this.nudFirstIP_ValueChanged);
            // 
            // FormUDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(689, 655);
            this.ControlBox = false;
            this.Controls.Add(this.lblSubTimer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboxIsLoopbackOn);
            this.Controls.Add(this.nudThirdIP);
            this.Controls.Add(this.nudSecondIP);
            this.Controls.Add(this.nudFirstIP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSerialMonitor);
            this.Controls.Add(this.btnNetworkCPL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboxUp);
            this.Controls.Add(this.lblNoAdapter);
            this.Controls.Add(this.lblHostname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboxNets);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNetworkHelp);
            this.Controls.Add(this.btnUDPOff);
            this.Controls.Add(this.btnSendSubnet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pboxSendSteer);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUDP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ethernet Configuration";
            this.Load += new System.EventHandler(this.FormUDp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxSendSteer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Label lblNetworkHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tboxNets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Label lblNoAdapter;
        private System.Windows.Forms.CheckBox cboxUp;
        private System.Windows.Forms.PictureBox pboxSendSteer;
        private System.Windows.Forms.Button btnSendSubnet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNetworkCPL;
        private System.Windows.Forms.Button btnSerialMonitor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUDPOff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private NudlessNumericUpDown nudFirstIP;
        private NudlessNumericUpDown nudSecondIP;
        private NudlessNumericUpDown nudThirdIP;
        private System.Windows.Forms.CheckBox cboxIsLoopbackOn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSubTimer;
    }
}