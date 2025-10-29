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
using Jewelry.FolderEmployee;

namespace Jewelry
{
    public partial class Employee: Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainerEmployee.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainerEmployee.Controls.Add(uc);
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            LoadUserControl(new General());
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Transfer another form
        private void wareHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm = new Invoice();
            this.Hide();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Page_Account frm = new Page_Account();
            this.Hide();
            frm.ShowDialog();
        }

        private void overviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Page_Overview frm = new Page_Overview();
            this.Hide();
            frm.ShowDialog();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product_View frm= new Product_View();
            this.Hide();
            frm.ShowDialog();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            this.Hide();
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            this.Hide();
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePrice frm = new UpdatePrice();
            this.Hide();
            frm.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }


        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

       
    }
}
