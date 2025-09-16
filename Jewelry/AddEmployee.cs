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
    public partial class AddEmployee: Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnExitAddEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnAddE_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
