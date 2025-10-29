using Jewelry;
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
            sale1.Visible = false;
            repurchase1.Visible = false;
            preOrder1.Visible = false;
            
        }

        //Toolstrip Menu
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

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }

        private void mstNEmployee_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sale1.Visible = true;
            repurchase1.Visible = false;
            preOrder1.Visible = false;
            saleToolStripMenuItem.ForeColor = Color.Red;
            scheduleToolStripMenuItem.ForeColor = Color.Black;
            RepurchaseToolStripMenuItem.ForeColor = Color.Black;
        }

        private void SalaryToolStripMenuItem_Click(object sender, EventArgs e) //rEpurchase
        {
            repurchase1.Visible = true;
            preOrder1.Visible = false;
            sale1.Visible = false;
            RepurchaseToolStripMenuItem.ForeColor = Color.Red;
            saleToolStripMenuItem.ForeColor = Color.Black;
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preOrder1.Visible = true;
            sale1.Visible = false;
            repurchase1.Visible = false;
            scheduleToolStripMenuItem.ForeColor = Color.Red;
            saleToolStripMenuItem.ForeColor = Color.Black;
            RepurchaseToolStripMenuItem.ForeColor = Color.Black;
        }

        private void sale1_Load(object sender, EventArgs e)
        {

        }
    }
}
