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
    public partial class EditInfoCustomer: Form
    {
        public EditInfoCustomer()
        {
            InitializeComponent();
        }

        private void btnExitEditCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnExitEditCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
