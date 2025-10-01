namespace Jewelry.Account
{
    partial class Provide_Permission
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
            this.dataGridViewPermission = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnViewPermission = new Guna.UI2.WinForms.Guna2Button();
            this.btnSavePermission = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchPermission = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermission)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPermission
            // 
            this.dataGridViewPermission.AllowUserToAddRows = false;
            this.dataGridViewPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPermission.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPermission.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPermission.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPermission.Location = new System.Drawing.Point(99, 319);
            this.dataGridViewPermission.Name = "dataGridViewPermission";
            this.dataGridViewPermission.RowHeadersVisible = false;
            this.dataGridViewPermission.RowHeadersWidth = 51;
            this.dataGridViewPermission.RowTemplate.Height = 24;
            this.dataGridViewPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPermission.Size = new System.Drawing.Size(1229, 273);
            this.dataGridViewPermission.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.btnViewPermission);
            this.panel3.Controls.Add(this.btnSavePermission);
            this.panel3.Controls.Add(this.txtSearchPermission);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1437, 102);
            this.panel3.TabIndex = 6;
            // 
            // btnViewPermission
            // 
            this.btnViewPermission.BackColor = System.Drawing.Color.White;
            this.btnViewPermission.BorderRadius = 12;
            this.btnViewPermission.BorderThickness = 1;
            this.btnViewPermission.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewPermission.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewPermission.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewPermission.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewPermission.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewPermission.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewPermission.ForeColor = System.Drawing.Color.White;
            this.btnViewPermission.Image = global::Jewelry.Properties.Resources.View;
            this.btnViewPermission.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnViewPermission.ImageSize = new System.Drawing.Size(50, 50);
            this.btnViewPermission.Location = new System.Drawing.Point(1292, 21);
            this.btnViewPermission.Name = "btnViewPermission";
            this.btnViewPermission.PressedColor = System.Drawing.Color.LightGreen;
            this.btnViewPermission.Size = new System.Drawing.Size(50, 50);
            this.btnViewPermission.TabIndex = 4;
            this.btnViewPermission.Click += new System.EventHandler(this.btnViewPermission_Click);
            // 
            // btnSavePermission
            // 
            this.btnSavePermission.BackColor = System.Drawing.Color.White;
            this.btnSavePermission.BorderRadius = 12;
            this.btnSavePermission.BorderThickness = 1;
            this.btnSavePermission.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSavePermission.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSavePermission.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSavePermission.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSavePermission.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSavePermission.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSavePermission.ForeColor = System.Drawing.Color.White;
            this.btnSavePermission.Image = global::Jewelry.Properties.Resources.Save;
            this.btnSavePermission.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnSavePermission.ImageSize = new System.Drawing.Size(50, 50);
            this.btnSavePermission.Location = new System.Drawing.Point(1194, 21);
            this.btnSavePermission.Name = "btnSavePermission";
            this.btnSavePermission.PressedColor = System.Drawing.Color.LightGreen;
            this.btnSavePermission.Size = new System.Drawing.Size(50, 50);
            this.btnSavePermission.TabIndex = 1;
            this.btnSavePermission.Click += new System.EventHandler(this.btnSavePermission_Click);
            // 
            // txtSearchPermission
            // 
            this.txtSearchPermission.BorderColor = System.Drawing.Color.Gray;
            this.txtSearchPermission.BorderRadius = 20;
            this.txtSearchPermission.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchPermission.DefaultText = "";
            this.txtSearchPermission.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchPermission.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchPermission.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchPermission.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchPermission.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchPermission.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchPermission.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchPermission.IconLeft = global::Jewelry.Properties.Resources.Search;
            this.txtSearchPermission.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSearchPermission.Location = new System.Drawing.Point(53, 21);
            this.txtSearchPermission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchPermission.Name = "txtSearchPermission";
            this.txtSearchPermission.PlaceholderText = "";
            this.txtSearchPermission.SelectedText = "";
            this.txtSearchPermission.Size = new System.Drawing.Size(468, 45);
            this.txtSearchPermission.TabIndex = 0;
            // 
            // Provide_Permission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewPermission);
            this.Controls.Add(this.panel3);
            this.Name = "Provide_Permission";
            this.Size = new System.Drawing.Size(1437, 807);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermission)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPermission;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnViewPermission;
        private Guna.UI2.WinForms.Guna2Button btnSavePermission;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchPermission;
    }
}
