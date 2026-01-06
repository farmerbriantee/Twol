namespace Twol
{
    partial class FormToolManual
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnToolLeft = new System.Windows.Forms.Button();
            this.btnToolRight = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnToolLeft);
            this.flowLayoutPanel1.Controls.Add(this.btnZero);
            this.flowLayoutPanel1.Controls.Add(this.btnToolRight);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-1, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 56);
            this.flowLayoutPanel1.TabIndex = 542;
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
            this.btnToolLeft.Location = new System.Drawing.Point(3, 3);
            this.btnToolLeft.Name = "btnToolLeft";
            this.btnToolLeft.Size = new System.Drawing.Size(74, 49);
            this.btnToolLeft.TabIndex = 543;
            this.btnToolLeft.UseVisualStyleBackColor = false;
            this.btnToolLeft.Click += new System.EventHandler(this.btnToolLeft_Click);
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
            this.btnToolRight.Location = new System.Drawing.Point(163, 3);
            this.btnToolRight.Name = "btnToolRight";
            this.btnToolRight.Size = new System.Drawing.Size(74, 49);
            this.btnToolRight.TabIndex = 542;
            this.btnToolRight.UseVisualStyleBackColor = false;
            this.btnToolRight.Click += new System.EventHandler(this.btnToolRight_Click);
            // 
            // btnZero
            // 
            this.btnZero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZero.BackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZero.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnZero.Image = global::Twol.Properties.Resources.SteerZero;
            this.btnZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZero.Location = new System.Drawing.Point(83, 3);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(74, 49);
            this.btnZero.TabIndex = 544;
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // FormToolManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(251, 75);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolManual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolManual_FormClosing);
            this.Load += new System.EventHandler(this.FormToolManual_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormToolManual_MouseDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportLines;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnToolRight;
        private System.Windows.Forms.Button btnToolLeft;
        private System.Windows.Forms.Button btnZero;
    }
}