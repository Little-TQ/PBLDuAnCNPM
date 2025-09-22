using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.DAL;
using Jewelry.Account;
using Jewelry.DTO;
using Jewelry.BLL;

namespace Jewelry
{
    public partial class AddAccount : Form
    {
        AccountDAL accountDAL = new AccountDAL();
        public AddAccount()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            AccountBLL accountBLL = new AccountBLL();
            DataTable roles = accountBLL.GetAllRoles();
            cbxRoleA.DataSource = roles;
            cbxRoleA.DisplayMember = "RoleName";
            cbxRoleA.ValueMember = "RoleName"; // or "idRole" if you want to use the ID
            cbxRoleA.SelectedIndex = -1; // No selection by default
        }

        private void btnCompleteAddA_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect data from controls
                string username = txtUsernameA.Text.Trim();
                string password = txtPasswordA.Text;
                string roleName = cbxRoleA.SelectedValue?.ToString();
                bool isActive = chkIsActiveA.Checked;

                // Generate new account ID
                AccountBLL accountBLL = new AccountBLL();
                string newId = accountBLL.GenerateNewAccountId();

                // Create DTO
                AccountDTO newAccount = new AccountDTO(newId, username, password, roleName, isActive);

                // Add account
                bool success = accountBLL.AddAccount(newAccount);

                if (success)
                {
                    MessageBox.Show("Account added successfully!");

                    // Open ManageAccount and refresh DataGridView
                    var manageAccount = new ManageAccount();
                    manageAccount.Show();
                    manageAccount.LoadAccounts(); // Ensure this method reloads the DataGridView

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add account.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnReturnAddA_Click(object sender, EventArgs e)
        {
            Page_Account acc = new Page_Account();
            this.Hide();
            acc.ShowDialog();
        }

        private void btnExitAddAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
