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
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadMaterials();
            LoadPriceHistory();
            DateTimeUpdatePrice.Value = DateTime.Now;
        }

        // Load danh sách chất liệu từ DB
        private void LoadMaterials()
        {
            try
            {
                DataTable materials = updateBLL.GetAllMaterials();
                cbxMaterialUpdate.DataSource = materials;
                cbxMaterialUpdate.DisplayMember = "NameMaterial";
                cbxMaterialUpdate.ValueMember = "idMaterial";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chất liệu: {ex.Message}");
            }
        }

        //Load toàn bộ lịch sử giá từ DB
        private void LoadPriceHistory()
        {
            try
            {
                DataTable history = updateBLL.GetAllUpdatePrices();
                dataGridViewChangePrice.DataSource = history;
                dataGridViewChangePrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewChangePrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử giá: " + ex.Message);
            }
        }

        // Cập nhật thông tin thống kê theo chất liệu
        private void UpdateStatistics(string materialId)
        {
            try
            {
                DataTable stats = updateBLL.GetPriceStatistics(materialId);
                if (stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];

                    txtMaxChangePrice.Text = row["MaxPrice"] != DBNull.Value
                        ? Convert.ToDecimal(row["MaxPrice"]).ToString("N0") + " VND"
                        : "0 VND";

                    txtMinChangePrice.Text = row["MinPrice"] != DBNull.Value
                        ? Convert.ToDecimal(row["MinPrice"]).ToString("N0") + " VND"
                        : "0 VND";

                    txtChangeTimeLatest.Text = row["LastUpdateTime"] != DBNull.Value
                        ? Convert.ToDateTime(row["LastUpdateTime"]).ToString("HH:mm:ss")
                        : "--:--:--";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }

        // Khi chọn chất liệu
        private void cbxMaterialUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaterialUpdate.SelectedValue != null)
                {
                    currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();

                    var info = updateBLL.GetLatestPriceAndChange(currentMaterialId);
                    currentPrice = info.Price;

                    txtPricenow.Text = $"{currentPrice:N0} VND";
                    txtChange.Text = (info.Change >= 0 ? "+" : "") + $"{info.Change:N0}";
                    txtChange.ForeColor = info.Change >= 0 ? Color.Green : Color.Red;

                    UpdateStatistics(currentMaterialId);
                    LoadPriceHistoryByMaterial(currentMaterialId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load lịch sử riêng cho từng chất liệu
        private void LoadPriceHistoryByMaterial(string materialId)
        {
            try
            {
                DataTable dt = updateBLL.GetAllUpdatePrices(); // vẫn dùng chung hàm DAL gốc
                if (dt.Columns.Contains("Loại Vàng"))
                {
                    // lọc nếu DAL có cột "Loại Vàng"
                    DataView view = new DataView(dt);
                    view.RowFilter = $"[Loại Vàng] LIKE '%{cbxMaterialUpdate.Text}%'";
                    dataGridViewChangePrice.DataSource = view;
                }
                else
                {
                    dataGridViewChangePrice.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc lịch sử giá: " + ex.Message);
            }
        }

        // Nút hoàn tất cập nhật giá
        private void btnCompleteUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                string validationResult = updateBLL.ValidatePriceUpdate(txtEnterChangePrice.Text, currentMaterialId);
                if (validationResult != "VALID")
                {
                    MessageBox.Show(validationResult, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal newPrice = decimal.Parse(txtEnterChangePrice.Text);
                DateTime updateTime = DateTimeUpdatePrice.Value;
                decimal changeAmount = newPrice - currentPrice;

                // Tạo DTO lưu vào DB
                UpdateDTO updateDTO = new UpdateDTO
                {
                    idUpdate = updateBLL.GenerateUpdateId(),
                    idMaterial = currentMaterialId,
                    UpdateTime = updateTime,
                    Price = newPrice,
                    ChangePrice = changeAmount
                };

                // Gọi hàm cập nhật
                bool success = updateBLL.UpdatePrice(updateDTO);

                if (success)
                {
                    MessageBox.Show("✅ Cập nhật giá thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật UI
                    currentPrice = newPrice;
                    txtPricenow.Text = currentPrice.ToString("N0") + " VND";
                    txtChange.Text = (changeAmount >= 0 ? "+" : "") + changeAmount.ToString("N0");
                    txtChange.ForeColor = changeAmount >= 0 ? Color.Green : Color.Red;

                    // Load lại dữ liệu
                    LoadPriceHistory();
                    UpdateStatistics(currentMaterialId);
                    txtEnterChangePrice.Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật giá thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật giá: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReturnUpDate_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();    
            this.Hide();
            frm.ShowDialog();
        }

        private void dataGridViewChangePrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void UpdatePrice_Load(object sender, EventArgs e)
        {
        }
    }
}
