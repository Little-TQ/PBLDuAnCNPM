using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry
{
    public partial class UpdatePrice: Form
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
                MessageBox.Show($"Error load material: {ex.Message}");
            }
        }

        // Load lịch sử giá
        private void LoadPriceHistory()
        {
            try
            {
                DataTable history = updateBLL.GetAllUpdatePrices();
                dataGridViewChangePrice.DataSource = history;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử giá: " + ex.Message);
            }
        }

        // Cập nhật thông tin thống kê
        private void UpdateStatistics(string materialId)
        {
            try
            {
                DataTable stats = updateBLL.GetPriceStatistics(materialId);
                if (stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];

                    // Cập nhật giá cao nhất
                    if (row["MaxPrice"] != DBNull.Value)
                        txtMaxChangePrice.Text = Convert.ToDecimal(row["MaxPrice"]).ToString("N0") + " VND";

                    // Cập nhật giá thấp nhất
                    if (row["MinPrice"] != DBNull.Value)
                        txtMinChangePrice.Text = Convert.ToDecimal(row["MinPrice"]).ToString("N0") + " VND";

                    // Cập nhật thời gian cập nhật cuối
                    if (row["LastUpdateTime"] != DBNull.Value)
                        txtChangeTimeLatest.Text = Convert.ToDateTime(row["LastUpdateTime"]).ToString("HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }
        private void dataGridViewChangePrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExitUpDate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnUpDate_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnCompleteUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu
                string validationResult = updateBLL.ValidatePriceUpdate(txtEnterChangePrice.Text, currentMaterialId);
                if (validationResult != "VALID")
                {
                    MessageBox.Show(validationResult, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal newPrice = decimal.Parse(txtEnterChangePrice.Text);
                DateTime updateTime = DateTimeUpdatePrice.Value;
                decimal changeAmount = newPrice - currentPrice;

                // Tạo DTO
                UpdateDTO updateDTO = new UpdateDTO
                {
                    idUpdate = updateBLL.GenerateUpdateId(),
                    idMaterial = currentMaterialId,
                    UpdateTime = updateTime,
                    Price = newPrice,
                    ChangePrice = changeAmount
                };

                // Thực hiện cập nhật
                bool success = updateBLL.UpdatePrice(updateDTO);

                if (success)
                {
                    MessageBox.Show("Cập nhật giá thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật giao diện
                    currentPrice = newPrice;
                    txtPricenow.Text = currentPrice.ToString("N0") + " VND";
                    txtChange.Text = (changeAmount >= 0 ? "+" : "") + changeAmount.ToString("N0");
                    txtChange.ForeColor = changeAmount >= 0 ? Color.Green : Color.Red;

                    // Load lại lịch sử và thống kê
                    LoadPriceHistory();
                    UpdateStatistics(currentMaterialId);

                    // Clear ô nhập giá
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

        private void cbxMaterialUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxMaterialUpdate.SelectedValue != null)
            {
                currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();
                currentPrice = updateBLL.GetCurrentPricePerOunce(currentMaterialId);
                txtPricenow.Text = currentPrice.ToString("N0") + " VND";
                UpdateStatistics(currentMaterialId);
            }
        }

        private void UpdatePrice_Load(object sender, EventArgs e)
        {

        }
    }
}
