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
            Customer frm = new Customer();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
