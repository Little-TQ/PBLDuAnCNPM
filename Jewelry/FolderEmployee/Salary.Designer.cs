namespace Jewelry.FolderEmployee
{
    partial class Salary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpSalaryView = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnEditSalaryEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewSalary = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchSalaryEmployee = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvSalaryView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.cbxRole);
            this.panel3.Controls.Add(this.dtpSalaryView);
            this.panel3.Controls.Add(this.btnEditSalaryEmployee);
            this.panel3.Controls.Add(this.btnViewSalary);
            this.panel3.Controls.Add(this.txtSearchSalaryEmployee);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1438, 99);
            this.panel3.TabIndex = 6;
            // 
            // cbxRole
            // 
            this.cbxRole.BackColor = System.Drawing.Color.Transparent;
            this.cbxRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbxRole.ItemHeight = 30;
            this.cbxRole.Location = new System.Drawing.Point(844, 30);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(156, 36);
            this.cbxRole.TabIndex = 21;
            this.cbxRole.SelectedIndexChanged += new System.EventHandler(this.cbxRole_SelectedIndexChanged);
            // 
            // dtpSalaryView
            // 
            this.dtpSalaryView.Checked = true;
            this.dtpSalaryView.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.dtpSalaryView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpSalaryView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpSalaryView.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalaryView.Location = new System.Drawing.Point(654, 30);
            this.dtpSalaryView.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpSalaryView.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSalaryView.Name = "dtpSalaryView";
            this.dtpSalaryView.Size = new System.Drawing.Size(132, 36);
            this.dtpSalaryView.TabIndex = 20;
            this.dtpSalaryView.Value = new System.DateTime(2025, 10, 9, 14, 22, 51, 122);
            this.dtpSalaryView.ValueChanged += new System.EventHandler(this.dtpSalaryView_ValueChanged);
            // 
            // btnEditSalaryEmployee
            // 
            this.btnEditSalaryEmployee.BackColor = System.Drawing.Color.White;
            this.btnEditSalaryEmployee.BorderRadius = 12;
            this.btnEditSalaryEmployee.BorderThickness = 1;
            this.btnEditSalaryEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditSalaryEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditSalaryEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditSalaryEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditSalaryEmployee.FillColor = System.Drawing.Color.Yellow;
            this.btnEditSalaryEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditSalaryEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEditSalaryEmployee.Image = global::Jewelry.Properties.Resources.Edit;
            this.btnEditSalaryEmployee.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnEditSalaryEmployee.ImageSize = new System.Drawing.Size(50, 50);
            this.btnEditSalaryEmployee.Location = new System.Drawing.Point(1190, 21);
            this.btnEditSalaryEmployee.Name = "btnEditSalaryEmployee";
            this.btnEditSalaryEmployee.PressedColor = System.Drawing.Color.Yellow;
            this.btnEditSalaryEmployee.Size = new System.Drawing.Size(50, 50);
            this.btnEditSalaryEmployee.TabIndex = 5;
            this.btnEditSalaryEmployee.Click += new System.EventHandler(this.btnEditSalaryEmployee_Click);
            // 
            // btnViewSalary
            // 
            this.btnViewSalary.BackColor = System.Drawing.Color.White;
            this.btnViewSalary.BorderRadius = 12;
            this.btnViewSalary.BorderThickness = 1;
            this.btnViewSalary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewSalary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewSalary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewSalary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewSalary.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewSalary.ForeColor = System.Drawing.Color.White;
            this.btnViewSalary.Image = global::Jewelry.Properties.Resources.View;
            this.btnViewSalary.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnViewSalary.ImageSize = new System.Drawing.Size(50, 50);
            this.btnViewSalary.Location = new System.Drawing.Point(1292, 21);
            this.btnViewSalary.Name = "btnViewSalary";
            this.btnViewSalary.PressedColor = System.Drawing.Color.LightGreen;
            this.btnViewSalary.Size = new System.Drawing.Size(50, 50);
            this.btnViewSalary.TabIndex = 4;
            this.btnViewSalary.Click += new System.EventHandler(this.btnViewSalary_Click);
            // 
            // txtSearchSalaryEmployee
            // 
            this.txtSearchSalaryEmployee.BorderColor = System.Drawing.Color.Gray;
            this.txtSearchSalaryEmployee.BorderRadius = 20;
            this.txtSearchSalaryEmployee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchSalaryEmployee.DefaultText = "";
            this.txtSearchSalaryEmployee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchSalaryEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchSalaryEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchSalaryEmployee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchSalaryEmployee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchSalaryEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchSalaryEmployee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchSalaryEmployee.IconLeft = global::Jewelry.Properties.Resources.Search;
            this.txtSearchSalaryEmployee.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSearchSalaryEmployee.Location = new System.Drawing.Point(53, 21);
            this.txtSearchSalaryEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchSalaryEmployee.Name = "txtSearchSalaryEmployee";
            this.txtSearchSalaryEmployee.PlaceholderText = "";
            this.txtSearchSalaryEmployee.SelectedText = "";
            this.txtSearchSalaryEmployee.Size = new System.Drawing.Size(468, 45);
            this.txtSearchSalaryEmployee.TabIndex = 0;
            this.txtSearchSalaryEmployee.TextChanged += new System.EventHandler(this.txtSearchSalaryEmployee_TextChanged);
            this.txtSearchSalaryEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchSalaryEmployee_KeyDown);
            // 
            // dgvSalaryView
            // 
            this.dgvSalaryView.AllowUserToAddRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSalaryView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Inter", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalaryView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSalaryView.ColumnHeadersHeight = 60;
            this.dgvSalaryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Inter", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalaryView.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSalaryView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalaryView.Location = new System.Drawing.Point(27, 118);
            this.dgvSalaryView.Name = "dgvSalaryView";
            this.dgvSalaryView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Inter", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalaryView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSalaryView.RowHeadersVisible = false;
            this.dgvSalaryView.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSalaryView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSalaryView.RowTemplate.Height = 50;
            this.dgvSalaryView.Size = new System.Drawing.Size(1358, 668);
            this.dgvSalaryView.TabIndex = 15;
            this.dgvSalaryView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalaryView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSalaryView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSalaryView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSalaryView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSalaryView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalaryView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalaryView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSalaryView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSalaryView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalaryView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSalaryView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSalaryView.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvSalaryView.ThemeStyle.ReadOnly = true;
            this.dgvSalaryView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalaryView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalaryView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalaryView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSalaryView.ThemeStyle.RowsStyle.Height = 50;
            this.dgvSalaryView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalaryView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSalaryView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalaryView_CellDoubleClick);
            // 
            // Salary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSalaryView);
            this.Controls.Add(this.panel3);
            this.Name = "Salary";
            this.Size = new System.Drawing.Size(1439, 805);
            this.Load += new System.EventHandler(this.Salary_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnViewSalary;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchSalaryEmployee;
        private Guna.UI2.WinForms.Guna2Button btnEditSalaryEmployee;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSalaryView;
        private Guna.UI2.WinForms.Guna2ComboBox cbxRole;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpSalaryView;
    }
}
