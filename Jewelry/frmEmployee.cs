using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.FolderEmployee;

namespace Jewelry
{
    public partial class frmEmployee: Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainerEmployee.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainerEmployee.Controls.Add(uc);
        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNEmployee.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            InformationToolStripMenuItem.BackColor = Color.Transparent;
            InformationToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new InformationEmployee());
        }

        private void SalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNEmployee.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            SalaryToolStripMenuItem.BackColor = Color.Transparent;
            SalaryToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new Salary());
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNEmployee.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            scheduleToolStripMenuItem.BackColor = Color.Transparent;
            scheduleToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new Schedule());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNEmployee.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            homeToolStripMenuItem.BackColor = Color.Transparent;
            homeToolStripMenuItem.ForeColor = Color.Red;
        }
    }
}
