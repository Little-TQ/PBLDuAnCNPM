using Guna.UI2.WinForms;
using Jewelry.BLL;
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
    public partial class Product_View : Form
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        public Product_View()
        {
            InitializeComponent();
            
        }


        private void Product_View_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            products1.Visible = true;
            property1.Visible = false;
            products1.LoadProducts();
        }
        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            products1.Visible = true;
            property1.Visible = false;
            try
            {
                string category = cbCategory.Text.Trim();
                string material = cbMaterial.Text.Trim();
                string color = cbColor.Text.Trim();

                products1.FilterProducts(category, material, color);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering: " + ex.Message);
            }
        }
        private void btnEditProperty_Click(object sender, EventArgs e)
        {
           products1.Visible = true;
              property1.Visible = true;
        }
        //Load cb
        private void LoadComboBoxes()
        {
            try
            {
                // ---- CATEGORY ----
                DataTable dtCategory = propertyBLL.GetPropertyData("Category");
                DataRow allCat = dtCategory.NewRow();
                allCat["idCategory"] = DBNull.Value;
                allCat["NameCategory"] = "All";
                dtCategory.Rows.InsertAt(allCat, 0); // thêm "All" TRƯỚC khi gán datasource

                cbCategory.DataSource = dtCategory;
                cbCategory.DisplayMember = "NameCategory";
                cbCategory.ValueMember = "idCategory";
                cbCategory.SelectedIndex = 0;


                // ---- MATERIAL ----
                DataTable dtMaterial = propertyBLL.GetPropertyData("Material");
                DataRow allMat = dtMaterial.NewRow();
                allMat["idMaterial"] = DBNull.Value;
                allMat["NameMaterial"] = "All";
                dtMaterial.Rows.InsertAt(allMat, 0);

                cbMaterial.DataSource = dtMaterial;
                cbMaterial.DisplayMember = "NameMaterial";
                cbMaterial.ValueMember = "idMaterial";
                cbMaterial.SelectedIndex = 0;


                // ---- COLOR ----
                DataTable dtColor = propertyBLL.GetPropertyData("Color");
                DataRow allColor = dtColor.NewRow();
                allColor["idColor"] = DBNull.Value;
                allColor["NameColor"] = "All";
                dtColor.Rows.InsertAt(allColor, 0);

                cbColor.DataSource = dtColor;
                cbColor.DisplayMember = "NameColor";
                cbColor.ValueMember = "idColor";
                cbColor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading combo data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //btn Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            cbCategory.SelectedIndex = 0;
            cbMaterial.SelectedIndex = 0;
            cbColor.SelectedIndex = 0;

            products1.LoadProducts();
        }

        //Transfer another form
        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page_Account frm= new Page_Account();
            this.Hide();
            frm.ShowDialog();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page_Overview frm= new Page_Overview();
            this.Hide();
            frm.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer frm= new Customer();
            this.Hide();
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            this.Hide();
            frm.ShowDialog();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm= new Invoice();
            this.Hide();
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePrice frm = new UpdatePrice();
            this.Hide();
            frm.ShowDialog();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm= new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void property1_Load(object sender, EventArgs e)
        {

        }
        private void product1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void navbar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
