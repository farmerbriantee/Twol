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
            this.bthOK = new System.Windows.Forms.Button();
            this.btnOuterInner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bthOK
            // 
            this.bthOK.BackColor = System.Drawing.Color.Transparent;
            this.bthOK.BackgroundImage = global::Twol.Properties.Resources.OK64;
            this.bthOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bthOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bthOK.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.bthOK.FlatAppearance.BorderSize = 0;
            this.bthOK.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.bthOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.bthOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bthOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bthOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bthOK.Location = new System.Drawing.Point(44, 9);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(52, 38);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // btnOuterInner
            // 
            this.btnOuterInner.BackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.BackgroundImage = global::Twol.Properties.Resources.Help;
            this.btnOuterInner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOuterInner.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnOuterInner.FlatAppearance.BorderSize = 0;
            this.btnOuterInner.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnOuterInner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOuterInner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOuterInner.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnOuterInner.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOuterInner.Location = new System.Drawing.Point(133, 2);
            this.btnOuterInner.Name = "btnOuterInner";
            this.btnOuterInner.Size = new System.Drawing.Size(93, 54);
            this.btnOuterInner.TabIndex = 538;
            this.btnOuterInner.UseVisualStyleBackColor = false;
            this.btnOuterInner.Click += new System.EventHandler(this.btnOuterInner_Click);
            // 
            // FormToolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(229, 56);
            this.ControlBox = false;
            this.Controls.Add(this.bthOK);
            this.Controls.Add(this.btnOuterInner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolControl_FormClosing);
            this.Load += new System.EventHandler(this.FormToolControl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormToolControl_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bthOK;
        private System.Windows.Forms.Button btnOuterInner;
    }
}