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
    public partial class DashBoard: Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        private void lblAccount_Click(object sender, EventArgs e)
        {
            Page_Account frm = new Page_Account();
            this.Hide();
            frm.ShowDialog();
        }
        private void btnExitDashBoard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblOverview_Click(object sender, EventArgs e)
        {
            Page_Account frm = new Page_Account();
            this.Hide();
            frm.ShowDialog();
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            UpdatePrice frm = new UpdatePrice(); 
            this.Hide();
            frm.ShowDialog();
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            this.Hide();
            frm.ShowDialog();   
        }

        private void lblProduct_Click(object sender, EventArgs e)
        {
            Product_View frm = new Product_View();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
