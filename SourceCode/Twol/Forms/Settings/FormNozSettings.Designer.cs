namespace Twol
{
    partial class FormNozSettings
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
            this.bntOK = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRateSet1 = new System.Windows.Forms.Label();
            this.lblRateSet2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZeroVolume = new System.Windows.Forms.Button();
            this.lblAppliedVolume = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudRateAlarmPercent = new Twol.NudlessNumericUpDown();
            this.nudNudge = new Twol.NudlessNumericUpDown();
            this.nudTankVolume = new Twol.NudlessNumericUpDown();
            this.nudZeroVolume = new Twol.NudlessNumericUpDown();
            this.nudRateSet2 = new Twol.NudlessNumericUpDown();
            this.nudSprayMinPressure = new Twol.NudlessNumericUpDown();
            this.nudRateSet1 = new Twol.NudlessNumericUpDown();
            this.SuspendLayout();
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.FlatAppearance.BorderSize = 0;
            this.bntOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::Twol.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(574, 347);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(166, 65);
            this.bntOK.TabIndex = 0;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(29, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 28);
            this.label10.TabIndex = 590;
            this.label10.Text = "Min Pressure";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRateSet1
            // 
            this.lblRateSet1.BackColor = System.Drawing.Color.Transparent;
            this.lblRateSet1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateSet1.ForeColor = System.Drawing.Color.White;
            this.lblRateSet1.Location = new System.Drawing.Point(551, 90);
            this.lblRateSet1.Name = "lblRateSet1";
            this.lblRateSet1.Size = new System.Drawing.Size(166, 28);
            this.lblRateSet1.TabIndex = 578;
            this.lblRateSet1.Text = " Gal / Acre";
            this.lblRateSet1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRateSet2
            // 
            this.lblRateSet2.BackColor = System.Drawing.Color.Transparent;
            this.lblRateSet2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateSet2.ForeColor = System.Drawing.Color.White;
            this.lblRateSet2.Location = new System.Drawing.Point(551, 230);
            this.lblRateSet2.Name = "lblRateSet2";
            this.lblRateSet2.Size = new System.Drawing.Size(166, 28);
            this.lblRateSet2.TabIndex = 612;
            this.lblRateSet2.Text = " Gal / Acre";
            this.lblRateSet2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(497, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 33);
            this.label2.TabIndex = 613;
            this.label2.Text = "1:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(497, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 33);
            this.label3.TabIndex = 614;
            this.label3.Text = "2:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(276, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 28);
            this.label1.TabIndex = 618;
            this.label1.Text = "Zero Applied";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZeroVolume
            // 
            this.btnZeroVolume.BackColor = System.Drawing.Color.White;
            this.btnZeroVolume.BackgroundImage = global::Twol.Properties.Resources.SteerZero;
            this.btnZeroVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZeroVolume.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnZeroVolume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeroVolume.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroVolume.ForeColor = System.Drawing.Color.White;
            this.btnZeroVolume.Location = new System.Drawing.Point(285, 313);
            this.btnZeroVolume.Name = "btnZeroVolume";
            this.btnZeroVolume.Size = new System.Drawing.Size(149, 65);
            this.btnZeroVolume.TabIndex = 617;
            this.btnZeroVolume.UseVisualStyleBackColor = false;
            this.btnZeroVolume.Click += new System.EventHandler(this.btnZeroVolume_Click);
            // 
            // lblAppliedVolume
            // 
            this.lblAppliedVolume.BackColor = System.Drawing.Color.Transparent;
            this.lblAppliedVolume.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliedVolume.ForeColor = System.Drawing.Color.White;
            this.lblAppliedVolume.Location = new System.Drawing.Point(276, 237);
            this.lblAppliedVolume.Name = "lblAppliedVolume";
            this.lblAppliedVolume.Size = new System.Drawing.Size(166, 28);
            this.lblAppliedVolume.TabIndex = 616;
            this.lblAppliedVolume.Text = "Applied";
            this.lblAppliedVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(276, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 28);
            this.label4.TabIndex = 620;
            this.label4.Text = "Tank Volume";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 28);
            this.label5.TabIndex = 622;
            this.label5.Text = "Rate Nudge";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(29, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 28);
            this.label6.TabIndex = 624;
            this.label6.Text = "Rate Alarm %";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudRateAlarmPercent
            // 
            this.nudRateAlarmPercent.Location = new System.Drawing.Point(37, 169);
            this.nudRateAlarmPercent.Minimum = 1D;
            this.nudRateAlarmPercent.Name = "nudRateAlarmPercent";
            this.nudRateAlarmPercent.Size = new System.Drawing.Size(150, 65);
            this.nudRateAlarmPercent.TabIndex = 625;
            this.nudRateAlarmPercent.ValueChanged += new System.EventHandler(this.nudRateAlarmPercent_ValueChanged);
            // 
            // nudNudge
            // 
            this.nudNudge.DecimalPlaces = 1;
            this.nudNudge.Location = new System.Drawing.Point(37, 313);
            this.nudNudge.Maximum = 30D;
            this.nudNudge.Minimum = 0.1D;
            this.nudNudge.Name = "nudNudge";
            this.nudNudge.Size = new System.Drawing.Size(150, 65);
            this.nudNudge.TabIndex = 623;
            this.nudNudge.ValueChanged += new System.EventHandler(this.nudNudge_ValueChanged);
            // 
            // nudTankVolume
            // 
            this.nudTankVolume.Location = new System.Drawing.Point(259, 31);
            this.nudTankVolume.Maximum = 100000D;
            this.nudTankVolume.Name = "nudTankVolume";
            this.nudTankVolume.Size = new System.Drawing.Size(201, 65);
            this.nudTankVolume.TabIndex = 619;
            this.nudTankVolume.ValueChanged += new System.EventHandler(this.nudTankVolume_ValueChanged);
            // 
            // nudZeroVolume
            // 
            this.nudZeroVolume.Location = new System.Drawing.Point(259, 172);
            this.nudZeroVolume.Maximum = 100000D;
            this.nudZeroVolume.Name = "nudZeroVolume";
            this.nudZeroVolume.Size = new System.Drawing.Size(201, 65);
            this.nudZeroVolume.TabIndex = 615;
            this.nudZeroVolume.ValueChanged += new System.EventHandler(this.nudZeroVolume_ValueChanged);
            // 
            // nudRateSet2
            // 
            this.nudRateSet2.DecimalPlaces = 1;
            this.nudRateSet2.Location = new System.Drawing.Point(541, 169);
            this.nudRateSet2.Maximum = 2000D;
            this.nudRateSet2.Minimum = 3D;
            this.nudRateSet2.Name = "nudSprayRateSet2";
            this.nudRateSet2.Size = new System.Drawing.Size(186, 65);
            this.nudRateSet2.TabIndex = 611;
            this.nudRateSet2.ValueChanged += new System.EventHandler(this.nudSprayRateSet2_ValueChanged);
            // 
            // nudSprayMinPressure
            // 
            this.nudSprayMinPressure.Location = new System.Drawing.Point(37, 31);
            this.nudSprayMinPressure.Minimum = 1D;
            this.nudSprayMinPressure.Name = "nudSprayMinPressure";
            this.nudSprayMinPressure.Size = new System.Drawing.Size(150, 65);
            this.nudSprayMinPressure.TabIndex = 591;
            this.nudSprayMinPressure.ValueChanged += new System.EventHandler(this.nudSprayMinPressure_ValueChanged);
            // 
            // nudRateSet1
            // 
            this.nudRateSet1.DecimalPlaces = 1;
            this.nudRateSet1.Location = new System.Drawing.Point(541, 29);
            this.nudRateSet1.Maximum = 2000D;
            this.nudRateSet1.Minimum = 3D;
            this.nudRateSet1.Name = "nudSprayRateSet1";
            this.nudRateSet1.Size = new System.Drawing.Size(186, 65);
            this.nudRateSet1.TabIndex = 577;
            this.nudRateSet1.ValueChanged += new System.EventHandler(this.nudSprayRateSet1_ValueChanged);
            // 
            // FormNozSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(752, 424);
            this.ControlBox = false;
            this.Controls.Add(this.nudRateAlarmPercent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudNudge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudTankVolume);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZeroVolume);
            this.Controls.Add(this.nudZeroVolume);
            this.Controls.Add(this.lblAppliedVolume);
            this.Controls.Add(this.nudRateSet2);
            this.Controls.Add(this.lblRateSet2);
            this.Controls.Add(this.nudSprayMinPressure);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudRateSet1);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.lblRateSet1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNozSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nozzle Configuration";
            this.Load += new System.EventHandler(this.FormDisplaySettings_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bntOK;
        private NudlessNumericUpDown nudSprayMinPressure;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRateSet1;
        private NudlessNumericUpDown nudRateSet1;
        private NudlessNumericUpDown nudRateSet2;
        private System.Windows.Forms.Label lblRateSet2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnZeroVolume;
        private NudlessNumericUpDown nudZeroVolume;
        private System.Windows.Forms.Label lblAppliedVolume;
        private NudlessNumericUpDown nudTankVolume;
        private System.Windows.Forms.Label label4;
        private NudlessNumericUpDown nudNudge;
        private System.Windows.Forms.Label label5;
        private NudlessNumericUpDown nudRateAlarmPercent;
        private System.Windows.Forms.Label label6;
    }
}