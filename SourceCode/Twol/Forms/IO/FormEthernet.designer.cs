namespace Twol
{
    partial class FormEthernet
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
            this.cboxIsUDPOn = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboxIsUDPOn
            // 
            this.cboxIsUDPOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsUDPOn.BackColor = System.Drawing.Color.LightSalmon;
            this.cboxIsUDPOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsUDPOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.cboxIsUDPOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsUDPOn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsUDPOn.Location = new System.Drawing.Point(64, 65);
            this.cboxIsUDPOn.Name = "cboxIsUDPOn";
            this.cboxIsUDPOn.Size = new System.Drawing.Size(313, 61);
            this.cboxIsUDPOn.TabIndex = 92;
            this.cboxIsUDPOn.Text = "Networking Is Off";
            this.cboxIsUDPOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsUDPOn.UseVisualStyleBackColor = false;
            this.cboxIsUDPOn.Click += new System.EventHandler(this.cboxIsUDPOn_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::Twol.Properties.Resources.OK64;
            this.btnOK.Location = new System.Drawing.Point(448, 55);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 79);
            this.btnOK.TabIndex = 71;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormEthernet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 220);
            this.ControlBox = false;
            this.Controls.Add(this.cboxIsUDPOn);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEthernet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enable Networking";
            this.Load += new System.EventHandler(this.FormUDp_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cboxIsUDPOn;
    }
}