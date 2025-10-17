namespace Twol
{
    partial class FormUDPMonitor
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
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.textBoxRcv = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLog = new System.Windows.Forms.Button();
            this.btnLogNMEA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 0;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::Twol.Properties.Resources.OK64;
            this.btnSerialCancel.Location = new System.Drawing.Point(385, 232);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(65, 54);
            this.btnSerialCancel.TabIndex = 71;
            this.btnSerialCancel.UseVisualStyleBackColor = true;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // textBoxRcv
            // 
            this.textBoxRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRcv.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRcv.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRcv.Location = new System.Drawing.Point(6, 31);
            this.textBoxRcv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRcv.Multiline = true;
            this.textBoxRcv.Name = "textBoxRcv";
            this.textBoxRcv.ReadOnly = true;
            this.textBoxRcv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRcv.Size = new System.Drawing.Size(437, 194);
            this.textBoxRcv.TabIndex = 539;
            this.textBoxRcv.WordWrap = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::Twol.Properties.Resources.Trash;
            this.btnClear.Location = new System.Drawing.Point(6, 233);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 53);
            this.btnClear.TabIndex = 543;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSteerAngle
            // 
            this.lblSteerAngle.AutoSize = true;
            this.lblSteerAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblSteerAngle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteerAngle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSteerAngle.Location = new System.Drawing.Point(15, 8);
            this.lblSteerAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteerAngle.Name = "lblSteerAngle";
            this.lblSteerAngle.Size = new System.Drawing.Size(44, 18);
            this.lblSteerAngle.TabIndex = 545;
            this.lblSteerAngle.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(100, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 546;
            this.label1.Text = "IP Address : Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(310, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 547;
            this.label2.Text = "PGN";
            // 
            // timer1
            // 
            this.timer1.Interval = 333;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.BackColor = System.Drawing.Color.LightGreen;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Image = global::Twol.Properties.Resources.LogNMEA;
            this.btnLog.Location = new System.Drawing.Point(240, 231);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(109, 54);
            this.btnLog.TabIndex = 548;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnLogNMEA
            // 
            this.btnLogNMEA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogNMEA.BackColor = System.Drawing.Color.Transparent;
            this.btnLogNMEA.FlatAppearance.BorderSize = 0;
            this.btnLogNMEA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogNMEA.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogNMEA.Image = global::Twol.Properties.Resources.Nmea;
            this.btnLogNMEA.Location = new System.Drawing.Point(95, 233);
            this.btnLogNMEA.Name = "btnLogNMEA";
            this.btnLogNMEA.Size = new System.Drawing.Size(109, 54);
            this.btnLogNMEA.TabIndex = 549;
            this.btnLogNMEA.UseVisualStyleBackColor = false;
            this.btnLogNMEA.Click += new System.EventHandler(this.btnLogNMEA_Click);
            // 
            // FormUDPMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(456, 291);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogNMEA);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSteerAngle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.textBoxRcv);
            this.Controls.Add(this.btnSerialCancel);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(465, 307);
            this.Name = "FormUDPMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UDP Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUDPMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormUDp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.TextBox textBoxRcv;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnLogNMEA;
    }
}