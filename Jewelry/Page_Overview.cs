using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.Account;
using Jewelry.Overview;

namespace Jewelry
{
    public partial class Page_Overview: Form
    {
        public Page_Overview()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainerOverview.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainerOverview.Controls.Add(uc);
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new General());
        }

        private void SoldProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNOverview.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            SoldProductToolStripMenuItem.BackColor = Color.Transparent;
            SoldProductToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new SoldProduct());
        }

        private void RevenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ToolStripMenuItem item in mstNOverview.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            RevenuToolStripMenuItem.BackColor = Color.Transparent;
            RevenuToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new Revenu());
        }

        private void btnExitOverview_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnOverview_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void wareHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm= new Invoice();
            this.Hide();
            frm.ShowDialog();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Page_Account frm= new Page_Account();
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

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee frm= new Employee();
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
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
