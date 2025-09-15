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
    public partial class frmDashBoard: Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }
        private void lblAccount_Click(object sender, EventArgs e)
        {
            frmAccount frm = new frmAccount();
            this.Hide();
            frm.ShowDialog();
        }
        private void btnExitDashBoard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblOverview_Click(object sender, EventArgs e)
        {
            frmOverview frm = new frmOverview();
            this.Hide();
            frm.ShowDialog();
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            frmUpdatePrice frm = new frmUpdatePrice(); 
            this.Hide();
            frm.ShowDialog();
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            this.Hide();
            frm.ShowDialog();   
        }
    }
}
