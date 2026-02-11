namespace Twol
{
    partial class FormGraphToolXTE
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.unoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPWM = new System.Windows.Forms.Label();
            this.btnGainUp = new System.Windows.Forms.Button();
            this.btnGainDown = new System.Windows.Forms.Button();
            this.btnGainAuto = new System.Windows.Forms.Button();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblXTE = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.unoChart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // unoChart
            // 
            this.unoChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unoChart.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            this.unoChart.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.unoChart.ChartAreas.Add(chartArea1);
            this.unoChart.Location = new System.Drawing.Point(3, 12);
            this.unoChart.Margin = new System.Windows.Forms.Padding(0);
            this.unoChart.Name = "unoChart";
            this.unoChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.OrangeRed;
            series1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "S";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.Lime;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "PWM";
            this.unoChart.Series.Add(series1);
            this.unoChart.Series.Add(series2);
            this.unoChart.Size = new System.Drawing.Size(440, 193);
            this.unoChart.TabIndex = 180;
            this.unoChart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(206, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 195;
            this.label1.Text = "XTE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPWM
            // 
            this.lblPWM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPWM.AutoSize = true;
            this.lblPWM.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblPWM.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWM.ForeColor = System.Drawing.Color.Yellow;
            this.lblPWM.Location = new System.Drawing.Point(97, 200);
            this.lblPWM.Name = "lblPWM";
            this.lblPWM.Size = new System.Drawing.Size(85, 29);
            this.lblPWM.TabIndex = 194;
            this.lblPWM.Text = "label5";
            this.lblPWM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGainUp
            // 
            this.btnGainUp.BackColor = System.Drawing.Color.Transparent;
            this.btnGainUp.FlatAppearance.BorderSize = 2;
            this.btnGainUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGainUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGainUp.ForeColor = System.Drawing.Color.White;
            this.btnGainUp.Location = new System.Drawing.Point(3, 12);
            this.btnGainUp.Name = "btnGainUp";
            this.btnGainUp.Size = new System.Drawing.Size(48, 55);
            this.btnGainUp.TabIndex = 197;
            this.btnGainUp.Text = "+";
            this.btnGainUp.UseVisualStyleBackColor = false;
            this.btnGainUp.Click += new System.EventHandler(this.btnGainUp_Click);
            // 
            // btnGainDown
            // 
            this.btnGainDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGainDown.BackColor = System.Drawing.Color.Transparent;
            this.btnGainDown.FlatAppearance.BorderSize = 2;
            this.btnGainDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGainDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGainDown.ForeColor = System.Drawing.Color.White;
            this.btnGainDown.Location = new System.Drawing.Point(3, 137);
            this.btnGainDown.Name = "btnGainDown";
            this.btnGainDown.Size = new System.Drawing.Size(48, 55);
            this.btnGainDown.TabIndex = 198;
            this.btnGainDown.Text = "-";
            this.btnGainDown.UseVisualStyleBackColor = false;
            this.btnGainDown.Click += new System.EventHandler(this.btnGainDown_Click);
            // 
            // btnGainAuto
            // 
            this.btnGainAuto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGainAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnGainAuto.FlatAppearance.BorderSize = 2;
            this.btnGainAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGainAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGainAuto.ForeColor = System.Drawing.Color.White;
            this.btnGainAuto.Location = new System.Drawing.Point(3, 71);
            this.btnGainAuto.Name = "btnGainAuto";
            this.btnGainAuto.Size = new System.Drawing.Size(48, 55);
            this.btnGainAuto.TabIndex = 199;
            this.btnGainAuto.Text = "A";
            this.btnGainAuto.UseVisualStyleBackColor = false;
            this.btnGainAuto.Click += new System.EventHandler(this.btnGainAuto_Click);
            // 
            // lblMin
            // 
            this.lblMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMin.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblMin.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.ForeColor = System.Drawing.Color.Lime;
            this.lblMin.Location = new System.Drawing.Point(351, 205);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(100, 23);
            this.lblMin.TabIndex = 200;
            this.lblMin.Text = "10";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMax.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblMax.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.ForeColor = System.Drawing.Color.Lime;
            this.lblMax.Location = new System.Drawing.Point(351, 1);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(100, 23);
            this.lblMax.TabIndex = 201;
            this.lblMax.Text = "Auto";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlText;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(433, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 33);
            this.label2.TabIndex = 202;
            this.label2.Text = "<";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblXTE
            // 
            this.lblXTE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXTE.AutoSize = true;
            this.lblXTE.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblXTE.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXTE.ForeColor = System.Drawing.Color.Lime;
            this.lblXTE.Location = new System.Drawing.Point(270, 200);
            this.lblXTE.Name = "lblXTE";
            this.lblXTE.Size = new System.Drawing.Size(75, 29);
            this.lblXTE.TabIndex = 203;
            this.lblXTE.Text = "PWM";
            this.lblXTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoEllipsis = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(31, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 204;
            this.label4.Text = "PWM:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormGraphToolXTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(460, 231);
            this.Controls.Add(this.lblXTE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPWM);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.btnGainAuto);
            this.Controls.Add(this.btnGainDown);
            this.Controls.Add(this.btnGainUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unoChart);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(30, 30);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(457, 255);
            this.Name = "FormGraphToolXTE";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool XTE Graph";
            this.Load += new System.EventHandler(this.FormGraphToolXTE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unoChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart unoChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPWM;
        private System.Windows.Forms.Button btnGainUp;
        private System.Windows.Forms.Button btnGainDown;
        private System.Windows.Forms.Button btnGainAuto;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblXTE;
        private System.Windows.Forms.Label label4;
    }
}