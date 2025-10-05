using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DAL;
using Jewelry.DTO;

namespace Jewelry
{
    public partial class Login : Form
    {
        AccountDAL accountDAL = new AccountDAL();
        private LoginDTO currentUser;
        // Property public để truy cập từ form khác
        public LoginDTO CurrentUser
        {
            get { return currentUser; }
            private set { currentUser = value; }
        }

        public Login()
        {
            InitializeComponent();
          
        }
        private void Login_Load(object sender, EventArgs e)
        {
            LoadRolesFromDatabase();
        }
        // Hàm load roles từ database vào combobox
        private void LoadRolesFromDatabase()
        {
            try
            {
                DataTable roles = accountDAL.GetAllRoles();

                // Clear items cũ (nếu có)
                cbxRole.Items.Clear();

                // Thêm các role vào combobox
                foreach (DataRow row in roles.Rows)
                {
                    if (!row.IsNull("RoleName"))
                    {
                        string roleName = row["RoleName"].ToString();
                        cbxRole.Items.Add(roleName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load roles: {ex.Message}");
            }
        }
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string selectedRole = cbxRole.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                AccountBLL accountBLL = new AccountBLL();
                var loginResult = accountBLL.CheckLogin(username, password, selectedRole);

                if (loginResult.Item1)
                {
                    CurrentUser = new LoginDTO
                    {
                        AccountId = loginResult.Item2,
                        Username = username,
                        RoleName = selectedRole,
                        Permissions = loginResult.Item4
                    };

                    // Lưu vào session static
                    Session.CurrentUser = CurrentUser;

                    DashBoard dashboard = new DashBoard();
                    this.Hide();
                    dashboard.ShowDialog();

                    // Khi Dashboard đóng, quay lại Login
                    CurrentUser = null;
                    Session.CurrentUser = null;
                    txtPassword.Clear();
                    this.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

        }
        private void txtUsername_Enter_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter Username")
            {
                txtUsername.Text = "";
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }
        private void picLogin_Click(object sender, EventArgs e)
        {
            HomePage frm= new HomePage();
            this.Hide();
            frm.ShowDialog();
        }

        
    }
}