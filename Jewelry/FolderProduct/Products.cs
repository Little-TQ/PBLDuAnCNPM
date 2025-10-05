using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry.FolderProduct
{
    public partial class Products : UserControl
    {
        private ProductBLL productBLL = new ProductBLL();
        private string selectedProductID = null;

        public Products()
        {
            InitializeComponent();
        }
        private void Products_Load(object sender, EventArgs e)
        {
            LoadProducts();

            // Định dạng cột Price và Wage dạng tiền tệ VNĐ
            dgvProduct.Columns["Price"].DefaultCellStyle.Format = "#,##0 ₫";
            dgvProduct.Columns["Wage"].DefaultCellStyle.Format = "#,##0 ₫";

            dgvProduct.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduct.Columns["Wage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
       
        //Show the thumbnail instead of the photo path
        private void ShowThumnail()
        {
            if (dgvProduct.Columns.Contains("Photo"))
                dgvProduct.Columns["Photo"].Visible = false;

            if (!dgvProduct.Columns.Contains("Thumnail"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.HeaderText = "Photo";
                imgCol.Name = "Thumnail";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvProduct.Columns.Add(imgCol);
            }

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;

                string relPath = row.Cells["Photo"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(relPath))
                    continue;

                string fullPath = Path.Combine(Application.StartupPath, relPath);
                if (File.Exists(fullPath))
                {
                    using (Image img = Image.FromFile(fullPath))
                    {
                        row.Cells["Thumnail"].Value = img.GetThumbnailImage(50,50, null, IntPtr.Zero);
                    }
                }
                else
                {
                    Bitmap bmp = new Bitmap(50, 50);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.LightGray);
                        g.DrawString("No Img", SystemFonts.DefaultFont, Brushes.Black, 5, 25);
                    }
                    row.Cells["Thumnail"].Value = bmp;
                }
            }
        }
        private void panelAdd_Click(object sender, EventArgs e)
        {
            Product_Add frm = new Product_Add();
            frm.FormClosed += (s, args) => LoadProducts();
            frm.ShowDialog();
        }

        public void LoadProducts()
        {
            dgvProduct.DataSource = productBLL.GetAllProducts();


            //Auto resize columns to fit content
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvProduct.RowTemplate.Height = 40;

            dgvProduct.ScrollBars = ScrollBars.Both;

            lblTotal.Text = "Total Product: " + dgvProduct.Rows.Count.ToString();
            dgvProduct.ClearSelection();
        }
        //btn AddNew to open form Add
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Product_Add formAdd = new Product_Add();
            formAdd.FormClosed += (s, args) => LoadProducts(); // Reload lại danh sách khi đóng
            formAdd.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedProductID = dgvProduct.Rows[e.RowIndex].Cells["ID"].Value?.ToString();
            }
        }
        //btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (productBLL.DeleteProduct(selectedProductID))
                    {
                        MessageBox.Show("Product deleted successfully.");
                        foreach (DataGridViewRow row in dgvProduct.Rows)
                        {
                            if (row.Cells["ID"].Value.ToString() == selectedProductID)
                            {
                                dgvProduct.Rows.Remove(row);
                                break;
                            }
                        }

                        selectedProductID = null; // Clear selection after deletion
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the product.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            int savedCount = 0;
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder
                if (row.Cells["ID"].Value == null || string.IsNullOrWhiteSpace(row.Cells["ID"].Value.ToString()))
                    continue;
                try
                {
                    ProductDTO product = new ProductDTO(
                        row.Cells["ID"].Value?.ToString(),
                        row.Cells["Name"].Value?.ToString(),
                        Convert.ToDecimal(row.Cells["Price"].Value ?? 0),
                        Convert.ToDecimal(row.Cells["Wage"].Value ?? 0),
                        Convert.ToInt32(row.Cells["Sold"].Value ?? 0),
                        Convert.ToInt32(row.Cells["Instock"].Value ?? 0),
                        row.Cells["Category"].Value?.ToString(),
                        row.Cells["Material"].Value?.ToString(),
                        row.Cells["Color"].Value?.ToString(),
                        row.Cells["Collection"].Value?.ToString(),
                        row.Cells["Gender"].Value?.ToString(),
                        Convert.ToDouble(row.Cells["Weight"].Value ?? 0),
                        Convert.ToDouble(row.Cells["Size"].Value ?? 0),
                        row.Cells["Photo"].Value?.ToString()
                    );
                    productBLL.EditProduct(product);
                    savedCount++;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Save error: " + ex.Message);
                }
            }
            MessageBox.Show("Save suscessfully");
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvProduct_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ShowThumnail();
        }

        //Open form edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            Product_Edit editForm = new Product_Edit(selectedProductID, this);
            editForm.ShowDialog();
        }
    }

}

