namespace Jewelry
{
    partial class frmEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExitEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.btnReturnEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mstNEmployee = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wareHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainerEmployee = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mstNEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnExitEmployee);
            this.panel1.Controls.Add(this.btnReturnEmployee);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 110);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(9, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1436, 120);
            this.panel2.TabIndex = 4;
            // 
            // btnExitEmployee
            // 
            this.btnExitEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExitEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExitEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExitEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExitEmployee.FillColor = System.Drawing.Color.White;
            this.btnExitEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExitEmployee.ForeColor = System.Drawing.Color.White;
            this.btnExitEmployee.Image = global::Jewelry.Properties.Resources.Exit;
            this.btnExitEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExitEmployee.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExitEmployee.Location = new System.Drawing.Point(1374, 3);
            this.btnExitEmployee.Name = "btnExitEmployee";
            this.btnExitEmployee.Size = new System.Drawing.Size(56, 41);
            this.btnExitEmployee.TabIndex = 3;
            // 
            // btnReturnEmployee
            // 
            this.btnReturnEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReturnEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReturnEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReturnEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReturnEmployee.FillColor = System.Drawing.Color.White;
            this.btnReturnEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReturnEmployee.ForeColor = System.Drawing.Color.White;
            this.btnReturnEmployee.Image = global::Jewelry.Properties.Resources.Return;
            this.btnReturnEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnReturnEmployee.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReturnEmployee.Location = new System.Drawing.Point(3, 17);
            this.btnReturnEmployee.Name = "btnReturnEmployee";
            this.btnReturnEmployee.Size = new System.Drawing.Size(50, 36);
            this.btnReturnEmployee.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("EB Garamond Medium", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(534, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "  Arpels Jewelry";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.mstNEmployee);
            this.panel3.Location = new System.Drawing.Point(3, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1440, 103);
            this.panel3.TabIndex = 6;
            // 
            // mstNEmployee
            // 
            this.mstNEmployee.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mstNEmployee.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mstNEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.InformationToolStripMenuItem,
            this.SalaryToolStripMenuItem,
            this.scheduleToolStripMenuItem});
            this.mstNEmployee.Location = new System.Drawing.Point(0, 0);
            this.mstNEmployee.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.mstNEmployee.Name = "mstNEmployee";
            this.mstNEmployee.Padding = new System.Windows.Forms.Padding(10, 30, 0, 30);
            this.mstNEmployee.Size = new System.Drawing.Size(1438, 99);
            this.mstNEmployee.TabIndex = 6;
            this.mstNEmployee.Text = "mstNavigionAccount";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.homeToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.overviewToolStripMenuItem1,
            this.productToolStripMenuItem1,
            this.customerToolStripMenuItem1,
            this.employeeToolStripMenuItem1,
            this.wareHouseToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.homeToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.Image")));
            this.homeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Padding = new System.Windows.Forms.Padding(110, 0, 110, 0);
            this.homeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(334, 39);
            this.homeToolStripMenuItem.Text = " Home";
            this.homeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 40);
            this.toolStripMenuItem1.Text = "Account";
            // 
            // overviewToolStripMenuItem1
            // 
            this.overviewToolStripMenuItem1.Name = "overviewToolStripMenuItem1";
            this.overviewToolStripMenuItem1.Size = new System.Drawing.Size(238, 40);
            this.overviewToolStripMenuItem1.Text = "Overview";
            // 
            // productToolStripMenuItem1
            // 
            this.productToolStripMenuItem1.Name = "productToolStripMenuItem1";
            this.productToolStripMenuItem1.Size = new System.Drawing.Size(238, 40);
            this.productToolStripMenuItem1.Text = "Product";
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(238, 40);
            this.customerToolStripMenuItem1.Text = "Customer";
            // 
            // employeeToolStripMenuItem1
            // 
            this.employeeToolStripMenuItem1.Name = "employeeToolStripMenuItem1";
            this.employeeToolStripMenuItem1.Size = new System.Drawing.Size(238, 40);
            this.employeeToolStripMenuItem1.Text = "Employee";
            // 
            // wareHouseToolStripMenuItem
            // 
            this.wareHouseToolStripMenuItem.Name = "wareHouseToolStripMenuItem";
            this.wareHouseToolStripMenuItem.Size = new System.Drawing.Size(238, 40);
            this.wareHouseToolStripMenuItem.Text = "WareHouse";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(238, 40);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // InformationToolStripMenuItem
            // 
            this.InformationToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
            this.InformationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(110, 0, 110, 0);
            this.InformationToolStripMenuItem.Size = new System.Drawing.Size(378, 39);
            this.InformationToolStripMenuItem.Text = "Information";
            this.InformationToolStripMenuItem.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // SalaryToolStripMenuItem
            // 
            this.SalaryToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryToolStripMenuItem.Name = "SalaryToolStripMenuItem";
            this.SalaryToolStripMenuItem.Padding = new System.Windows.Forms.Padding(110, 0, 110, 0);
            this.SalaryToolStripMenuItem.Size = new System.Drawing.Size(310, 39);
            this.SalaryToolStripMenuItem.Text = "Salary";
            this.SalaryToolStripMenuItem.Click += new System.EventHandler(this.SalaryToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(110, 0, 110, 0);
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(349, 39);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // pnlContainerEmployee
            // 
            this.pnlContainerEmployee.Location = new System.Drawing.Point(3, 217);
            this.pnlContainerEmployee.Name = "pnlContainerEmployee";
            this.pnlContainerEmployee.Size = new System.Drawing.Size(1439, 805);
            this.pnlContainerEmployee.TabIndex = 7;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Controls.Add(this.pnlContainerEmployee);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.mstNEmployee.ResumeLayout(false);
            this.mstNEmployee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnExitEmployee;
        private Guna.UI2.WinForms.Guna2Button btnReturnEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip mstNEmployee;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wareHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalaryToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContainerEmployee;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
    }
}