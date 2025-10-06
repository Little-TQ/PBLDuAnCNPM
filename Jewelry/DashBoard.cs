using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
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
            mstDashBoard.BackColor = Color.Transparent;
            mstDashBoard.Renderer = new TransparentMenuRenderer();

        }
        private class TransparentMenuRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                // Không vẽ gì cả => để lộ nền phía sau
                e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), e.AffectedBounds);
            }
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                // không vẽ nền khi hover => menu trong suốt
                if (e.Item.Selected || e.Item.Pressed)
                {
                    
                    e.Item.ForeColor = Color.FromArgb(27, 56, 59);
                }
                else
                {
                    e.Item.ForeColor = Color.White; 
                }
            }
        }
        private void SetupPermissions()
        {
            var currentUser = Session.CurrentUser;

            if (currentUser?.Permissions == null)
            {
                // Nếu không có quyền gì thì disable hết
                foreach (ToolStripMenuItem item in mstDashBoard.Items)
                {
                    item.Enabled = false;
                }
                return;
            }

            // Reset tất cả menu => disable trước
            foreach (ToolStripMenuItem item in mstDashBoard.Items)
            {
                item.Enabled = false;
                item.ForeColor = Color.Gray;   // màu mờ khi không có quyền
            }

            // Duyệt quyền của user để bật menu
            foreach (string permission in currentUser.Permissions)
            {
                switch (permission)
                {
                    case "Account":
                        accountToolStripMenuItem1.Enabled = true;
                        accountToolStripMenuItem1.ForeColor = Color.White;
                        break;
                    case "Overview":
                        overviewToolStripMenuItem2.Enabled = true;
                        overviewToolStripMenuItem2.ForeColor = Color.White;
                        break;
                    case "Product":
                        productToolStripMenuItem2.Enabled = true;
                        productToolStripMenuItem2.ForeColor = Color.White;
                        break;
                    case "Customer":
                        customerToolStripMenuItem2.Enabled = true;
                        customerToolStripMenuItem2.ForeColor = Color.White;
                        break;
                    case "Employee":
                        employeeToolStripMenuItem2.Enabled = true;
                        employeeToolStripMenuItem2.ForeColor = Color.White;
                        break;
                    case "Payment":
                        paymentToolStripMenuItem1.Enabled = true;
                        paymentToolStripMenuItem1.ForeColor = Color.White;
                        break;
                    case "Invoice":
                        invoiceToolStripMenuItem.Enabled = true;
                        invoiceToolStripMenuItem.ForeColor = Color.White;
                        break;
                    case "Update":
                        updateToolStripMenuItem1.Enabled = true;
                        updateToolStripMenuItem1.ForeColor = Color.White;
                        break;
                }
            }
        }
        private void accountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Account") == true)
            {
                Page_Account frm = new Page_Account();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void overviewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Overview") == true)
            {
                Page_Overview frm = new Page_Overview();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void picLogin_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null; // clear session
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
        private void productToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Product") == true)
            {
                Product_View frm = new Product_View();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void customerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Customer") == true)
            {
                Customer frm = new Customer();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void employeeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Employee") == true)
            {
                Employee frm = new Employee();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Payment") == true)
            {
                Payment_Sale_Select frm = new Payment_Sale_Select();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Invoice") == true)
            {
                Invoice frm = new Invoice();
                this.Hide();
                frm.ShowDialog();
            }
        }
        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser?.Permissions.Contains("Update") == true)
            {
                UpdatePrice frm = new UpdatePrice();
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}
