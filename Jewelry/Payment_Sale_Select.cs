using Jewelry;
using Jewelry.BLL;
using Jewelry.Flow_Layout_Panel;
using Jewelry.FlowLayoutPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Jewelry
{
    public partial class Payment_Sale_Select : Form
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        public Payment_Sale_Select()
        {
            InitializeComponent();
        }
        private void Payment_Sale_Select_Load(object sender, EventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        //Load Category list
        private void LoadCategoryList()
        {
            flowCategory.Controls.Clear();

            DataTable dt = propertyBLL.GetPropertyData("Category");
            foreach (DataRow row in dt.Rows)
            {
                string id = row["idCategory"].ToString();
                string name = row["NameCategory"].ToString();

                Category item = new Category();
                item.SetCategoryData(id, name);

                flowCategory.Controls.Add(item);
            }
        }
        //Load Product list
        private void LoadProductList()
        {
            flowProduct.Controls.Clear();

            DataTable dt = propertyBLL.GetPropertyData("Product");
            DataTable dtMaterial = propertyBLL.GetPropertyData("Material");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Product!");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                string id = row["idProduct"].ToString();
                string name = row["NameProduct"].ToString();
                decimal price = row["PriceSilver"] == DBNull.Value ? 0 : Convert.ToDecimal(row["PriceSilver"]);
                string photo = row["Photo"].ToString();
                string idMaterial = row["idMaterial"].ToString();

                // tìm tên chất liệu theo idMaterial
                string materialName = "";
                DataRow[] materialRows = dtMaterial.Select($"idMaterial = '{idMaterial}'");
                if (materialRows.Length > 0)
                {
                    materialName = materialRows[0]["NameMaterial"].ToString();
                }

                ProductList productItem = new ProductList();
                productItem.SetProductData(id, name, price, materialName, photo);

                productItem.Margin = new Padding(10);
                flowProduct.Controls.Add(productItem);
            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Page_Account frm = new Page_Account();
            this.Hide();
            frm.ShowDialog();
        }

        private void overviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Page_Overview frm = new Page_Overview();
            this.Hide();
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Employee frm= new Employee();
            this.Hide();
            frm.ShowDialog();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product_View frm= new Product_View();
            this.Hide();
            frm.ShowDialog();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer frm= new Customer();
            this.Hide();
            frm.ShowDialog();
        }

        private void wareHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm= new Invoice();
            this.Hide();
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePrice frm= new UpdatePrice();
            this.Hide();
            frm.ShowDialog();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm= new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void navbar_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
