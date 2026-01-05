namespace Twol
{
    partial class FormToolControl
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
            this.bthOK = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnOuterInner = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnToolRight = new System.Windows.Forms.Button();
            this.btnToolLeft = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bthOK
            // 
            this.bthOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImage = global::Twol.Properties.Resources.OK64;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(3, 3);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(53, 41);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnOuterInner
            // 
            this.btnOuterInner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOuterInner.BackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnOuterInner.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOuterInner.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOuterInner.Image = global::Twol.Properties.Resources.TramOuter;
            this.btnOuterInner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOuterInner.Location = new System.Drawing.Point(3, 50);
            this.btnOuterInner.Name = "btnOuterInner";
            this.btnOuterInner.Size = new System.Drawing.Size(53, 61);
            this.btnOuterInner.TabIndex = 538;
            this.btnOuterInner.UseVisualStyleBackColor = false;
            this.btnOuterInner.Click += new System.EventHandler(this.btnOuterInner_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.bthOK);
            this.flowLayoutPanel1.Controls.Add(this.btnOuterInner);
            this.flowLayoutPanel1.Controls.Add(this.btnToolRight);
            this.flowLayoutPanel1.Controls.Add(this.btnToolLeft);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(60, 260);
            this.flowLayoutPanel1.TabIndex = 542;
            // 
            // btnToolRight
            // 
            this.btnToolRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToolRight.BackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnToolRight.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToolRight.Image = global::Twol.Properties.Resources.ArrowGrnRight;
            this.btnToolRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToolRight.Location = new System.Drawing.Point(3, 117);
            this.btnToolRight.Name = "btnToolRight";
            this.btnToolRight.Size = new System.Drawing.Size(53, 61);
            this.btnToolRight.TabIndex = 542;
            this.btnToolRight.UseVisualStyleBackColor = false;
            // 
            // btnToolLeft
            // 
            this.btnToolLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToolLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnToolLeft.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToolLeft.Image = global::Twol.Properties.Resources.ArrowGrnLeft;
            this.btnToolLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToolLeft.Location = new System.Drawing.Point(3, 184);
            this.btnToolLeft.Name = "btnToolLeft";
            this.btnToolLeft.Size = new System.Drawing.Size(53, 61);
            this.btnToolLeft.TabIndex = 543;
            this.btnToolLeft.UseVisualStyleBackColor = false;
            // 
            // FormToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(60, 289);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolPathRec_FormClosing);
            this.Load += new System.EventHandler(this.FormToolPathRec_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormToolPathRec_MouseDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bthOK;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOuterInner;
        private System.Windows.Forms.Button btnExportLines;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnToolRight;
        private System.Windows.Forms.Button btnToolLeft;
    }
}