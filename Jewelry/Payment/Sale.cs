using Jewelry.BLL;
using Jewelry.DTO;
using Jewelry.FlowLayoutPanel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Jewelry.Payment
{
    public partial class Sale : UserControl
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        private ProductBLL productBLL = new ProductBLL();
        private UpdateBLL updateBLL = new UpdateBLL();

        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            SetUpDGVStyle();
            LoadProductList();
        }
        private void LoadProductList(string filter = "")
        {
            flowProduct.Controls.Clear();

            DataTable dtProduct = propertyBLL.GetPropertyData("Product");
            DataTable dtMaterial = propertyBLL.GetPropertyData("Material");

            //Nếu có chuỗi tìm kiếm => lọc theo ID
            if (!string.IsNullOrWhiteSpace(filter))
            {
                // Lọc các sản phẩm có idProduct bắt đầu bằng filter (không phân biệt hoa thường)
                var filteredRows = dtProduct.AsEnumerable()
                    .Where(r => r["idProduct"].ToString().ToUpper().StartsWith(filter.ToUpper()));

                // Nếu không tìm thấy sản phẩm phù hợp
                if (!filteredRows.Any())
                {
                    Label lblNoResult = new Label
                    {
                        Text = "No products found.",
                        AutoSize = true,
                        ForeColor = Color.Gray,
                        Font = new Font("Segoe UI", 11, FontStyle.Italic)
                    };
                    flowProduct.Controls.Add(lblNoResult);
                    return;
                }

                dtProduct = filteredRows.CopyToDataTable();
            }

            if (dtProduct.Rows.Count == 0)
            {
                MessageBox.Show("No Product!");
                return;
            }

            foreach (DataRow row in dtProduct.Rows)
            {
                string id = row["idProduct"].ToString();
                string name = row["NameProduct"].ToString();
                decimal price = row["PriceSilver"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PriceSilver"]);
                string photo = row["Photo"].ToString();
                string idMaterial = row["idMaterial"].ToString();

                string materialName = "";
                DataRow[] materialRows = dtMaterial.Select($"idMaterial = '{idMaterial}'");
                if (materialRows.Length > 0)
                    materialName = materialRows[0]["NameMaterial"].ToString();

                ProductList productItem = new ProductList();
                productItem.SetProductData(id, name, price, materialName, photo);
                productItem.ProductAdded += ProductItem_ProductAdded;

                productItem.Margin = new Padding(10);
                flowProduct.Controls.Add(productItem);
            }
        }
        private void ProductItem_ProductAdded(object sender, ProductEventArgs e)
        {
            try
            {
                var product = productBLL.GetProductByID(e.ID);
                if (product == null)
                {
                    MessageBox.Show("Product not found in database!");
                    return;
                }

                var (basePrice, change) = updateBLL.GetLatestPriceAndChange(product.idMaterial);
                decimal price = product.PriceSilver ?? 0;

                // So sánh theo Tag (idProduct)
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    var idInRow = row.Cells["Product"].Tag?.ToString();
                    if (idInRow == product.idProduct)
                    {
                        int qty = Convert.ToInt32(row.Cells["Quantity"].Value) + 1;
                        row.Cells["Quantity"].Value = qty;
                        row.Cells["Amount"].Value = qty * price;
                        UpdateTotal();
                        return;
                    }
                }

                // Không có -> thêm mới
                int index = dgvProduct.Rows.Add();
                dgvProduct.Rows[index].Cells["Product"].Value = product.NameProduct;
                dgvProduct.Rows[index].Cells["Product"].Tag = product.idProduct; // giữ ID ở Tag
                dgvProduct.Rows[index].Cells["Quantity"].Value = 1;
                dgvProduct.Rows[index].Cells["Weight"].Value = product.Weight;
                dgvProduct.Rows[index].Cells["Wage"].Value = product.Wage;
                dgvProduct.Rows[index].Cells["BasePrice"].Value = basePrice;
                dgvProduct.Rows[index].Cells["Price"].Value = price;
                dgvProduct.Rows[index].Cells["Amount"].Value = price;

                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting product: " + ex.Message);
            }
        }

        private void SetUpDGVStyle()
        {
            if (dgvProduct.Columns.Contains("Price"))
                dgvProduct.Columns["Price"].DefaultCellStyle.Format = "#,##0 ₫";
            if (dgvProduct.Columns.Contains("Amount"))
                dgvProduct.Columns["Amount"].DefaultCellStyle.Format = "#,##0 ₫";
            if (dgvProduct.Columns.Contains("BasePrice"))
                dgvProduct.Columns["BasePrice"].DefaultCellStyle.Format = "#,##0 ₫";
            if (dgvProduct.Columns.Contains("Wage"))
                dgvProduct.Columns["Wage"].DefaultCellStyle.Format = "#,##0 ₫";

            dgvProduct.AllowUserToAddRows = false;


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
       
        private void btnPayment_Paint(object sender, PaintEventArgs e)
        {
           
        }
        //btn Payment
        private void btnPayment_Click(object sender, EventArgs e)
        {
            // Tạo danh sách sản phẩm từ dgv
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;

                orderItems.Add(new OrderItem
                {
                    ID = productBLL.GetProductIDByName(row.Cells["Product"].Value?.ToString()),
                    Name = row.Cells["Product"].Value?.ToString(),
                    Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                    Weight = row.Cells["Weight"].Value?.ToString(),
                    Wage = Convert.ToDecimal(row.Cells["Wage"].Value ?? 0),
                    BasePrice = Convert.ToDecimal(row.Cells["BasePrice"].Value ?? 0),
                    Price = Convert.ToDecimal(row.Cells["Price"].Value ?? 0),
                    Amount = Convert.ToDecimal(row.Cells["Amount"].Value ?? 0)
                });
            }

            // Mở form hóa đơn
            Payment_Sale_invoice frmInvoice = new Payment_Sale_invoice(orderItems);
            frmInvoice.InvoicePrinted += (s, ev) =>
            {
                dgvProduct.Rows.Clear();
                lblSubtotal.Text = "0 ₫";
                lblTotal.Text = "0 ₫";
            };
            frmInvoice.ShowDialog();
        }

        private void dgvProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProduct.Columns[e.ColumnIndex].Name == "Quantity")
                {
                    DataGridViewRow row = dgvProduct.Rows[e.RowIndex];

                    string productID = row.Cells["Product"].Tag?.ToString();
                    if (string.IsNullOrEmpty(productID))
                    {
                        MessageBox.Show("Invalid product reference.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var product = productBLL.GetProductByID(productID);
                    if (product == null)
                    {
                        MessageBox.Show("Product not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int newQty))
                    {
                        MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["Quantity"].Value = 1;
                        return;
                    }

                    if (newQty == 0)
                    {
                        dgvProduct.Rows.RemoveAt(e.RowIndex);
                        UpdateTotal();
                        return;
                    }

                    int stock = productBLL.GetStockByProductID(productID); 

                    if (newQty > stock)
                    {
                        MessageBox.Show($"Not enough stock. Only {stock} items available.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["Quantity"].Value = stock;
                        newQty = stock;
                    }

                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
                    row.Cells["Amount"].Value = newQty * price;

                    UpdateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating quantity: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToUpper();
            LoadProductList(keyword);
        }
    }
}
