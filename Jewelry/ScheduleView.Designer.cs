namespace Jewelry
{
    partial class ScheduleView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchScheduleView = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbxRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpScheduleView = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgvScheduleView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnReturnSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduleView)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel1.Controls.Add(this.btnReturnSchedule);
            this.guna2Panel1.Controls.Add(this.txtSearchScheduleView);
            this.guna2Panel1.Controls.Add(this.cbxRole);
            this.guna2Panel1.Controls.Add(this.dtpScheduleView);
            this.guna2Panel1.Location = new System.Drawing.Point(1, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1438, 93);
            this.guna2Panel1.TabIndex = 23;
            // 
            // txtSearchScheduleView
            // 
            this.txtSearchScheduleView.BorderColor = System.Drawing.Color.Gray;
            this.txtSearchScheduleView.BorderRadius = 20;
            this.txtSearchScheduleView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchScheduleView.DefaultText = "";
            this.txtSearchScheduleView.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchScheduleView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchScheduleView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchScheduleView.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchScheduleView.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchScheduleView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchScheduleView.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchScheduleView.IconLeft = global::Jewelry.Properties.Resources.Search;
            this.txtSearchScheduleView.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSearchScheduleView.Location = new System.Drawing.Point(187, 24);
            this.txtSearchScheduleView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchScheduleView.Name = "txtSearchScheduleView";
            this.txtSearchScheduleView.PlaceholderText = "";
            this.txtSearchScheduleView.SelectedText = "";
            this.txtSearchScheduleView.Size = new System.Drawing.Size(468, 45);
            this.txtSearchScheduleView.TabIndex = 20;
            this.txtSearchScheduleView.TextChanged += new System.EventHandler(this.txtSearchScheduleView_TextChanged);
            this.txtSearchScheduleView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchScheduleView_KeyDown);
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
            this.cbxRole.Location = new System.Drawing.Point(1114, 33);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(156, 36);
            this.cbxRole.TabIndex = 19;
            this.cbxRole.SelectedIndexChanged += new System.EventHandler(this.cbxRole_SelectedIndexChanged);
            // 
            // dtpScheduleView
            // 
            this.dtpScheduleView.Checked = true;
            this.dtpScheduleView.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.dtpScheduleView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpScheduleView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpScheduleView.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpScheduleView.Location = new System.Drawing.Point(924, 33);
            this.dtpScheduleView.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpScheduleView.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpScheduleView.Name = "dtpScheduleView";
            this.dtpScheduleView.Size = new System.Drawing.Size(132, 36);
            this.dtpScheduleView.TabIndex = 18;
            this.dtpScheduleView.Value = new System.DateTime(2025, 10, 9, 14, 22, 51, 122);
            this.dtpScheduleView.ValueChanged += new System.EventHandler(this.dtpScheduleView_ValueChanged);
            // 
            // dgvScheduleView
            // 
            this.dgvScheduleView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvScheduleView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Inter", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScheduleView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScheduleView.ColumnHeadersHeight = 60;
            this.dgvScheduleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Inter", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScheduleView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScheduleView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvScheduleView.Location = new System.Drawing.Point(32, 145);
            this.dgvScheduleView.Name = "dgvScheduleView";
            this.dgvScheduleView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Inter", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScheduleView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvScheduleView.RowHeadersVisible = false;
            this.dgvScheduleView.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvScheduleView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvScheduleView.RowTemplate.Height = 50;
            this.dgvScheduleView.Size = new System.Drawing.Size(1374, 593);
            this.dgvScheduleView.TabIndex = 22;
            this.dgvScheduleView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScheduleView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvScheduleView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvScheduleView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvScheduleView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvScheduleView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvScheduleView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvScheduleView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvScheduleView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvScheduleView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScheduleView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvScheduleView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvScheduleView.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvScheduleView.ThemeStyle.ReadOnly = true;
            this.dgvScheduleView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScheduleView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvScheduleView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScheduleView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvScheduleView.ThemeStyle.RowsStyle.Height = 50;
            this.dgvScheduleView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvScheduleView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnReturnSchedule
            // 
            this.btnReturnSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReturnSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReturnSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReturnSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReturnSchedule.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturnSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReturnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnReturnSchedule.Image = global::Jewelry.Properties.Resources.Exit;
            this.btnReturnSchedule.ImageSize = new System.Drawing.Size(35, 35);
            this.btnReturnSchedule.Location = new System.Drawing.Point(3, 9);
            this.btnReturnSchedule.Name = "btnReturnSchedule";
            this.btnReturnSchedule.Size = new System.Drawing.Size(64, 36);
            this.btnReturnSchedule.TabIndex = 21;
            this.btnReturnSchedule.Click += new System.EventHandler(this.btnReturnSchedule_Click);
            // 
            // ScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 805);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvScheduleView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScheduleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleView";
            this.Load += new System.EventHandler(this.ScheduleView_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduleView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchScheduleView;
        private Guna.UI2.WinForms.Guna2ComboBox cbxRole;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpScheduleView;
        private Guna.UI2.WinForms.Guna2DataGridView dgvScheduleView;
        private Guna.UI2.WinForms.Guna2Button btnReturnSchedule;
    }
}