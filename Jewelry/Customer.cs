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

            Info.BackColor = Color.Transparent;
            Info.ForeColor = Color.Red;
            LoadUserControl(new InformationCustomer());
            membershipClass1.Visible = false;
        }

        private void MembershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNCustomer.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            Membership.BackColor = Color.Transparent;
            Membership.ForeColor = Color.Red;
            LoadUserControl(new MembershipClass());
            informationCustomer1.Visible = false;
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

        private void Customer_Load(object sender, EventArgs e)
        {
            informationCustomer1.Visible = true;
            membershipClass1.Visible = false;
        }
    }
}
