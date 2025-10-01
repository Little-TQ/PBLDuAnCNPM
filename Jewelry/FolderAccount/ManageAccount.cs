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
            dataGridViewAccount.CellDoubleClick += dataGridViewAccount_CellDoubleClick;
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
                dataGridViewAccount.DataSource = accountDAL.GetAllAccounts();

                // Đặt tên cột hiển thị
                if (dataGridViewAccount.Columns.Count > 0)
                {
                    dataGridViewAccount.Columns["idAccount"].HeaderText = "Mã TK";
                    dataGridViewAccount.Columns["Username"].HeaderText = "Tên đăng nhập";
                    dataGridViewAccount.Columns["Password"].HeaderText = "Mật khẩu";
                    dataGridViewAccount.Columns["RoleName"].HeaderText = "Vai trò";
                    dataGridViewAccount.Columns["IsActive"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Nút Load
        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }
        private void dataGridViewAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get selected row
                DataGridViewRow row = dataGridViewAccount.Rows[e.RowIndex];

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
            if (dataGridViewAccount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select accounts to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Delete {dataGridViewAccount.SelectedRows.Count} selected accounts?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                AccountBLL accountBLL = new AccountBLL();

                foreach (DataGridViewRow row in dataGridViewAccount.SelectedRows)
                {
                    string accountId = row.Cells["idAccount"].Value.ToString();
                    accountBLL.DeleteAccount(accountId);
                }

                MessageBox.Show("Accounts deleted successfully!");
                LoadAccounts(); // Refresh DataGridView
            }
        }
    }
}
