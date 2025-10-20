using Jewelry.BLL;
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

namespace Jewelry.Payment
{
    public partial class Sale : UserControl
    {
        private PropertyBLL propertyBLL = new PropertyBLL();
        public Sale()
        {
            InitializeComponent();
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

                //Search idMaterial
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
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sale_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }
    }
}
