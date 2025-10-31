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
        private ProductBLL productBLL = new ProductBLL();
        private string currentInvoiceId = "";

        public Repurchase()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvProduct.Columns.Clear();
            dgvProduct.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Product", HeaderText = "Product", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Quantity" },
                new DataGridViewTextBoxColumn { Name = "Weight", HeaderText = "Weight", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Wage", HeaderText = "Wage", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "BasePrice", HeaderText = "BasePrice", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "RepurchasePrice", HeaderText = "RepurchasePrice", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Amount", HeaderText = "Amount", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "idProduct", HeaderText = "idProduct", Visible = false },
                new DataGridViewTextBoxColumn { Name = "idMaterial", HeaderText = "idMaterial", Visible = false }
            });

            dgvProduct.CellEndEdit += dgvProduct_CellEndEdit;
            dgvProduct.AllowUserToAddRows = false;
        }

        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string invoiceId = txbSearch.Text.Trim();
                if (string.IsNullOrEmpty(invoiceId))
                {
                    MessageBox.Show("Please enter your ID invoice");
                    return;
                }

                SearchInvoice(invoiceId);
            }
        }

        private void SearchInvoice(string invoiceId)
        {
            try
            {
                var invoiceDetails = invoiceBLL.GetInvoiceDetails(invoiceId);

                if (invoiceDetails == null || invoiceDetails.Rows.Count == 0)
                {
                    MessageBox.Show("Search Unsuccessful!");
                    return;
                }

                currentInvoiceId = invoiceId;
                dgvProduct.Rows.Clear();

                foreach (DataRow row in invoiceDetails.Rows)
                {
                    string productId = row["idProduct"].ToString();
                    string materialId = row["idMaterial"].ToString();

                    // Lấy giá mua lại từ UpdateBLL
                    var repurchaseData = updateBLL.GetLatestRepurchasePriceAndChange(materialId);
                    decimal repurchasePrice = repurchaseData.Repurchase;
  
                    decimal quantity = Convert.ToDecimal(row["Quantity"]);
                    decimal weight = Convert.ToDecimal(row["Weight"]);
                    decimal wage = Convert.ToDecimal(row["Wage"]);
                    decimal basicprice = Convert.ToDecimal(row["Price"]);

                    // Tính giá theo công thức: (BasicPrice * Weight) + Wage
                    decimal price = (basicprice * weight) + wage;

                    // Thêm dòng mới với đầy đủ thông tin
                    int index = dgvProduct.Rows.Add();
                    dgvProduct.Rows[index].Cells["Product"].Value = row["ProductName"];
                    dgvProduct.Rows[index].Cells["Product"].Tag = productId; 
                    dgvProduct.Rows[index].Cells["Quantity"].Value = quantity;
                    dgvProduct.Rows[index].Cells["Weight"].Value = weight;
                    dgvProduct.Rows[index].Cells["Wage"].Value = wage;
                    dgvProduct.Rows[index].Cells["BasePrice"].Value = basicprice;
                    dgvProduct.Rows[index].Cells["Price"].Value = price;
                    dgvProduct.Rows[index].Cells["RepurchasePrice"].Value = repurchasePrice;
                    dgvProduct.Rows[index].Cells["Amount"].Value = quantity * repurchasePrice;
                    dgvProduct.Rows[index].Cells["idProduct"].Value = productId;
                    dgvProduct.Rows[index].Cells["idMaterial"].Value = materialId;
                    dgvProduct.Columns["Wage"].DefaultCellStyle.Format =
                    dgvProduct.Columns["BasePrice"].DefaultCellStyle.Format =
                    dgvProduct.Columns["Price"].DefaultCellStyle.Format =
                    dgvProduct.Columns["RepurchasePrice"].DefaultCellStyle.Format =
                    dgvProduct.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
                }

                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Search Invoice: {ex.Message}");
            }
        }

        private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProduct.Columns["Quantity"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];

                if (row.Cells["Quantity"].Value != null &&
                    decimal.TryParse(row.Cells["Quantity"].Value.ToString(), out decimal quantity))
                {
                    if (quantity == 0)
                    {
                        dgvProduct.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        decimal repurchasePrice = Convert.ToDecimal(row.Cells["RepurchasePrice"].Value);
                        row.Cells["Amount"].Value = quantity * repurchasePrice;
                    }
                    UpdateTotal();
                }
            }
        }

        private void btnDeleteRepurchase_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow != null)
            {
                dgvProduct.Rows.RemoveAt(dgvProduct.CurrentRow.Index);
                UpdateTotal();
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows.Count == 0)
            {
                MessageBox.Show("Don't have any product for payment");
                return;
            }

            // Tạo danh sách sản phẩm mua lại từ dgv - SỬA LẠI THEO CÁCH CỦA SALE.CS
            List<RepurchaseItem> repurchaseItems = new List<RepurchaseItem>();
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;

                repurchaseItems.Add(new RepurchaseItem
                {
                    ID = row.Cells["idProduct"].Value?.ToString(),
                    Name = row.Cells["Product"].Value?.ToString(),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Weight = row.Cells["Weight"].Value?.ToString(),
                    Wage = Convert.ToDecimal(row.Cells["Wage"].Value ?? 0),
                    BasePrice = Convert.ToDecimal(row.Cells["BasePrice"].Value ?? 0),
                    Price = Convert.ToDecimal(row.Cells["Price"].Value ?? 0),
                    RepurchasePrice = Convert.ToDecimal(row.Cells["RepurchasePrice"].Value ?? 0),
                    Amount = Convert.ToDecimal(row.Cells["Amount"].Value ?? 0)
                });
            }

            // Mở form hóa đơn mua lại và truyền cả originalInvoiceId
            Payment_Repurchase_Invoice frmInvoice = new Payment_Repurchase_Invoice(repurchaseItems, currentInvoiceId);
            frmInvoice.InvoicePrinted += (s, ev) =>
            { 
                dgvProduct.Rows.Clear();
                txbSearch.Clear();
                UpdateTotal();
            };
            frmInvoice.ShowDialog();
        }
    }
}