using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry.Payment
{
    public partial class Repurchase : UserControl
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private UpdateBLL updateBLL = new UpdateBLL();
        private string currentMaterialId = "";

        public Repurchase()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            try
            {
                DataTable materials = updateBLL.GetAllMaterials();
                cbxMaterialUpdate.DataSource = materials;
                cbxMaterialUpdate.DisplayMember = "NameMaterial";
                cbxMaterialUpdate.ValueMember = "idMaterial";
                cbxMaterialUpdate.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}");
            }
        }

        private void SetupDataGridView()
        {
            dgvProduct.Columns.Clear();
            dgvProduct.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Material", HeaderText = "Material", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Weight", HeaderText = "Weight", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "RepurchasePrice", HeaderText = "RepurchasePrice", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Amount", HeaderText = "Amount", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "idMaterial", HeaderText = "idMaterial", Visible = false }
            });

            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.Columns["RepurchasePrice"].DefaultCellStyle.Format = "#,##0 ₫";
            dgvProduct.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
        }

        private void cbxMaterialUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMaterialUpdate.SelectedIndex == -1) return;

            // Chỉ lưu materialId, chưa thêm vào dgv
            currentMaterialId = cbxMaterialUpdate.SelectedValue.ToString();

            // Focus để nhập weight
            txtWeight.Focus();
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(currentMaterialId))
            {
                AddMaterialToGrid();
            }
        }

        private void AddMaterialToGrid()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtWeight.Text) || !decimal.TryParse(txtWeight.Text, out decimal weight) || weight <= 0)
                {
                    MessageBox.Show("Please enter valid weight");
                    return;
                }

                string materialName = cbxMaterialUpdate.Text;

                // Kiểm tra trùng
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    if (row.Cells["idMaterial"].Value?.ToString() == currentMaterialId)
                    {
                        MessageBox.Show("Material already exists");
                        return;
                    }
                }

                // Lấy giá và tính toán
                var repurchaseData = updateBLL.GetLatestRepurchasePriceAndChange(currentMaterialId);
                decimal repurchasePrice = repurchaseData.Repurchase;
                decimal amount = weight * repurchasePrice;

                // Thêm vào dgv
                int index = dgvProduct.Rows.Add();
                dgvProduct.Rows[index].Cells["Material"].Value = materialName;
                dgvProduct.Rows[index].Cells["Weight"].Value = weight;
                dgvProduct.Rows[index].Cells["RepurchasePrice"].Value = repurchasePrice;
                dgvProduct.Rows[index].Cells["Amount"].Value = amount;
                dgvProduct.Rows[index].Cells["idMaterial"].Value = currentMaterialId;

                // Reset
                cbxMaterialUpdate.SelectedIndex = -1;
                txtWeight.Clear();
                currentMaterialId = "";

                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateTotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.Cells["Amount"].Value != null)
                    subtotal += Convert.ToDecimal(row.Cells["Amount"].Value);
            }
            lblSubtotal.Text = $"{subtotal:N0} ₫";
            lblTotal.Text = $"{subtotal:N0} ₫";
        }

        private void btnDeleteRepurchase_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow != null)
            {
                dgvProduct.Rows.RemoveAt(dgvProduct.CurrentRow.Index);
                UpdateTotal();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows.Count == 0)
            {
                MessageBox.Show("No products for payment");
                return;
            }

            List<RepurchaseItem> repurchaseItems = new List<RepurchaseItem>();
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                repurchaseItems.Add(new RepurchaseItem
                {
                    Name = row.Cells["Material"].Value?.ToString(),
                    Weight = row.Cells["Weight"].Value?.ToString(),
                    RepurchasePrice = Convert.ToDecimal(row.Cells["RepurchasePrice"].Value ?? 0),
                    Amount = Convert.ToDecimal(row.Cells["Amount"].Value ?? 0),
                    ID = row.Cells["idMaterial"].Value?.ToString()
                });
            }

            Payment_Repurchase_Invoice frmInvoice = new Payment_Repurchase_Invoice(repurchaseItems, "");
            frmInvoice.InvoicePrinted += (s, ev) =>
            {
                dgvProduct.Rows.Clear();
                UpdateTotal();
            };
            frmInvoice.ShowDialog();
        }
    }
}