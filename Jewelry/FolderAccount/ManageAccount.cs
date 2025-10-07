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
using Jewelry.BLL;

namespace Jewelry.Account
{
    public partial class ManageAccount : UserControl
    {
        AccountDAL accountDAL = new AccountDAL();
        public ManageAccount()
        {
            InitializeComponent();
            LoadAccounts();
            dgvManageAccount.CellDoubleClick += dataGridViewAccount_CellDoubleClick;
        }

        // Load dữ liệu vào DataGridView
        private void btnAddAccount_Click_1(object sender, EventArgs e)
        {
            AddAccount frm = new AddAccount();
            frm.btnEditAccount.Visible = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAccounts(); // load lại DataGridView
            }
        }
        // Load dữ liệu vào DataGridView
        public void LoadAccounts()
        {
            try
            {
                dgvManageAccount.DataSource = accountDAL.GetAllAccounts();

                // Đặt tên cột hiển thị
                if (dgvManageAccount.Columns.Count > 0)
                {
                    dgvManageAccount.Columns["idAccount"].HeaderText = "ID";
                    dgvManageAccount.Columns["Username"].HeaderText = "Username";
                    dgvManageAccount.Columns["Password"].HeaderText = "Password";
                    dgvManageAccount.Columns["RoleName"].HeaderText = "Role";
                    dgvManageAccount.Columns["IsActive"].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Nút Load
        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridViewAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get selected row
                DataGridViewRow row = dgvManageAccount.Rows[e.RowIndex];

                // Extract account info
                string idAccount = row.Cells["idAccount"].Value?.ToString();
                string username = row.Cells["Username"].Value?.ToString();
                string password = row.Cells["Password"].Value?.ToString();
                string roleName = row.Cells["RoleName"].Value?.ToString();
                bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);

                // Open AddAccount form with info, in read-only mode
                AddAccount frm = new AddAccount(idAccount, username, password, roleName, isActive, true); // true = read-only
                frm.btnEditAccount.Visible = true;
                frm.ShowDialog();

                // Optionally reload accounts after editing
                LoadAccounts();
            }
        }
        private void btnDeleteAccount_Click_1(object sender, EventArgs e)
        {
            if (dgvManageAccount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select accounts to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Delete {dgvManageAccount.SelectedRows.Count} selected accounts?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                AccountBLL accountBLL = new AccountBLL();

                foreach (DataGridViewRow row in dgvManageAccount.SelectedRows)
                {
                    string accountId = row.Cells["idAccount"].Value.ToString();
                    accountBLL.DeleteAccount(accountId);
                }

                MessageBox.Show("Accounts deleted successfully!");
                LoadAccounts(); // Refresh DataGridView
            }
        }

        private void ManageAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
