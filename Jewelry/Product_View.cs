using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Jewelry
{
    public partial class Product_View : Form
    {
        public Product_View()
        {
            InitializeComponent();
            
        }


        private void Product_View_Load(object sender, EventArgs e)
        {
            products1.Visible = true;
            property1.Visible = false;
        }
        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            products1.Visible = true;
            property1.Visible = false;

        }
        private void btnEditProperty_Click(object sender, EventArgs e)
        {
           products1.Visible = true;
              property1.Visible = true;
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
    }
}
