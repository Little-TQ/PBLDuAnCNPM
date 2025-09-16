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

namespace Jewelry
{
    public partial class Customer: Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainerCustomer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainerCustomer.Controls.Add(uc);
        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            InformationToolStripMenuItem.BackColor = Color.Transparent;
            InformationToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new InformationCustomer());
        }

        private void MembershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            MembershipToolStripMenuItem.BackColor = Color.Transparent;
            MembershipToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new MembershipClass());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            homeToolStripMenuItem.BackColor = Color.Transparent;
            homeToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new General());
        }

        private void btnExitCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnCustomer_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
