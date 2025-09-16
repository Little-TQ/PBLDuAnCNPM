using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry.Account
{
    public partial class ManageAccount: UserControl
    {
        public ManageAccount()
        {
            InitializeComponent();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AddAccount adc = new AddAccount();
            adc.btnEditAccount.Visible = false;
            adc.ShowDialog();
        }
    }
}
