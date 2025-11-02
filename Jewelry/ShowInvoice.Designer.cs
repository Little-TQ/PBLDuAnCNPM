namespace Jewelry
{
    partial class ShowInvoice
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
            this.guna2HtmlLabel16 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlshowinvoice = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel16
            // 
            this.guna2HtmlLabel16.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel16.Font = new System.Drawing.Font("EB Garamond SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(124)))));
            this.guna2HtmlLabel16.Location = new System.Drawing.Point(83, 12);
            this.guna2HtmlLabel16.Name = "guna2HtmlLabel16";
            this.guna2HtmlLabel16.Size = new System.Drawing.Size(92, 45);
            this.guna2HtmlLabel16.TabIndex = 66;
            this.guna2HtmlLabel16.Text = "Invoice ";
            // 
            // pnlshowinvoice
            // 
            this.pnlshowinvoice.Location = new System.Drawing.Point(94, 63);
            this.pnlshowinvoice.Name = "pnlshowinvoice";
            this.pnlshowinvoice.Size = new System.Drawing.Size(956, 890);
            this.pnlshowinvoice.TabIndex = 67;
            // 
            // ShowInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 977);
            this.Controls.Add(this.pnlshowinvoice);
            this.Controls.Add(this.guna2HtmlLabel16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowInvoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel16;
        private System.Windows.Forms.Panel pnlshowinvoice;
    }
}