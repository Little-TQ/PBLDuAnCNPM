using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry.FolderEmployee
{
    public partial class InformationEmployee: UserControl
    {
        public InformationEmployee()
        {
            InitializeComponent();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            frmAddEmployee frm = new frmAddEmployee();
            frm.ShowDialog();
        }

    }
}
