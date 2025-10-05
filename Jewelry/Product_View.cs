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

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }

        private void repurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Repurchase_Select frm= new Payment_Repurchase_Select();
            this.Hide();
            frm.ShowDialog();
        }

        private void preOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_PreOrder_Select frm= new Payment_PreOrder_Select();
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
    }
}
