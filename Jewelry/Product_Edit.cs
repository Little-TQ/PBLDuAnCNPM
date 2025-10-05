using Jewelry.BLL;
using Jewelry.DTO;
using Jewelry.FolderProduct;
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

namespace Jewelry
{
    public partial class Product_Edit : Form
    {
        private ProductBLL productBLL = new ProductBLL();
        private PropertyBLL propertyBLL = new PropertyBLL();
        private string idProduct;
        private string selectedImagePath;
        private string savedImagePath;
        private Products parentForm;


        private readonly string _idProduct;
        private readonly Products _parent;

        public Product_Edit()
        {
            InitializeComponent();
        }
        public Product_Edit(string id, Products parent)
        {
            InitializeComponent();
            idProduct = id;
            parentForm = parent;
        }
        private void Product_EditProduct_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadProductInfo();
        }
        //Load combobox
        private void LoadComboBoxes()
        {
            LoadComboBox(cbCategory, "Category", "idCategory", "NameCategory");
            LoadComboBox(cbMaterial, "Material", "idMaterial", "NameMaterial");
            LoadComboBox(cbColor, "Color", "idColor", "NameColor");
            LoadComboBox(cbCollection, "Collection", "idCollection", "NameCollection");
        }
        private void LoadComboBox(ComboBox combo, string tableName, string valueMember, string displayMember)
        {
            DataTable dt = propertyBLL.GetPropertyData(tableName);
            combo.DataSource = dt;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
        }
        //Load information of product
        private void LoadProductInfo()
        {
            var product = productBLL.GetProductByID(idProduct);

            if (product == null)
            {
                MessageBox.Show("Product not found!");
                this.Close();
                return;
            }

            // Binding data
            txtNameP.Text = product.NameProduct;
            txtPrice.Text = product.PriceSilver?.ToString();
            txtWage.Text = product.Wage?.ToString();
            txtStock.Text = product.Instock.ToString();
            txtWeight.Text = product.Weight?.ToString();
            txtSize.Text = product.Size?.ToString();
            cbGender.Text = product.Gender;

            SafeSelect(cbCategory, product.idCategory);
            SafeSelect(cbMaterial, product.idMaterial);
            SafeSelect(cbColor, product.idColor);
            SafeSelect(cbCollection, product.idCollection);

            savedImagePath = product.Photo;

            if (!string.IsNullOrEmpty(savedImagePath))
            {
                string fullPath = Path.Combine(Application.StartupPath, savedImagePath);
                if (File.Exists(fullPath))
                {
                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        Photo.Image = Image.FromStream(fs);
                    }
                }
            }
        }
        private void SafeSelect(ComboBox cb, string value)
        {
            if (cb == null) return;

            if (string.IsNullOrWhiteSpace(value))
            {
                cb.SelectedIndex = -1; // Không chọn gì
                return;
            }

            try
            {
                cb.SelectedValue = value;
            }
            catch
            {
                // Nếu value không tồn tại trong danh sách
                cb.SelectedIndex = -1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        //Btn Save
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            string newPhotoPath = savedImagePath;
            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                string photoFolder = Path.Combine(Application.StartupPath, "Product Photo");
                if (!Directory.Exists(photoFolder))
                    Directory.CreateDirectory(photoFolder);

                string photoFileName = idProduct + Path.GetExtension(selectedImagePath);
                string photoFullPath = Path.Combine(photoFolder, photoFileName);

                File.Copy(selectedImagePath, photoFullPath, true);

                newPhotoPath = Path.Combine("Product Photo", photoFileName);
            }
            if (string.IsNullOrEmpty(newPhotoPath))
                newPhotoPath = "Product Photo\\NoImage.png";
            try
            {
                ProductDTO updated = new ProductDTO(
                    idProduct,
                    txtNameP.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtPrice.Text) ? null : (decimal?)decimal.Parse(txtPrice.Text),
                    string.IsNullOrWhiteSpace(txtWage.Text) ? null : (decimal?)decimal.Parse(txtWage.Text),
                    0,
                    int.Parse(txtStock.Text),
                    cbCategory.SelectedValue?.ToString(),
                    cbMaterial.SelectedValue?.ToString(),
                    cbColor.SelectedValue?.ToString(),
                    cbCollection.SelectedValue == null ? null : cbCollection.SelectedValue.ToString(),
                    cbGender.Text,
                    string.IsNullOrWhiteSpace(txtWeight.Text) ? null : (double?)double.Parse(txtWeight.Text),
                    string.IsNullOrWhiteSpace(txtSize.Text) ? null : (double?)double.Parse(txtSize.Text),
                    newPhotoPath
                );

                if (productBLL.EditProduct(updated))
                {
                    MessageBox.Show("Product updated successfully!", "Success");
                    parentForm.LoadProducts();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed!", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFile.Title = "Choose the product photo";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFile.FileName;
                    Photo.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
