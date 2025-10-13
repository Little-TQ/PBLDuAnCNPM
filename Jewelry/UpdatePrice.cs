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

                //Lấy tuple (Price, Change)
                var info = updateBLL.GetLatestPriceAndChange(currentMaterialId);
                currentPrice = info.Price;

                txtPricenow.Text = $"{currentPrice:N0} VND";
                txtChange.Text = (info.Change >= 0 ? "+" : "") + $"{info.Change:N0}";
                txtChange.ForeColor = info.Change >= 0 ? Color.Green : Color.Red;

                // Load lại DataGridView & thống kê
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

        // Nút hoàn tất cập nhật giá
        private void btnCompleteUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string validationResult = updateBLL.ValidatePriceUpdate(txtEnterChangePrice.Text, currentMaterialId);
                if (validationResult != "VALID")
                {
                    MessageBox.Show(validationResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal newPrice = decimal.Parse(txtEnterChangePrice.Text);
                DateTime updateTime = DateTimeUpdatePrice.Value;

                UpdateDTO updateDTO = new UpdateDTO
                {
                    idUpdate = updateBLL.GenerateUpdateId(),
                    idMaterial = currentMaterialId,
                    UpdateTime = updateTime,
                    Price = newPrice,
                    ChangePrice = 0
                };

                bool success = updateBLL.UpdatePrice(updateDTO);

                if (success)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sau khi cập nhật, đọc lại dòng mới nhất để cập nhật UI
                    DataRow latest = updateBLL.GetLatestRowByMaterial(currentMaterialId);
                    if (latest != null)
                    {
                        currentPrice = Convert.ToDecimal(latest["Price"]);
                        decimal change = Convert.ToDecimal(latest["ChangePrice"]);

                        txtPricenow.Text = $"{currentPrice:N0} VND";
                        txtChange.Text = (change >= 0 ? "+" : "") + $"{change:N0}";
                        txtChange.ForeColor = change >= 0 ? Color.Green : Color.Red;
                    }

                    LoadPriceHistoryByMaterial(currentMaterialId);
                    UpdateStatistics(currentMaterialId);
                    txtEnterChangePrice.Clear();
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

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void repurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Repurchase_Select frm = new Payment_Repurchase_Select();
            this.Hide();
            frm.ShowDialog();
        }

        private void preOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_PreOrder_Select frm= new Payment_PreOrder_Select();
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
