using Jewelry.BLL;
using Jewelry.DTO;
using System;
using System.Data;
using System.Drawing;
using System.IO;
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

            dgvProduct.DataBindingComplete += dgvProduct_DataBindingComplete;
        }

        // Load 
        public void LoadProducts()
        {
            dgvProduct.DataSource = productBLL.GetAllProducts();

            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProduct.RowTemplate.Height = 60;
            dgvProduct.ScrollBars = ScrollBars.Both;

            if (dgvProduct.Columns.Contains("Price"))
            {
                dgvProduct.Columns["Price"].DefaultCellStyle.Format = "#,##0 ₫";
                dgvProduct.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvProduct.Columns.Contains("Wage"))
            {
                dgvProduct.Columns["Wage"].DefaultCellStyle.Format = "#,##0 ₫";
                dgvProduct.Columns["Wage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            lblTotal.Text = "Total Product: " + dgvProduct.Rows.Count;
            ShowThumbnail();
        }

        //Thumbnail 
        private void ShowThumbnail()
        {
            if (dgvProduct.Columns.Contains("Photo"))
                dgvProduct.Columns["Photo"].Visible = false;

            if (!dgvProduct.Columns.Contains("Thumbnail"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Thumbnail",
                    HeaderText = "Photo",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvProduct.Columns.Insert(0, imgCol);
            }

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;

                string relativePath = row.Cells["Photo"].Value?.ToString();
                string fullPath = string.Empty;

                if (!string.IsNullOrEmpty(relativePath))
                {
                    fullPath = Path.IsPathRooted(relativePath)
                        ? relativePath
                        : Path.Combine(Application.StartupPath, relativePath);
                }

                Image thumb;
                if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
                {
                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        thumb = Image.FromStream(fs);
                    }
                }
                else
                {
                    // ảnh mặc định khi không có
                    thumb = new Bitmap(50, 50);
                    using (Graphics g = Graphics.FromImage(thumb))
                    {
                        g.Clear(Color.LightGray);
                        g.DrawString("No Img", SystemFonts.DefaultFont, Brushes.DarkGray, new PointF(5, 15));
                    }
                }

                row.Cells["Thumbnail"].Value = thumb.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            }
        }

        // Click dgv  
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                selectedProductID = row.Cells["ID"].Value?.ToString();
            }
        }

        // btn Add new
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Product_Add formAdd = new Product_Add(this);
            formAdd.ShowDialog();
        }

        //btn Edit 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
            {
                MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product_Edit formEdit = new Product_Edit(selectedProductID, this);
            formEdit.ShowDialog();
        }

        //btnDelete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedProductID))
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (productBLL.DeleteProduct(selectedProductID))
                    {
                        MessageBox.Show("✅ Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("❌ Failed to delete product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ShowThumbnail();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
