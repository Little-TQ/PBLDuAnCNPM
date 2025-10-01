using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.Account;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            SetupPermissions();
        }
        private void lblAccount_Click_1(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Account") == true)
            {
                Page_Account frm = new Page_Account();
                frm.ShowDialog();
            }
        }

        private void SetupPermissions()
        {

            // Ẩn tất cả các label navigation trước
            lblAccount.Visible = false;
            lblOverview.Visible = false;
            lblProduct.Visible = false;
            lblCustomer.Visible = false;
            lblEmployee.Visible = false;
            lblPayment.Visible = false;
            lblInvoice.Visible = false;
            lblUpdate.Visible = false;

            var currentUser = Session.CurrentUser;

            if (currentUser?.Permissions == null)
            {
                return; // Không có permission thì ẩn hết
            }

            foreach (string permission in currentUser.Permissions)
            {
                switch (permission)
                {
                    case "Account": lblAccount.Visible = true; break;
                    case "Overview": lblOverview.Visible = true; break;
                    case "Product": lblProduct.Visible = true; break;
                    case "Customer": lblCustomer.Visible = true; break;
                    case "Employee": lblEmployee.Visible = true; break;
                    case "Payment": lblPayment.Visible = true; break;
                    case "Invoice": lblInvoice.Visible = true; break;
                    case "Update": lblUpdate.Visible = true; break;
                }
            }
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null; // clear session
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void lblOverview_Click(object sender, EventArgs e)
        {
            Page_Overview frm = new Page_Overview();
            frm.ShowDialog();

        }

        private void lblProduct_Click(object sender, EventArgs e)
        {
            Product_View frm = new Product_View();
            frm.ShowDialog();
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {
            Customer frm = new Customer();
            frm.ShowDialog();
        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.ShowDialog();
        }

        private void lblInvoice_Click(object sender, EventArgs e)
        {
            Import_Invoice frm = new Import_Invoice(); 
            frm.ShowDialog();
        }

        private void lblPayment_Click(object sender, EventArgs e)
        {
            
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            UpdatePrice frm = new UpdatePrice();
            frm.ShowDialog();

        }
    }
}
