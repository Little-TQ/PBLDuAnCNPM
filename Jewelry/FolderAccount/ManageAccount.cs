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

namespace Jewelry.Account
{
    public partial class ManageAccount: UserControl
    {
        AccountDAL accountDAL = new AccountDAL();
        public ManageAccount()
        {
            InitializeComponent();
            LoadAccounts();
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
    }
}
