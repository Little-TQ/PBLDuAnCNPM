using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Jewelry.FlowLayoutPanel
{
    public partial class ProductList : UserControl
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string MaterialName { get; set; }

        public event EventHandler<ProductEventArgs> ProductAdded;

        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
        }
        private void btnAdd_Click(object sender, EventArgs e)
        { 
            ProductAdded?.Invoke(this, new ProductEventArgs(
                ProductID,
                lblName.Text,
                lblMaterial.Text
            ));
        }
        public void SetProductData(string id, string name, string mat, string photoPath)
        {
            ProductID = id;
            ProductName = name;
            MaterialName = mat;

            lblID.Text = id;
            lblName.Text = name;
            lblMaterial.Text = mat;

            try
            {
                string fullPath = Path.Combine(Application.StartupPath, photoPath ?? "");
                if (!string.IsNullOrEmpty(photoPath) && File.Exists(fullPath))
                {
                    Photo.Image = Image.FromFile(fullPath);
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class ProductEventArgs : EventArgs
    {
        public string ID { get; }
        public string Name { get; }
        public string Material { get; }
        public ProductEventArgs(string id, string name, string mat)
        {
            ID = id;
            Name = name;
            Material = mat;
        }
    }
}
