namespace Twol
{
    partial class FormYesNo
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
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.btnSerialOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessage2
            // 
            this.lblMessage2.BackColor = System.Drawing.Color.Gainsboro;
            this.lblMessage2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.Location = new System.Drawing.Point(12, 9);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(734, 412);
            this.lblMessage2.TabIndex = 1;
            this.lblMessage2.Text = "Message 2";
            this.lblMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSerialOK
            // 
            this.btnSerialOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOK.BackColor = System.Drawing.Color.LightGreen;
            this.btnSerialOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSerialOK.FlatAppearance.BorderSize = 2;
            this.btnSerialOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSerialOK.Image = global::Twol.Properties.Resources.OK64;
            this.btnSerialOK.Location = new System.Drawing.Point(582, 309);
            this.btnSerialOK.Name = "btnSerialOK";
            this.btnSerialOK.Size = new System.Drawing.Size(146, 96);
            this.btnSerialOK.TabIndex = 96;
            this.btnSerialOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSerialOK.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::Twol.Properties.Resources.Cancel64;
            this.btnCancel.Location = new System.Drawing.Point(39, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 96);
            this.btnCancel.TabIndex = 97;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormYesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(758, 430);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSerialOK);
            this.Controls.Add(this.lblMessage2);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormYesNo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TWOL Message";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Button btnSerialOK;
        private System.Windows.Forms.Button btnCancel;
    }
}