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
    }
}
