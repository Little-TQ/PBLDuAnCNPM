using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

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

                DrawPriceChart(currentMaterialId, dtpUpdatePrice.Value);
                LoadPriceHistoryByMaterial(currentMaterialId);
                UpdateStatistics(currentMaterialId);
            }
        }

        // load material into combobox
        private void LoadMaterials()
        {
            try
            {
                DataTable materials = updateBLL.GetAllMaterials();

                //Lọc bỏ Silver
                var filtered = materials.AsEnumerable()
                    .Where(row => !row["NameMaterial"].ToString().Equals("Silver", StringComparison.OrdinalIgnoreCase))
                    .CopyToDataTable();

                cbxMaterialUpdate.DataSource = filtered;
                cbxMaterialUpdate.DisplayMember = "NameMaterial";
                cbxMaterialUpdate.ValueMember = "idMaterial";
                cbxMaterialUpdate.SelectedIndex = -1;

                // Reset các textbox
                txtPricenow.Text = "0 VND";
                txtChange.Text = "0";
                txtRepurchaseNow.Text = "0 VND";
                txtChangeRepurchasePrice.Text = "0";
            }
            catch (InvalidOperationException)
            {
                cbxMaterialUpdate.DataSource = null;
                MessageBox.Show("Không có chất liệu hợp lệ (ngoại trừ Silver).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}");
            }
        }

        // choose material
        private void cbxMaterialUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaterialUpdate.SelectedIndex < 0 || cbxMaterialUpdate.SelectedValue == null)
                    return;

                currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();

                // Lấy thông tin giá bán
                var saleInfo = updateBLL.GetLatestPriceAndChange(currentMaterialId);
                currentPrice = saleInfo.Price;

                // Lấy thông tin giá mua lại
                var repurchaseInfo = updateBLL.GetLatestRepurchasePriceAndChange(currentMaterialId);
                currentRepurchasePrice = repurchaseInfo.Repurchase;

                // Cập nhật UI
                txtPricenow.Text = $"{currentPrice:N0} VND";
                txtChange.Text = (saleInfo.Change >= 0 ? "+" : "") + $"{saleInfo.Change:N0}";
                txtChange.ForeColor = saleInfo.Change >= 0 ? Color.Green : Color.Red;

                txtRepurchaseNow.Text = $"{currentRepurchasePrice:N0} VND";
                txtChangeRepurchasePrice.Text = (repurchaseInfo.RepurchaseChange >= 0 ? "+" : "") + $"{repurchaseInfo.RepurchaseChange:N0}";
                txtChangeRepurchasePrice.ForeColor = repurchaseInfo.RepurchaseChange >= 0 ? Color.Green : Color.Red;

                // Cập nhật biểu đồ và thống kê
                LoadPriceHistoryByMaterial(currentMaterialId);
                UpdateStatistics(currentMaterialId);
                DrawPriceChart(currentMaterialId, dtpUpdatePrice.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading material info: " + ex.Message);
            }
        }

        //draw chart
        private void DrawPriceChart(string materialId, DateTime selectedDate)
        {
            try
            {
                DataTable chartData = updateBLL.GetDailyPriceChartData(materialId, selectedDate);

                if (chartData.Rows.Count == 0)
                {
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

                int margin = 60;
                int chartWidth = chartPanel.Width - 2 * margin;
                int chartHeight = chartPanel.Height - 2 * margin;

                decimal maxPrice = 0;
                foreach (DataRow row in chartData.Rows)
                {
                    decimal Price = Convert.ToDecimal(row["SalePrice"]);
                    decimal Repurchase = Convert.ToDecimal(row["RepurchasePrice"]);
                    maxPrice = Math.Max(maxPrice, Math.Max(Price, Repurchase));
                }

                DrawAxes(g, margin, chartWidth, chartHeight, maxPrice);
                DrawBars(g, chartData, margin, chartWidth, chartHeight, maxPrice);
                DrawLegend(g, margin, chartHeight, chartWidth);
            }
        }

        private void DrawAxes(Graphics g, int margin, int chartWidth, int chartHeight, decimal maxPrice)
        {
            Pen axisPen = new Pen(Color.Black, 2);
            Font labelFont = new Font("Segoe UI", 8);

            g.DrawLine(axisPen, margin, margin, margin, margin + chartHeight);
            g.DrawLine(axisPen, margin, margin + chartHeight, margin + chartWidth, margin + chartHeight);

            int ySteps = 5;
            for (int i = 0; i <= ySteps; i++)
            {
                int y = margin + chartHeight - (i * chartHeight / ySteps);
                decimal priceValue = maxPrice * i / ySteps;
                g.DrawLine(Pens.LightGray, margin, y, margin + chartWidth, y);
                string label = $"{priceValue / 1000000:F1}M";
                g.DrawString(label, labelFont, Brushes.Black, margin - 40, y - 8);
            }

            g.DrawString("Price (VND)", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, margin - 20, margin - 30);
            g.DrawString("Time", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, margin + chartWidth / 2 - 20, margin + chartHeight + 20);
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

                int x = margin + (i * (barWidth * 3 + spacing)) + spacing;

                int saleHeight = (int)((Price / maxPrice) * chartHeight);
                int saleY = margin + chartHeight - saleHeight;
                g.FillRectangle(Brushes.Teal, x, saleY, barWidth, saleHeight);
                g.DrawRectangle(Pens.Teal, x, saleY, barWidth, saleHeight);

                int purchaseHeight = (int)((Repurchase / maxPrice) * chartHeight);
                int purchaseY = margin + chartHeight - purchaseHeight;
                g.FillRectangle(Brushes.Coral, x + barWidth + 2, purchaseY, barWidth, purchaseHeight);
                g.DrawRectangle(Pens.Coral, x + barWidth + 2, purchaseY, barWidth, purchaseHeight);

                Font timeFont = new Font("Segoe UI", 7);
                g.DrawString(time, timeFont, Brushes.Black, x - 5, margin + chartHeight + 5);
            }
        }

        private void DrawLegend(Graphics g, int margin, int chartHeight, int chartWidth)
        {
            int legendX = margin + chartWidth - 80;
            int legendY = margin - 50;

            g.FillRectangle(Brushes.Teal, legendX, legendY, 15, 15);
            g.DrawString("Sale Price", new Font("Segoe UI", 9), Brushes.Black, legendX + 20, legendY);

            g.FillRectangle(Brushes.Coral, legendX, legendY + 20, 15, 15);
            g.DrawString("Repurchase Price", new Font("Segoe UI", 9), Brushes.Black, legendX + 20, legendY + 20);
        }

        // Load price history into DataGridView
        private void LoadPriceHistoryByMaterial(string idMaterial)
        {
            try
            {
                DataTable history = updateBLL.GetAllUpdatePrices(idMaterial);
                dataGridViewChangePrice.DataSource = history;

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

        // Update statistics
        private void UpdateStatistics(string materialId)
        {
            try
            {
                DataTable stats = updateBLL.GetPriceStatistics(materialId);
                if (stats.Rows.Count == 0) return;

                DataRow row = stats.Rows[0];
                txtMaxChangePrice.Text = row["MaxPrice"] != DBNull.Value ? $"{Convert.ToDecimal(row["MaxPrice"]):N0} VND" : "0 VND";
                txtMinChangePrice.Text = row["MinPrice"] != DBNull.Value ? $"{Convert.ToDecimal(row["MinPrice"]):N0} VND" : "0 VND";
                txtMaxRepurchasePrice.Text = row["MaxPurchasePrice"] != DBNull.Value ? $"{Convert.ToDecimal(row["MaxPurchasePrice"]):N0} VND" : "0 VND";
                txtMinRepurchasePrice.Text = row["MinPurchasePrice"] != DBNull.Value ? $"{Convert.ToDecimal(row["MinPurchasePrice"]):N0} VND" : "0 VND";
                txtChangeTimeLatest.Text = row["LastUpdateTime"] != DBNull.Value
                    ? Convert.ToDateTime(row["LastUpdateTime"]).ToString("HH:mm:ss")
                    : "--:--:--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }

        // Updatw price button click
        private void btnCompleteUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentMaterialId))
                {
                    MessageBox.Show("Please select a material before updating!");
                    return;
                }

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
                    LoadPriceHistoryByMaterial(currentMaterialId);
                    UpdateStatistics(currentMaterialId);
                    DrawPriceChart(currentMaterialId, dtpUpdatePrice.Value);
                }
                else
                {
                    MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            //Invoice frm = new Invoice();
            this.Hide();
            //frm.ShowDialog();
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



