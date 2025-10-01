using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;
using Jewelry.Account;
namespace Jewelry
{
    public partial class Page_Account : Form
    {
        public Page_Account()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();     
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);     
        }
        private void Account_Load(object sender, EventArgs e)
        {
            LoadUserControl(new General());
        }
        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNAccount.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            homeToolStripMenuItem.BackColor = Color.Transparent;
            homeToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new General());

        }
        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNAccount.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            accountToolStripMenuItem.BackColor = Color.Transparent;
            accountToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new ManageAccount());
        }
        private void paymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNAccount.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            paymentToolStripMenuItem.BackColor = Color.Transparent;
            paymentToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new Provide_Permission());
        }
        
        private void btnExitAccount_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
