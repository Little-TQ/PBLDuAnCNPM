using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry.FolderProduct
{
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        private void panelAdd_Click(object sender, EventArgs e)
        {
            Product_Add frm = new Product_Add();
            frm.ShowDialog();
        }
    }
}
