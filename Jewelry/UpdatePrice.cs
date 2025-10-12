using System;
using System.Data;
using System.Drawing;
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
            DateTimeUpdatePrice.Value = DateTime.Now;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}");
            }
        }

        // Khi chọn chất liệu trong ComboBox
        private void cbxMaterialUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaterialUpdate.SelectedValue == null || cbxMaterialUpdate.SelectedIndex < 0)
                    return;

                currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();

                // Lấy thông tin giá mới nhất từ DB
                DataRow latest = updateBLL.GetLatestPriceInfo(currentMaterialId);
                if (latest != null)
                {
                    currentPrice = Convert.ToDecimal(latest["Price"]);
                    decimal change = Convert.ToDecimal(latest["ChangePrice"]);

                    txtPricenow.Text = $"{currentPrice:N0} VND";
                    txtChange.Text = (change >= 0 ? "+" : "") + $"{change:N0}";
                    txtChange.ForeColor = change >= 0 ? Color.Green : Color.Red;
                }
                else
                {
                    currentPrice = 0;
                    txtPricenow.Text = "0 VND";
                    txtChange.Text = "0";
                    txtChange.ForeColor = Color.Black;
                }

                // Load bảng và thống kê
                LoadPriceHistoryByMaterial(currentMaterialId);
                UpdateStatistics(currentMaterialId);
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
                dataGridViewChangePrice.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
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

        //Nút hoàn tất cập nhật giá
        private void btnCompleteUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                string validationResult = updateBLL.ValidatePriceUpdate(txtEnterChangePrice.Text, currentMaterialId);
                if (validationResult != "VALID")
                {
                    MessageBox.Show(validationResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal newPrice = decimal.Parse(txtEnterChangePrice.Text);
                DateTime updateTime = DateTimeUpdatePrice.Value;
                decimal changeAmount = newPrice - currentPrice;

                UpdateDTO updateDTO = new UpdateDTO
                {
                    idUpdate = updateBLL.GenerateUpdateId(),
                    idMaterial = currentMaterialId,
                    UpdateTime = updateTime,
                    Price = newPrice,
                    ChangePrice = changeAmount
                };

                bool success = updateBLL.UpdatePrice(updateDTO);

                if (success)
                {
                    MessageBox.Show("Updated Successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload giá mới từ DB
                    DataRow latest = updateBLL.GetLatestPriceInfo(currentMaterialId);
                    if (latest != null)
                    {
                        currentPrice = Convert.ToDecimal(latest["Price"]);
                        txtPricenow.Text = $"{currentPrice:N0} VND";

                        decimal change = Convert.ToDecimal(latest["ChangePrice"]);
                        txtChange.Text = (change >= 0 ? "+" : "") + $"{change:N0}";
                        txtChange.ForeColor = change >= 0 ? Color.Green : Color.Red;
                    }

                    // Reload DataGridView & thống kê
                    LoadPriceHistoryByMaterial(currentMaterialId);
                    UpdateStatistics(currentMaterialId);
                    txtEnterChangePrice.Clear();
                }
                else
                {
                    MessageBox.Show(" Update failed!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút quay lại Dashboard
        private void btnReturnUpDate_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
