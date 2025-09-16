namespace Jewelry
{
    partial class Import_Invoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExitImportInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.btnReturnImportInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnExitImportInvoice);
            this.panel1.Controls.Add(this.btnReturnImportInvoice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 110);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1436, 99);
            this.panel2.TabIndex = 4;
            // 
            // btnExitImportInvoice
            // 
            this.btnExitImportInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExitImportInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExitImportInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExitImportInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExitImportInvoice.FillColor = System.Drawing.Color.White;
            this.btnExitImportInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExitImportInvoice.ForeColor = System.Drawing.Color.White;
            this.btnExitImportInvoice.Image = global::Jewelry.Properties.Resources.Exit;
            this.btnExitImportInvoice.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExitImportInvoice.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExitImportInvoice.Location = new System.Drawing.Point(1374, 3);
            this.btnExitImportInvoice.Name = "btnExitImportInvoice";
            this.btnExitImportInvoice.Size = new System.Drawing.Size(56, 41);
            this.btnExitImportInvoice.TabIndex = 3;
            // 
            // btnReturnImportInvoice
            // 
            this.btnReturnImportInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReturnImportInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReturnImportInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReturnImportInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReturnImportInvoice.FillColor = System.Drawing.Color.White;
            this.btnReturnImportInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReturnImportInvoice.ForeColor = System.Drawing.Color.White;
            this.btnReturnImportInvoice.Image = global::Jewelry.Properties.Resources.Return;
            this.btnReturnImportInvoice.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnReturnImportInvoice.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReturnImportInvoice.Location = new System.Drawing.Point(3, 17);
            this.btnReturnImportInvoice.Name = "btnReturnImportInvoice";
            this.btnReturnImportInvoice.Size = new System.Drawing.Size(50, 36);
            this.btnReturnImportInvoice.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("EB Garamond Medium", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(129)))));
            this.label1.Location = new System.Drawing.Point(534, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import Invoice";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1440, 98);
            this.panel3.TabIndex = 5;
            // 
            // Import_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Import_Invoice";
            this.Text = "WareHousecs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnExitImportInvoice;
        private Guna.UI2.WinForms.Guna2Button btnReturnImportInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}