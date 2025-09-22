namespace Jewelry
{
    partial class Payment
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.mstNOverview = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wareHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SoldProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RevenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.mstNOverview.SuspendLayout();
            this.SuspendLayout();
            // 
            // navbar
            // 
            this.navbar.BackColor = System.Drawing.Color.White;
            this.navbar.Controls.Add(this.guna2HtmlLabel1);
            this.navbar.Controls.Add(this.panel1);
            this.navbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbar.Location = new System.Drawing.Point(0, 0);
            this.navbar.Name = "navbar";
            this.navbar.Size = new System.Drawing.Size(1440, 222);
            this.navbar.TabIndex = 3;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("EB Garamond Medium", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(124)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(594, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(212, 88);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Payment";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mstNOverview);
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 100);
            this.panel1.TabIndex = 2;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Jewelry.Properties.Resources.Product_General;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 219);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(1440, 817);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            // 
            // mstNOverview
            // 
            this.mstNOverview.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mstNOverview.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mstNOverview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.SoldProductToolStripMenuItem,
            this.RevenuToolStripMenuItem,
            this.preOrderToolStripMenuItem});
            this.mstNOverview.Location = new System.Drawing.Point(0, 0);
            this.mstNOverview.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.mstNOverview.Name = "mstNOverview";
            this.mstNOverview.Padding = new System.Windows.Forms.Padding(10, 15, 0, 5);
            this.mstNOverview.Size = new System.Drawing.Size(1438, 94);
            this.mstNOverview.TabIndex = 5;
            this.mstNOverview.Text = "mstNavigionAccount";
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
            this.updateToolStripMenuItem,
            this.paymentToolStripMenuItem});
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
            this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 40);
            this.toolStripMenuItem1.Text = "Account";
            // 
            // overviewToolStripMenuItem1
            // 
            this.overviewToolStripMenuItem1.Name = "overviewToolStripMenuItem1";
            this.overviewToolStripMenuItem1.Size = new System.Drawing.Size(224, 40);
            this.overviewToolStripMenuItem1.Text = "Overview";
            // 
            // productToolStripMenuItem1
            // 
            this.productToolStripMenuItem1.Name = "productToolStripMenuItem1";
            this.productToolStripMenuItem1.Size = new System.Drawing.Size(224, 40);
            this.productToolStripMenuItem1.Text = "Product";
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(224, 40);
            this.customerToolStripMenuItem1.Text = "Customer";
            // 
            // employeeToolStripMenuItem1
            // 
            this.employeeToolStripMenuItem1.Name = "employeeToolStripMenuItem1";
            this.employeeToolStripMenuItem1.Size = new System.Drawing.Size(224, 40);
            this.employeeToolStripMenuItem1.Text = "Employee";
            // 
            // wareHouseToolStripMenuItem
            // 
            this.wareHouseToolStripMenuItem.Name = "wareHouseToolStripMenuItem";
            this.wareHouseToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.wareHouseToolStripMenuItem.Text = "Invoice";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // SoldProductToolStripMenuItem
            // 
            this.SoldProductToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoldProductToolStripMenuItem.Name = "SoldProductToolStripMenuItem";
            this.SoldProductToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.SoldProductToolStripMenuItem.Size = new System.Drawing.Size(269, 74);
            this.SoldProductToolStripMenuItem.Text = "Sale";
            this.SoldProductToolStripMenuItem.Click += new System.EventHandler(this.SoldProductToolStripMenuItem_Click);
            // 
            // RevenuToolStripMenuItem
            // 
            this.RevenuToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevenuToolStripMenuItem.Name = "RevenuToolStripMenuItem";
            this.RevenuToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.RevenuToolStripMenuItem.Size = new System.Drawing.Size(356, 74);
            this.RevenuToolStripMenuItem.Text = "Repurchase";
            // 
            // preOrderToolStripMenuItem
            // 
            this.preOrderToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preOrderToolStripMenuItem.Name = "preOrderToolStripMenuItem";
            this.preOrderToolStripMenuItem.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.preOrderToolStripMenuItem.Size = new System.Drawing.Size(337, 74);
            this.preOrderToolStripMenuItem.Text = "Pre-Order";
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.paymentToolStripMenuItem.Text = "Payment";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.navbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Payment";
            this.Text = "Payment";
            this.navbar.ResumeLayout(false);
            this.navbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.mstNOverview.ResumeLayout(false);
            this.mstNOverview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navbar;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.MenuStrip mstNOverview;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wareHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SoldProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RevenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preOrderToolStripMenuItem;
    }
}