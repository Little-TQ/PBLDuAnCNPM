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
using System.Security.Principal;

namespace Jewelry
{
    public partial class AddAccount : Form
    {
        private string currentIdAccount = null;
        private bool isEditMode = false;

        public AddAccount()
        {
            InitializeComponent();
            LoadRoles();
            btnEditAccount.Click += btnEditAccount_Click;
        }
        public AddAccount(string idAccount, string username, string password, string roleName, bool isActive, bool isReadOnly) : this()
        {
            currentIdAccount = idAccount;
            txtUsernameA.Text = username;
            txtPasswordA.Text = password;
            cbxRoleA.SelectedValue = roleName;
            chkIsActiveA.Checked = isActive;
            SetReadOnly(isReadOnly);
        }
        private void SetReadOnly(bool isReadOnly)
        {
            txtUsernameA.ReadOnly = isReadOnly;
            txtPasswordA.ReadOnly = isReadOnly;
            cbxRoleA.Enabled = !isReadOnly;
            chkIsActiveA.Enabled = !isReadOnly;
            btnCompleteAddA.Enabled = !isReadOnly;
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
                string username = txtUsernameA.Text.Trim();
                string password = txtPasswordA.Text;
                string roleName = cbxRoleA.SelectedValue?.ToString();
                bool isActive = chkIsActiveA.Checked;

                AccountBLL accountBLL = new AccountBLL();
                bool success;

                if (isEditMode && !string.IsNullOrEmpty(currentIdAccount))
                {
                    // Update
                    AccountDTO updatedAccount = new AccountDTO(currentIdAccount, username, password, roleName, isActive);
                    success = accountBLL.UpdateAccount(updatedAccount);
                }
                else
                {
                    // Add new
                    string newId = accountBLL.GenerateNewAccountId();
                    AccountDTO newAccount = new AccountDTO(newId, username, password, roleName, isActive);
                    success = accountBLL.AddAccount(newAccount);
                }

                if (success)
                {
                    MessageBox.Show(isEditMode ? "Account success updated!" : "Account success added!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            SetReadOnly(false);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
