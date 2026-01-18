namespace Twol
{
    partial class FormTrackFilter
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
            this.btnToolOuter = new System.Windows.Forms.Button();
            this.btnToolInner = new System.Windows.Forms.Button();
            this.btnBnd = new System.Windows.Forms.Button();
            this.btnField = new System.Windows.Forms.Button();
            this.btnHideShow = new System.Windows.Forms.Button();
            this.bthOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToolOuter
            // 
            this.btnToolOuter.BackColor = System.Drawing.Color.Transparent;
            this.btnToolOuter.BackgroundImage = global::Twol.Properties.Resources.FilterOuterToolLines;
            this.btnToolOuter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToolOuter.FlatAppearance.BorderSize = 0;
            this.btnToolOuter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolOuter.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToolOuter.Location = new System.Drawing.Point(3, 312);
            this.btnToolOuter.Name = "btnToolOuter";
            this.btnToolOuter.Size = new System.Drawing.Size(42, 42);
            this.btnToolOuter.TabIndex = 543;
            this.btnToolOuter.UseVisualStyleBackColor = false;
            this.btnToolOuter.Click += new System.EventHandler(this.btnToolOuter_Click);
            // 
            // btnToolInner
            // 
            this.btnToolInner.BackColor = System.Drawing.Color.Transparent;
            this.btnToolInner.BackgroundImage = global::Twol.Properties.Resources.FilterInnerToolLines;
            this.btnToolInner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToolInner.FlatAppearance.BorderSize = 0;
            this.btnToolInner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolInner.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToolInner.Location = new System.Drawing.Point(3, 253);
            this.btnToolInner.Name = "btnToolInner";
            this.btnToolInner.Size = new System.Drawing.Size(42, 42);
            this.btnToolInner.TabIndex = 542;
            this.btnToolInner.UseVisualStyleBackColor = false;
            this.btnToolInner.Click += new System.EventHandler(this.btnToolInner_Click);
            // 
            // btnBnd
            // 
            this.btnBnd.BackColor = System.Drawing.Color.Transparent;
            this.btnBnd.BackgroundImage = global::Twol.Properties.Resources.FilterOuterLines;
            this.btnBnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBnd.FlatAppearance.BorderSize = 0;
            this.btnBnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBnd.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBnd.Location = new System.Drawing.Point(3, 194);
            this.btnBnd.Name = "btnBnd";
            this.btnBnd.Size = new System.Drawing.Size(42, 42);
            this.btnBnd.TabIndex = 541;
            this.btnBnd.UseVisualStyleBackColor = false;
            this.btnBnd.Click += new System.EventHandler(this.btnBnd_Click);
            // 
            // btnField
            // 
            this.btnField.BackColor = System.Drawing.Color.Transparent;
            this.btnField.BackgroundImage = global::Twol.Properties.Resources.FilterInnerLines;
            this.btnField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnField.FlatAppearance.BorderSize = 0;
            this.btnField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnField.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnField.Location = new System.Drawing.Point(3, 135);
            this.btnField.Name = "btnField";
            this.btnField.Size = new System.Drawing.Size(42, 42);
            this.btnField.TabIndex = 540;
            this.btnField.UseVisualStyleBackColor = false;
            this.btnField.Click += new System.EventHandler(this.btnField_Click);
            // 
            // btnHideShow
            // 
            this.btnHideShow.BackColor = System.Drawing.Color.Transparent;
            this.btnHideShow.FlatAppearance.BorderSize = 0;
            this.btnHideShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideShow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideShow.Image = global::Twol.Properties.Resources.ABLinesHideShow;
            this.btnHideShow.Location = new System.Drawing.Point(3, 76);
            this.btnHideShow.Name = "btnHideShow";
            this.btnHideShow.Size = new System.Drawing.Size(42, 42);
            this.btnHideShow.TabIndex = 539;
            this.btnHideShow.UseVisualStyleBackColor = false;
            this.btnHideShow.Click += new System.EventHandler(this.btnHideShow_Click);
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
            this.bthOK.Location = new System.Drawing.Point(9, 31);
            this.bthOK.Name = "bthOK";
            this.bthOK.Size = new System.Drawing.Size(31, 26);
            this.bthOK.TabIndex = 1;
            this.bthOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bthOK.UseVisualStyleBackColor = false;
            this.bthOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // FormTrackFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(48, 243);
            this.ControlBox = false;
            this.Controls.Add(this.btnToolOuter);
            this.Controls.Add(this.btnToolInner);
            this.Controls.Add(this.btnBnd);
            this.Controls.Add(this.btnField);
            this.Controls.Add(this.btnHideShow);
            this.Controls.Add(this.bthOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTrackFilter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormToolControl_FormClosing);
            this.Load += new System.EventHandler(this.FormToolControl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormToolControl_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bthOK;
        private System.Windows.Forms.Button btnHideShow;
        private System.Windows.Forms.Button btnField;
        private System.Windows.Forms.Button btnBnd;
        private System.Windows.Forms.Button btnToolInner;
        private System.Windows.Forms.Button btnToolOuter;
    }
}