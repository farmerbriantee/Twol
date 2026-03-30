namespace Twol
{
    partial class FormSettingsTree
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.treeViewUser = new System.Windows.Forms.TreeView();
            this.treeViewVehicle = new System.Windows.Forms.TreeView();
            this.treeViewTool = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // treeViewUser
            // 
            this.treeViewUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewUser.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewUser.Location = new System.Drawing.Point(3, 3);
            this.treeViewUser.Name = "treeViewUser";
            this.treeViewUser.Size = new System.Drawing.Size(374, 706);
            this.treeViewUser.TabIndex = 0;
            // 
            // treeViewVehicle
            // 
            this.treeViewVehicle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewVehicle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewVehicle.Location = new System.Drawing.Point(383, 3);
            this.treeViewVehicle.Name = "treeViewVehicle";
            this.treeViewVehicle.Size = new System.Drawing.Size(483, 706);
            this.treeViewVehicle.TabIndex = 1;
            // 
            // treeViewTool
            // 
            this.treeViewTool.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTool.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewTool.Location = new System.Drawing.Point(872, 3);
            this.treeViewTool.Name = "treeViewTool";
            this.treeViewTool.Size = new System.Drawing.Size(484, 706);
            this.treeViewTool.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.Controls.Add(this.treeViewUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeViewTool, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeViewVehicle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1359, 712);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // FormSettingsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1359, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(30, 30);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(457, 255);
            this.Name = "FormSettingsTree";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XML Settings";
            this.Load += new System.EventHandler(this.FormSettingsTree_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeViewUser;
        private System.Windows.Forms.TreeView treeViewVehicle;
        private System.Windows.Forms.TreeView treeViewTool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}