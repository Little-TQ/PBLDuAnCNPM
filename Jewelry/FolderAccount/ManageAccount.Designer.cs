namespace Jewelry.Account
{
    partial class ManageAccount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteAccount = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchAccount = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridViewAccount = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.btnAddAccount);
            this.panel3.Controls.Add(this.btnViewAccount);
            this.panel3.Controls.Add(this.btnDeleteAccount);
            this.panel3.Controls.Add(this.txtSearchAccount);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1437, 99);
            this.panel3.TabIndex = 4;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BorderColor = System.Drawing.Color.Gray;
            this.btnAddAccount.BorderRadius = 18;
            this.btnAddAccount.BorderThickness = 1;
            this.btnAddAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddAccount.FillColor = System.Drawing.Color.White;
            this.btnAddAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddAccount.ForeColor = System.Drawing.Color.Gray;
            this.btnAddAccount.Image = global::Jewelry.Properties.Resources.plus;
            this.btnAddAccount.Location = new System.Drawing.Point(667, 28);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(153, 38);
            this.btnAddAccount.TabIndex = 5;
            this.btnAddAccount.Text = "Thêm Tài Khoản";
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click_1);
            // 
            // btnViewAccount
            // 
            this.btnViewAccount.BackColor = System.Drawing.Color.White;
            this.btnViewAccount.BorderRadius = 12;
            this.btnViewAccount.BorderThickness = 1;
            this.btnViewAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewAccount.ForeColor = System.Drawing.Color.White;
            this.btnViewAccount.Image = global::Jewelry.Properties.Resources.View;
            this.btnViewAccount.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnViewAccount.ImageSize = new System.Drawing.Size(50, 50);
            this.btnViewAccount.Location = new System.Drawing.Point(1292, 21);
            this.btnViewAccount.Name = "btnViewAccount";
            this.btnViewAccount.PressedColor = System.Drawing.Color.LightGreen;
            this.btnViewAccount.Size = new System.Drawing.Size(50, 50);
            this.btnViewAccount.TabIndex = 4;
            this.btnViewAccount.Click += new System.EventHandler(this.btnViewAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.BackColor = System.Drawing.Color.White;
            this.btnDeleteAccount.BorderRadius = 12;
            this.btnDeleteAccount.BorderThickness = 1;
            this.btnDeleteAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteAccount.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAccount.Image = global::Jewelry.Properties.Resources.Delete;
            this.btnDeleteAccount.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnDeleteAccount.ImageSize = new System.Drawing.Size(50, 50);
            this.btnDeleteAccount.Location = new System.Drawing.Point(1187, 21);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.PressedColor = System.Drawing.Color.LightGreen;
            this.btnDeleteAccount.Size = new System.Drawing.Size(50, 50);
            this.btnDeleteAccount.TabIndex = 3;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click_1);
            // 
            // txtSearchAccount
            // 
            this.txtSearchAccount.BorderColor = System.Drawing.Color.Gray;
            this.txtSearchAccount.BorderRadius = 20;
            this.txtSearchAccount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchAccount.DefaultText = "";
            this.txtSearchAccount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchAccount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchAccount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchAccount.IconLeft = global::Jewelry.Properties.Resources.Search;
            this.txtSearchAccount.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSearchAccount.Location = new System.Drawing.Point(53, 21);
            this.txtSearchAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchAccount.Name = "txtSearchAccount";
            this.txtSearchAccount.PlaceholderText = "";
            this.txtSearchAccount.SelectedText = "";
            this.txtSearchAccount.Size = new System.Drawing.Size(468, 45);
            this.txtSearchAccount.TabIndex = 0;
            // 
            // dataGridViewAccount
            // 
            this.dataGridViewAccount.AllowUserToAddRows = false;
            this.dataGridViewAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAccount.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAccount.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAccount.Location = new System.Drawing.Point(262, 309);
            this.dataGridViewAccount.Name = "dataGridViewAccount";
            this.dataGridViewAccount.RowHeadersVisible = false;
            this.dataGridViewAccount.RowHeadersWidth = 51;
            this.dataGridViewAccount.RowTemplate.Height = 24;
            this.dataGridViewAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAccount.Size = new System.Drawing.Size(899, 273);
            this.dataGridViewAccount.TabIndex = 5;
            // 
            // ManageAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewAccount);
            this.Controls.Add(this.panel3);
            this.Name = "ManageAccount";
            this.Size = new System.Drawing.Size(1437, 807);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnAddAccount;
        private Guna.UI2.WinForms.Guna2Button btnViewAccount;
        private Guna.UI2.WinForms.Guna2Button btnDeleteAccount;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchAccount;
        private System.Windows.Forms.DataGridView dataGridViewAccount;
    }
}
