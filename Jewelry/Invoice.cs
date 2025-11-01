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
using Jewelry.FolderCustomer;
using Jewelry.FolderImportInvoice;

namespace Jewelry
{
    public partial class Invoice: Form
    {
        public Invoice()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainerInvoice.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainerInvoice.Controls.Add(uc);
        }
        private void Invoice_Load(object sender, EventArgs e)
        {
            LoadUserControl(new General());
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
            UpdatePrice frm= new UpdatePrice();
            this.Hide();
            frm.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }
        
        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            Export.BackColor = Color.Transparent;
            Export.ForeColor = Color.Red;
            LoadUserControl(new ExportInvoice());
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            Import.BackColor = Color.Transparent;
            Import.ForeColor = Color.Red;
            LoadUserControl(new ImportInvoice());
        }

        private void preOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            preOrder.BackColor = Color.Transparent;
            preOrder.ForeColor = Color.Red;
            LoadUserControl(new FollowItems());
        }
    }
}
