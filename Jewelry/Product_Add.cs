using Jewelry.BLL;
using Jewelry.DAL;
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
    public partial class Product_Add : Form
    {
        private ProductBLL productBLL = new ProductBLL();
        private Products parentForm; // Tham chiếu đến form cha
        private PropertyBLL propertyBLL = new PropertyBLL();
        private string selectedImagePath = null; //Photo path
        private string savedImagePath = null;     //Path in DB

        public Product_Add(Products parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }
        public Product_Add()
        {
            InitializeComponent();
        }
        //Form Load
        private void Product_Add_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

        }
       
        //btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtNameP.Text))
                {
                    MessageBox.Show("Please enter product name.");
                    return;
                }
                if (cbCategory.SelectedValue == null || cbMaterial.SelectedValue == null)
                {
                    MessageBox.Show("Please select Category and Material.");
                    return;
                }

                // Generate new ID
                string categoryName = cbCategory.Text;
                string materialName = cbMaterial.Text;
                string newId = productBLL.GenerateProductID(categoryName, materialName);

                string photoFolder = Path.Combine(Application.StartupPath, "Product Photo");
                if (!Directory.Exists(photoFolder))
                    Directory.CreateDirectory(photoFolder);

                string relativePath = null;
                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    string photoFileName = newId + Path.GetExtension(selectedImagePath);
                    string photoFullPath = Path.Combine(photoFolder, photoFileName);
                    File.Copy(selectedImagePath, photoFullPath, true);
                    relativePath = Path.Combine("Product Photo", photoFileName);
                }

                ProductDTO product = new ProductDTO(
                    newId,
                    txtNameP.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtPrice.Text) ? null : (decimal?)decimal.Parse(txtPrice.Text),
                    string.IsNullOrWhiteSpace(txtWage.Text) ? null : (decimal?)decimal.Parse(txtWage.Text),
                    0,
                    string.IsNullOrWhiteSpace(txtStock.Text) ? 0 : int.Parse(txtStock.Text),
                    cbCategory.SelectedValue?.ToString(),
                    cbMaterial.SelectedValue?.ToString(),
                    cbColor.SelectedValue?.ToString(),
                    cbCollection.SelectedValue == null ? null : cbCollection.SelectedValue.ToString(),
                    cbGender.Text,
                    string.IsNullOrWhiteSpace(txtWeight.Text) ? null : (double?)double.Parse(txtWeight.Text),
                    string.IsNullOrWhiteSpace(txtSize.Text) ? null : (double?)double.Parse(txtSize.Text),
                    relativePath 
                );

                if (productBLL.AddNewProduct(product))
                {
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (parentForm != null)
                        parentForm.LoadProducts();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("❌ Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving product:\n" + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            combo.SelectedIndex = -1; // Không chọn mặc định
        }

        //Close
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //btn Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog()) { 
                openFile.Filter= "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFile.Title = "Choose the product photo";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFile.FileName;
                    Photo.Image= Image.FromFile(selectedImagePath);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
