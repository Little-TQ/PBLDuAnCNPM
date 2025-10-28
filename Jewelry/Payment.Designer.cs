namespace Jewelry
{
    partial class Payment_Sale_Select
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
            this.navbar = new System.Windows.Forms.Panel();
            this.mstNEmployee = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wareHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.sale1 = new Jewelry.Payment.Sale();
            this.preOrder1 = new Jewelry.Payment.PreOrder();
            this.navbar.SuspendLayout();
            this.mstNEmployee.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // navbar
            // 
            this.navbar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.navbar.Controls.Add(this.mstNEmployee);
            this.navbar.Controls.Add(this.panel7);
            this.navbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbar.Location = new System.Drawing.Point(0, 0);
            this.navbar.Name = "navbar";
            this.navbar.Size = new System.Drawing.Size(1440, 222);
            this.navbar.TabIndex = 1;
            this.navbar.Paint += new System.Windows.Forms.PaintEventHandler(this.navbar_Paint);
            // 
            // mstNEmployee
            // 
            this.mstNEmployee.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mstNEmployee.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mstNEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.saleToolStripMenuItem,
            this.SalaryToolStripMenuItem,
            this.scheduleToolStripMenuItem});
            this.mstNEmployee.Location = new System.Drawing.Point(0, 110);
            this.mstNEmployee.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.mstNEmployee.Name = "mstNEmployee";
            this.mstNEmployee.Padding = new System.Windows.Forms.Padding(10, 20, 0, 8);
            this.mstNEmployee.Size = new System.Drawing.Size(1440, 102);
            this.mstNEmployee.TabIndex = 11;
            this.mstNEmployee.Text = "mstNavigionAccount";
            this.mstNEmployee.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mstNEmployee_ItemClicked);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.homeToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.overviewToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.productToolStripMenuItem1,
            this.customerToolStripMenuItem1,
            this.wareHouseToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.dashBoardToolStripMenuItem});
            this.homeToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeToolStripMenuItem.Image = global::Jewelry.Properties.Resources.Bar;
            this.homeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.homeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.homeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(361, 74);
            this.homeToolStripMenuItem.Text = " Home";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 40);
            this.toolStripMenuItem1.Text = "Account";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // overviewToolStripMenuItem1
            // 
            this.overviewToolStripMenuItem1.Name = "overviewToolStripMenuItem1";
            this.overviewToolStripMenuItem1.Size = new System.Drawing.Size(232, 40);
            this.overviewToolStripMenuItem1.Text = "Overview";
            this.overviewToolStripMenuItem1.Click += new System.EventHandler(this.overviewToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 40);
            this.toolStripMenuItem2.Text = "Employee";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // productToolStripMenuItem1
            // 
            this.productToolStripMenuItem1.Name = "productToolStripMenuItem1";
            this.productToolStripMenuItem1.Size = new System.Drawing.Size(232, 40);
            this.productToolStripMenuItem1.Text = "Product";
            this.productToolStripMenuItem1.Click += new System.EventHandler(this.productToolStripMenuItem1_Click);
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(232, 40);
            this.customerToolStripMenuItem1.Text = "Customer";
            this.customerToolStripMenuItem1.Click += new System.EventHandler(this.customerToolStripMenuItem1_Click);
            // 
            // wareHouseToolStripMenuItem
            // 
            this.wareHouseToolStripMenuItem.Name = "wareHouseToolStripMenuItem";
            this.wareHouseToolStripMenuItem.Size = new System.Drawing.Size(232, 40);
            this.wareHouseToolStripMenuItem.Text = "Invoice";
            this.wareHouseToolStripMenuItem.Click += new System.EventHandler(this.wareHouseToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(232, 40);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // dashBoardToolStripMenuItem
            // 
            this.dashBoardToolStripMenuItem.Name = "dashBoardToolStripMenuItem";
            this.dashBoardToolStripMenuItem.Size = new System.Drawing.Size(232, 40);
            this.dashBoardToolStripMenuItem.Text = "DashBoard";
            this.dashBoardToolStripMenuItem.Click += new System.EventHandler(this.dashBoardToolStripMenuItem_Click);
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(269, 74);
            this.saleToolStripMenuItem.Text = "Sale";
            this.saleToolStripMenuItem.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // SalaryToolStripMenuItem
            // 
            this.SalaryToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryToolStripMenuItem.Name = "SalaryToolStripMenuItem";
            this.SalaryToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.SalaryToolStripMenuItem.Size = new System.Drawing.Size(356, 74);
            this.SalaryToolStripMenuItem.Text = "Repurchase";
            this.SalaryToolStripMenuItem.Click += new System.EventHandler(this.SalaryToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(337, 74);
            this.scheduleToolStripMenuItem.Text = "Pre-Order";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1440, 110);
            this.panel7.TabIndex = 9;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(1, 109);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1436, 99);
            this.panel8.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("EB Garamond", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(555, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 96);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payment";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("EB Garamond Medium", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(124)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(40, 12);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(179, 74);
            this.guna2HtmlLabel6.TabIndex = 5;
            this.guna2HtmlLabel6.Text = "Payment";
            // 
            // sale1
            // 
            this.sale1.Location = new System.Drawing.Point(0, 215);
            this.sale1.Name = "sale1";
            this.sale1.Size = new System.Drawing.Size(1437, 849);
            this.sale1.TabIndex = 2;
            // 
            // preOrder1
            // 
            this.preOrder1.BackColor = System.Drawing.Color.White;
            this.preOrder1.Location = new System.Drawing.Point(3, 215);
            this.preOrder1.Name = "preOrder1";
            this.preOrder1.Size = new System.Drawing.Size(1437, 849);
            this.preOrder1.TabIndex = 3;
            // 
            // Payment_Sale_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Controls.Add(this.preOrder1);
            this.Controls.Add(this.sale1);
            this.Controls.Add(this.navbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Payment_Sale_Select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment_Sale_Select";
            this.Load += new System.EventHandler(this.Payment_Sale_Select_Load);
            this.navbar.ResumeLayout(false);
            this.navbar.PerformLayout();
            this.mstNEmployee.ResumeLayout(false);
            this.mstNEmployee.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel navbar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private System.Windows.Forms.MenuStrip mstNEmployee;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wareHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private Payment.Sale sale1;
        private Payment.PreOrder preOrder1;
    }
}