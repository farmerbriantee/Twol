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
            this.btnToolLeft = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnToolRight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToolLeft
            // 
            this.btnToolLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnToolLeft.FlatAppearance.BorderSize = 0;
            this.btnToolLeft.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnToolLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToolLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToolLeft.Image = global::Twol.Properties.Resources.ArrowLeft;
            this.btnToolLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToolLeft.Location = new System.Drawing.Point(31, 2);
            this.btnToolLeft.Name = "btnToolLeft";
            this.btnToolLeft.Size = new System.Drawing.Size(74, 52);
            this.btnToolLeft.TabIndex = 543;
            this.btnToolLeft.UseVisualStyleBackColor = false;
            this.btnToolLeft.Click += new System.EventHandler(this.btnToolLeft_Click);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnZero.FlatAppearance.BorderSize = 0;
            this.btnZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZero.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnZero.Image = global::Twol.Properties.Resources.SteerZero;
            this.btnZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZero.Location = new System.Drawing.Point(114, 2);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(74, 52);
            this.btnZero.TabIndex = 544;
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnToolRight
            // 
            this.btnToolRight.BackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnToolRight.FlatAppearance.BorderSize = 0;
            this.btnToolRight.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnToolRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToolRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToolRight.Image = global::Twol.Properties.Resources.ArrowRight;
            this.btnToolRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnToolRight.Location = new System.Drawing.Point(197, 2);
            this.btnToolRight.Name = "btnToolRight";
            this.btnToolRight.Size = new System.Drawing.Size(74, 52);
            this.btnToolRight.TabIndex = 542;
            this.btnToolRight.UseVisualStyleBackColor = false;
            this.btnToolRight.Click += new System.EventHandler(this.btnToolRight_Click);
            // 
            // FormToolManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(272, 56);
            this.ControlBox = false;
            this.Controls.Add(this.btnToolLeft);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnToolRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolManual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolManual_FormClosing);
            this.Load += new System.EventHandler(this.FormToolManual_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormToolManual_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnToolRight;
        private System.Windows.Forms.Button btnToolLeft;
        private System.Windows.Forms.Button btnZero;
    }
}