namespace Jewelry.Overview
{
    partial class Revenu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBestSelling = new System.Windows.Forms.GroupBox();
            this.txtRevenuMonth = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRevenuWeek = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartRevenu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbBestSelling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.guna2Button2);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.guna2DateTimePicker2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(69, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 243);
            this.panel1.TabIndex = 1;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.White;
            this.guna2Button2.BorderColor = System.Drawing.Color.IndianRed;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.Enabled = false;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Firebrick;
            this.guna2Button2.Location = new System.Drawing.Point(337, 180);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.PressedColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Size = new System.Drawing.Size(149, 50);
            this.guna2Button2.TabIndex = 5;
            this.guna2Button2.Text = "Xem theo tháng ";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Enabled = false;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.guna2Button1.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(90, 180);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Size = new System.Drawing.Size(139, 50);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Xem theo tuần";
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.BorderColor = System.Drawing.SystemColors.Control;
            this.guna2DateTimePicker2.BorderThickness = 1;
            this.guna2DateTimePicker2.Checked = true;
            this.guna2DateTimePicker2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2DateTimePicker2.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DateTimePicker2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(90, 101);
            this.guna2DateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(418, 60);
            this.guna2DateTimePicker2.TabIndex = 3;
            this.guna2DateTimePicker2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2DateTimePicker2.Value = new System.DateTime(2025, 9, 14, 1, 42, 59, 565);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 73);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(218, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Lịch";
            // 
            // grbBestSelling
            // 
            this.grbBestSelling.Controls.Add(this.txtRevenuMonth);
            this.grbBestSelling.Controls.Add(this.txtRevenuWeek);
            this.grbBestSelling.Controls.Add(this.label3);
            this.grbBestSelling.Controls.Add(this.label2);
            this.grbBestSelling.Font = new System.Drawing.Font("Sora SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBestSelling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.grbBestSelling.Location = new System.Drawing.Point(737, 17);
            this.grbBestSelling.Name = "grbBestSelling";
            this.grbBestSelling.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grbBestSelling.Size = new System.Drawing.Size(600, 239);
            this.grbBestSelling.TabIndex = 2;
            this.grbBestSelling.TabStop = false;
            this.grbBestSelling.Text = "Total Revenu";
            // 
            // txtRevenuMonth
            // 
            this.txtRevenuMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRevenuMonth.DefaultText = "75.300.000 VNĐ";
            this.txtRevenuMonth.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRevenuMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRevenuMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRevenuMonth.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRevenuMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRevenuMonth.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevenuMonth.ForeColor = System.Drawing.Color.Gray;
            this.txtRevenuMonth.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRevenuMonth.Location = new System.Drawing.Point(368, 51);
            this.txtRevenuMonth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtRevenuMonth.Name = "txtRevenuMonth";
            this.txtRevenuMonth.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.txtRevenuMonth.PlaceholderText = "";
            this.txtRevenuMonth.SelectedText = "";
            this.txtRevenuMonth.Size = new System.Drawing.Size(163, 134);
            this.txtRevenuMonth.TabIndex = 7;
            this.txtRevenuMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRevenuWeek
            // 
            this.txtRevenuWeek.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRevenuWeek.DefaultText = "43.300.000 VNĐ";
            this.txtRevenuWeek.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRevenuWeek.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRevenuWeek.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRevenuWeek.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRevenuWeek.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRevenuWeek.Font = new System.Drawing.Font("Inter SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevenuWeek.ForeColor = System.Drawing.Color.Gray;
            this.txtRevenuWeek.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRevenuWeek.Location = new System.Drawing.Point(124, 51);
            this.txtRevenuWeek.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtRevenuWeek.Name = "txtRevenuWeek";
            this.txtRevenuWeek.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.txtRevenuWeek.PlaceholderText = "";
            this.txtRevenuWeek.SelectedText = "";
            this.txtRevenuWeek.Size = new System.Drawing.Size(163, 134);
            this.txtRevenuWeek.TabIndex = 6;
            this.txtRevenuWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRevenuWeek.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label3.Location = new System.Drawing.Point(406, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "MONTH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label2.Location = new System.Drawing.Point(173, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "WEEK";
            // 
            // chartRevenu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRevenu.Legends.Add(legend1);
            this.chartRevenu.Location = new System.Drawing.Point(69, 326);
            this.chartRevenu.Name = "chartRevenu";
            this.chartRevenu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenu.Series.Add(series1);
            this.chartRevenu.Size = new System.Drawing.Size(1224, 472);
            this.chartRevenu.TabIndex = 3;
            this.chartRevenu.Text = "chart1";
            this.chartRevenu.Click += new System.EventHandler(this.chartRevenu_Click);
            // 
            // Revenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartRevenu);
            this.Controls.Add(this.grbBestSelling);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Inter", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Revenu";
            this.Size = new System.Drawing.Size(1434, 812);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbBestSelling.ResumeLayout(false);
            this.grbBestSelling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbBestSelling;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenu;
        private Guna.UI2.WinForms.Guna2TextBox txtRevenuWeek;
        private Guna.UI2.WinForms.Guna2TextBox txtRevenuMonth;
    }
}
