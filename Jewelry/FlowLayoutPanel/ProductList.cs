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

namespace Jewelry.FlowLayoutPanel
{
    
    public partial class ProductList : UserControl
    {
        public string ProductID { get; set; }
        public ProductList()
        {
            InitializeComponent();
        }
        public void SetProductData(string id, string name, decimal price, string mat, string photoPath)
        {
            ProductID = id;
            lblID.Text = id;
            lblName.Text = name;
            lblMaterial.Text = mat;
            lblPrice.Text = $"{price:N0}";

            try
            {
                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                {
                    Photo.Image = Image.FromFile(photoPath);
                }
                else
                {
                    Photo.Image = null;
                    Photo.BackColor = Color.LightGray;

                }
            }
            catch
            {
                Photo.Image = null;
                Photo.BackColor = Color.LightGray;

            }
        }
        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void ProductList_Load(object sender, EventArgs e)
        {

        }
    }
}
