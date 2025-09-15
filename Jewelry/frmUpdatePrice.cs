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
    public partial class frmUpdatePrice: Form
    {
        public frmUpdatePrice()
        {
            InitializeComponent();
        }

        private void dataGridViewChangePrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExitUpDate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnUpDate_Click(object sender, EventArgs e)
        {
            frmDashBoard frm = new frmDashBoard();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
