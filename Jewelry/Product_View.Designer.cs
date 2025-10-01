namespace Jewelry
{
    partial class Product_View
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2HtmlLabel13 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewProduct = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnEditProperty = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.property1 = new Jewelry.FolderProduct.Property();
            this.product1 = new Jewelry.FolderProduct.Product();
            this.navbar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditProperty)).BeginInit();
            this.panelDGV.SuspendLayout();
            this.SuspendLayout();
            // 
            // navbar
            // 
            this.navbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.navbar.Controls.Add(this.panel3);
            this.navbar.Controls.Add(this.panel1);
            this.navbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbar.Location = new System.Drawing.Point(0, 0);
            this.navbar.Name = "navbar";
            this.navbar.Size = new System.Drawing.Size(1440, 222);
            this.navbar.TabIndex = 2;
            this.navbar.Paint += new System.Windows.Forms.PaintEventHandler(this.navbar_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.guna2HtmlLabel13);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1440, 119);
            this.panel3.TabIndex = 56;
            // 
            // guna2HtmlLabel13
            // 
            this.guna2HtmlLabel13.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel13.Font = new System.Drawing.Font("EB Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.guna2HtmlLabel13.Location = new System.Drawing.Point(444, 73);
            this.guna2HtmlLabel13.Name = "guna2HtmlLabel13";
            this.guna2HtmlLabel13.Size = new System.Drawing.Size(569, 31);
            this.guna2HtmlLabel13.TabIndex = 50;
            this.guna2HtmlLabel13.Text = "Manage categories, materials, colors, gender specifications, and collections";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(1, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1436, 99);
            this.panel4.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("EB Garamond", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(608, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(268, 96);
            this.label11.TabIndex = 0;
            this.label11.Text = "Product";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnViewProduct);
            this.panel1.Controls.Add(this.btnEditProperty);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.cbGender);
            this.panel1.Controls.Add(this.cbMaterial);
            this.panel1.Controls.Add(this.cbColor);
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 100);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(11, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 47);
            this.panel2.TabIndex = 46;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(159, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.overviewToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.productToolStripMenuItem,
            this.invoiceToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.homeToolStripMenuItem.Font = new System.Drawing.Font("Sora", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(129, 39);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // overviewToolStripMenuItem
            // 
            this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            this.overviewToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.overviewToolStripMenuItem.Text = "Overview";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.paymentToolStripMenuItem.Text = "Payment";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.invoiceToolStripMenuItem.Text = "Invoice";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // btnViewProduct
            // 
            this.btnViewProduct.Image = global::Jewelry.Properties.Resources.View;
            this.btnViewProduct.ImageRotate = 0F;
            this.btnViewProduct.Location = new System.Drawing.Point(1136, 41);
            this.btnViewProduct.Name = "btnViewProduct";
            this.btnViewProduct.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnViewProduct.Size = new System.Drawing.Size(30, 29);
            this.btnViewProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnViewProduct.TabIndex = 45;
            this.btnViewProduct.TabStop = false;
            this.btnViewProduct.Click += new System.EventHandler(this.btnViewProduct_Click);
            // 
            // btnEditProperty
            // 
            this.btnEditProperty.Image = global::Jewelry.Properties.Resources.Edit;
            this.btnEditProperty.ImageRotate = 0F;
            this.btnEditProperty.Location = new System.Drawing.Point(1186, 41);
            this.btnEditProperty.Name = "btnEditProperty";
            this.btnEditProperty.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEditProperty.Size = new System.Drawing.Size(30, 29);
            this.btnEditProperty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEditProperty.TabIndex = 44;
            this.btnEditProperty.TabStop = false;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Sora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "All",
            "Silver",
            "Gold 10k",
            "Gold 18k",
            "Gold 24k"});
            this.cbCategory.Location = new System.Drawing.Point(387, 32);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(126, 38);
            this.cbCategory.TabIndex = 6;
            this.cbCategory.Text = "Category";
            // 
            // cbGender
            // 
            this.cbGender.Font = new System.Drawing.Font("Sora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "All",
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(971, 32);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(126, 38);
            this.cbGender.TabIndex = 5;
            this.cbGender.Text = "Gender";
            // 
            // cbMaterial
            // 
            this.cbMaterial.Font = new System.Drawing.Font("Sora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Items.AddRange(new object[] {
            "All",
            "Silver",
            "Gold 10k",
            "Gold 18k",
            "Gold 24k"});
            this.cbMaterial.Location = new System.Drawing.Point(584, 32);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(126, 38);
            this.cbMaterial.TabIndex = 2;
            this.cbMaterial.Text = "Material";
            // 
            // cbColor
            // 
            this.cbColor.Font = new System.Drawing.Font("Sora", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "All",
            "Sliver",
            "Gold",
            "Pink Gold"});
            this.cbColor.Location = new System.Drawing.Point(779, 32);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(126, 38);
            this.cbColor.TabIndex = 3;
            this.cbColor.Text = "Color";
            // 
            // panelDGV
            // 
            this.panelDGV.Controls.Add(this.property1);
            this.panelDGV.Controls.Add(this.product1);
            this.panelDGV.Location = new System.Drawing.Point(0, 228);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Size = new System.Drawing.Size(1440, 796);
            this.panelDGV.TabIndex = 3;
            // 
            // property1
            // 
            this.property1.BackColor = System.Drawing.Color.White;
            this.property1.Location = new System.Drawing.Point(344, -100);
            this.property1.Name = "property1";
            this.property1.Size = new System.Drawing.Size(770, 620);
            this.property1.TabIndex = 1;
            // 
            // product1
            // 
            this.product1.BackColor = System.Drawing.Color.White;
            this.product1.Location = new System.Drawing.Point(0, 0);
            this.product1.Name = "product1";
            this.product1.Size = new System.Drawing.Size(1440, 802);
            this.product1.TabIndex = 0;
            // 
            // Product_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Controls.Add(this.panelDGV);
            this.Controls.Add(this.navbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Product_View";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product_View";
            this.Load += new System.EventHandler(this.Product_View_Load);
            this.navbar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditProperty)).EndInit();
            this.panelDGV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navbar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDGV;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.ComboBox cbColor;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnEditProperty;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnViewProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private FolderProduct.Product product1;
        private FolderProduct.Property property1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
    }
}