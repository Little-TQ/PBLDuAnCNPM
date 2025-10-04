using Jewelry.BLL;
using Jewelry.DAL;
using Jewelry.DTO;
using Jewelry.FolderProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Product_Add(Products parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }
        public Product_Add()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = cbCategory.Text;
                string materialName = cbMaterial.Text;

                //Genrate new ID
                string newId = productBLL.GenerateProductID(categoryName, materialName);

                // Genrate new product object
                ProductDTO product = new ProductDTO(
                    newId,
                    txtNameP.Text,
                    string.IsNullOrWhiteSpace(txtPrice.Text) ? null : (decimal?)decimal.Parse(txtPrice.Text),
                    string.IsNullOrWhiteSpace(txtWage.Text) ? null : (decimal?)decimal.Parse(txtWage.Text),
                    0,
                    int.Parse(txtStock.Text),
                    cbCategory.SelectedValue.ToString(),  // ID Category
                    cbMaterial.SelectedValue.ToString(),  // ID Material
                    cbColor.SelectedValue.ToString(),     // ID Color
                    cbCollection.SelectedValue.ToString(),// ID Collection
                    cbGender.Text,
                    string.IsNullOrWhiteSpace(txtWeight.Text) ? null : (double?)double.Parse(txtWeight.Text),
                    string.IsNullOrWhiteSpace(txtSize.Text) ? null : (double?)double.Parse(txtSize.Text),
                    "abc.png" // Placeholder for Photo

                );

                if (productBLL.AddNewProduct(product))
                {
                    MessageBox.Show("Add Product Suscessfully!");
                    parentForm.LoadProducts(); // gọi lại form cha để refresh dgv
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Product_Add_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

        }
    }
}
