using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Jewelry.BLL;
using Jewelry.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Jewelry
{
    public partial class UpdatePrice : Form
    {
        private UpdateBLL updateBLL = new UpdateBLL();
        private string currentMaterialId = "";
        private decimal currentPrice = 0;
        private decimal currentRepurchasePrice = 0;

        public UpdatePrice()
        {
            InitializeComponent();
        }

        private void UpdatePrice_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadMaterials();
            dtpUpdatePrice.Value = DateTime.Now;
            if (cbxMaterialUpdate.Items.Count > 0)
            {
                cbxMaterialUpdate.SelectedIndex = 0;
                currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();

                // Lúc này mới vẽ chart
                DrawPriceChart(currentMaterialId, dtpUpdatePrice.Value);

                // Load nốt phần còn lại
                LoadPriceHistoryByMaterial(currentMaterialId);
                UpdateStatistics(currentMaterialId);
            }
        }

        //Load danh sách chất liệu từ DB
        private void LoadMaterials()
        {
            try
            {
                DataTable materials = updateBLL.GetAllMaterials();
                cbxMaterialUpdate.DataSource = materials;
                cbxMaterialUpdate.DisplayMember = "NameMaterial";
                cbxMaterialUpdate.ValueMember = "idMaterial";

                cbxMaterialUpdate.SelectedIndex = -1; // chưa chọn gì ban đầu
                txtPricenow.Text = "0 VND";
                txtChange.Text = "0";
                txtRepurchaseNow.Text = "0 VND";
                txtChangeRepurchasePrice.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}");
            }
        }
        private void DrawPriceChart(string materialId, DateTime selectedDate)
        {
            try
            {
                // Lấy dữ liệu từ BLL
                DataTable chartData = updateBLL.GetDailyPriceChartData(materialId, selectedDate);

                if (chartData.Rows.Count == 0)
                {
                    // Vẽ biểu đồ rỗng
                    using (Graphics g = chartPanel.CreateGraphics())
                    {
                        g.Clear(Color.White);
                        g.DrawString("No data for selected date",
                            new Font("Segoe UI", 12),
                            Brushes.Black,
                            chartPanel.Width / 2 - 80,
                            chartPanel.Height / 2);
                    }
                    return;
                }

                // Vẽ biểu đồ
                DrawChart(chartData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart data: " + ex.Message);
            }
        }

        private void DrawChart(DataTable chartData)
        {
            using (Graphics g = chartPanel.CreateGraphics())
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Kích thước và margin
                int margin = 60;
                int chartWidth = chartPanel.Width - 2 * margin;
                int chartHeight = chartPanel.Height - 2 * margin;

                // Tìm giá trị lớn nhất để scale trục Y
                decimal maxPrice = 0;
                foreach (DataRow row in chartData.Rows)
                {
                    decimal Price = Convert.ToDecimal(row["SalePrice"]);
                    decimal Repurchase = Convert.ToDecimal(row["RepurchasePrice"]);
                    maxPrice = Math.Max(maxPrice, Math.Max(Price, Repurchase));
                }

                // Vẽ trục
                DrawAxes(g, margin, chartWidth, chartHeight, maxPrice);

                // Vẽ các cột
                DrawBars(g, chartData, margin, chartWidth, chartHeight, maxPrice);

                // Vẽ chú thích
                DrawLegend(g, margin, chartHeight, chartWidth);
            }
        }

        private void DrawAxes(Graphics g, int margin, int chartWidth, int chartHeight, decimal maxPrice)
        {
            Pen axisPen = new Pen(Color.Black, 2);
            Font labelFont = new Font("Segoe UI", 8);

            // Vẽ trục Y
            g.DrawLine(axisPen, margin, margin, margin, margin + chartHeight);

            // Vẽ trục X
            g.DrawLine(axisPen, margin, margin + chartHeight, margin + chartWidth, margin + chartHeight);

            // Vẽ chia độ trục Y
            int ySteps = 5;
            for (int i = 0; i <= ySteps; i++)
            {
                int y = margin + chartHeight - (i * chartHeight / ySteps);
                decimal priceValue = maxPrice * i / ySteps;

                // Vẽ đường kẻ ngang
                g.DrawLine(Pens.LightGray, margin, y, margin + chartWidth, y);

                // Vẽ nhãn giá
                string label = $"{priceValue / 1000000:F1}M";
                g.DrawString(label, labelFont, Brushes.Black, margin - 40, y - 8);
            }

            // Nhãn trục
            g.DrawString("Price (VND)",
             new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, margin - 20, margin - 30);
            g.DrawString("Time", new Font("Segoe UI", 9, FontStyle.Bold),
             Brushes.Black, margin + chartWidth / 2 - 20, margin + chartHeight + 20);
        }

        private void DrawBars(Graphics g, DataTable chartData, int margin, int chartWidth, int chartHeight, decimal maxPrice)
        {
            int barWidth = (chartWidth / chartData.Rows.Count) / 3;
            int spacing = barWidth / 2;

            for (int i = 0; i < chartData.Rows.Count; i++)
            {
                DataRow row = chartData.Rows[i];
                string time = row["Time"].ToString();
                decimal Price = Convert.ToDecimal(row["SalePrice"]);
                decimal Repurchase = Convert.ToDecimal(row["RepurchasePrice"]);

                // Tính vị trí và chiều cao các cột
                int x = margin + (i * (barWidth * 3 + spacing)) + spacing;

                // Cột giá bán 
                int saleHeight = (int)((Price / maxPrice) * chartHeight);
                int saleY = margin + chartHeight - saleHeight;
                g.FillRectangle(Brushes.Teal, x, saleY, barWidth, saleHeight);
                g.DrawRectangle(Pens.Teal, x, saleY, barWidth, saleHeight);

                // Cột giá mua (màu cam)
                int purchaseHeight = (int)((Repurchase / maxPrice) * chartHeight);
                int purchaseY = margin + chartHeight - purchaseHeight;
                g.FillRectangle(Brushes.Coral, x + barWidth + 2, purchaseY, barWidth, purchaseHeight);
                g.DrawRectangle(Pens.Coral, x + barWidth + 2, purchaseY, barWidth, purchaseHeight);

                // Vẽ nhãn thời gian
                Font timeFont = new Font("Segoe UI", 7);
                g.DrawString(time, timeFont, Brushes.Black, x - 5, margin + chartHeight + 5);

                // Vẽ giá trị trên cột
                DrawValueOnBar(g, Price, x, saleY, barWidth, Brushes.Black, margin, chartHeight);
                DrawValueOnBar(g, Repurchase, x + barWidth + 2, purchaseY, barWidth, Brushes.Black, margin, chartHeight);
            }
        }

        private void DrawValueOnBar(Graphics g, decimal value, int x, int y, int barWidth, Brush defaultColor, int margin, int chartHeight)
        {
            string valueText = $"{(value / 1000000):F1}M";
            Font valueFont = new Font("Segoe UI", 7);
            SizeF textSize = g.MeasureString(valueText, valueFont);

            float textX = x + (barWidth - textSize.Width) / 2;
            float textY = y - textSize.Height - 2;

            Brush textBrush = defaultColor; 
            if (textY < margin)
            {
                textY = y + 2;                 
                textBrush = Brushes.White;
            }

            g.DrawString(valueText, valueFont, textBrush, textX, textY);
        }

        private void DrawLegend(Graphics g, int margin, int chartHeight, int chartWidth)
        {
            int legendX = margin + chartWidth - 80;
            int legendY = margin - 50;

            // Sale
            g.FillRectangle(Brushes.Teal, legendX, legendY, 15, 15);
            g.DrawString("PricePerOunce", new Font("Segoe UI", 9), Brushes.Black, legendX + 20, legendY);

            // Purchase
            g.FillRectangle(Brushes.Coral, legendX, legendY + 20, 15, 15);
            g.DrawString("RepurchasePrice", new Font("Segoe UI", 9), Brushes.Black, legendX + 20, legendY + 20);
        }


        // Khi chọn chất liệu trong ComboBox
        private void cbxMaterialUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaterialUpdate.SelectedValue == null || cbxMaterialUpdate.SelectedIndex < 0)
                    return;

                currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();

                //Lấy tuple (Price, Change) cho giá bán
                var saleInfo = updateBLL.GetLatestPriceAndChange(currentMaterialId);
                currentPrice = saleInfo.Price;

                //Lấy tuple (Repurchase, RepurchaseChange) cho giá mua
                var repurchaseInfo = updateBLL.GetLatestRepurchasePriceAndChange(currentMaterialId);
                currentRepurchasePrice = repurchaseInfo.Repurchase;

                // Hiển thị giá bán
                txtPricenow.Text = $"{currentPrice:N0} VND";
                txtChange.Text = (saleInfo.Change >= 0 ? "+" : "") + $"{saleInfo.Change:N0}";
                txtChange.ForeColor = saleInfo.Change >= 0 ? Color.Green : Color.Red;

                // Hiển thị giá mua 
                txtRepurchaseNow.Text = $"{currentRepurchasePrice:N0} VND";
                txtChangeRepurchasePrice.Text = (repurchaseInfo.RepurchaseChange >= 0 ? "+" : "") + $"{repurchaseInfo.RepurchaseChange:N0}";
                txtChangeRepurchasePrice.ForeColor = repurchaseInfo.RepurchaseChange >= 0 ? Color.Green : Color.Red;

                // Load lại DataGridView & thống kê
                LoadPriceHistoryByMaterial(currentMaterialId);
                UpdateStatistics(currentMaterialId);
                DrawPriceChart(currentMaterialId, dtpUpdatePrice.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading material info: " + ex.Message);
            }
        }

        // Load lịch sử giá theo từng chất liệu
        private void LoadPriceHistoryByMaterial(string idMaterial)
        {
            try
            {
                DataTable history = updateBLL.GetAllUpdatePrices(idMaterial);
                dataGridViewChangePrice.DataSource = history;

                // Căn chỉnh style
                dataGridViewChangePrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewChangePrice.ColumnHeadersDefaultCellStyle.Font = new Font("EB Garamond", 7, FontStyle.Bold);
                dataGridViewChangePrice.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                dataGridViewChangePrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewChangePrice.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading price history: " + ex.Message);
            }
        }

        // Cập nhật phần thống kê giá
        private void UpdateStatistics(string materialId)
        {
            try
            {
                DataTable stats = updateBLL.GetPriceStatistics(materialId);
                if (stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];

                    txtMaxChangePrice.Text = row["MaxPrice"] != DBNull.Value
                        ? $"{Convert.ToDecimal(row["MaxPrice"]):N0} VND"
                        : "0 VND";

                    txtMinChangePrice.Text = row["MinPrice"] != DBNull.Value
                        ? $"{Convert.ToDecimal(row["MinPrice"]):N0} VND"
                        : "0 VND";

                    txtMaxRepurchasePrice.Text = row["MaxPurchasePrice"] != DBNull.Value
                        ? $"{Convert.ToDecimal(row["MaxPurchasePrice"]):N0} VND"
                        : "0 VND";

                    // SỬA CHỖ NÀY: txtMinRepurchasePrice thay vì txtMinChangePrice
                    txtMinRepurchasePrice.Text = row["MinPurchasePrice"] != DBNull.Value
                        ? $"{Convert.ToDecimal(row["MinPurchasePrice"]):N0} VND"
                        : "0 VND";

                    txtChangeTimeLatest.Text = row["LastUpdateTime"] != DBNull.Value
                        ? Convert.ToDateTime(row["LastUpdateTime"]).ToString("HH:mm:ss")
                        : "--:--:--";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }

        // Nút hoàn tất cập nhật giá
        private void btnCompleteUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string validationResult = updateBLL.ValidatePriceUpdate(txtEnterChangePrice.Text, txtEnterRepurchasePrice.Text, currentMaterialId);
                if (validationResult != "VALID")
                {
                    MessageBox.Show(validationResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal newPrice = decimal.Parse(txtEnterChangePrice.Text);
                decimal newRepurchasePrice = decimal.Parse(txtEnterRepurchasePrice.Text);
                DateTime updateTime = dtpUpdatePrice.Value;

                UpdateDTO updateDTO = new UpdateDTO
                {
                    idUpdate = updateBLL.GenerateUpdateId(),
                    idMaterial = currentMaterialId,
                    UpdateTime = updateTime,
                    Price = newPrice,
                    RepurchasePrice = newRepurchasePrice,
                    ChangePrice = 0,
                    RepurchaseChange = 0,
                };

                bool success = updateBLL.UpdatePrice(updateDTO);

                if (success)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sau khi cập nhật, đọc lại dòng mới nhất để cập nhật UI
                    DataRow latest = updateBLL.GetLatestRowByMaterial(currentMaterialId);
                    if (latest != null)
                    {
                        // Cập nhật giá bán
                        currentPrice = Convert.ToDecimal(latest["Price"]);
                        decimal saleChange = Convert.ToDecimal(latest["ChangePrice"]);

                        txtPricenow.Text = $"{currentPrice:N0} VND";
                        txtChange.Text = (saleChange >= 0 ? "+" : "") + $"{saleChange:N0}";
                        txtChange.ForeColor = saleChange >= 0 ? Color.Green : Color.Red;

                        // Cập nhật giá mua - SỬA CHỖ NÀY
                        currentRepurchasePrice = Convert.ToDecimal(latest["Repurchase"]);
                        decimal repurchaseChange = Convert.ToDecimal(latest["RepurchaseChange"]);

                        txtRepurchaseNow.Text = $"{currentRepurchasePrice:N0} VND";
                        txtChangeRepurchasePrice.Text = (repurchaseChange >= 0 ? "+" : "") + $"{repurchaseChange:N0}";
                        txtChangeRepurchasePrice.ForeColor = repurchaseChange >= 0 ? Color.Green : Color.Red;
                    }

                    LoadPriceHistoryByMaterial(currentMaterialId);
                    UpdateStatistics(currentMaterialId);
                    txtEnterChangePrice.Clear();
                    txtEnterRepurchasePrice.Clear();
                    DrawPriceChart(currentMaterialId, dtpUpdatePrice.Value);
                }
                else
                {
                    MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page_Account frm = new Page_Account();
            this.Hide();
            frm.ShowDialog();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page_Overview frm = new Page_Overview();
            this.Hide();
            frm.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            this.Hide();
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            this.Hide();
            frm.ShowDialog();
        }
        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }
        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm = new Invoice();
            this.Hide();
            frm.ShowDialog();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product_View frm = new Product_View();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
