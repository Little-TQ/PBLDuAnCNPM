using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.BLL;
using Jewelry.DTO;

namespace Jewelry.Account
{
    public partial class Provide_Permission : UserControl
    {
        private PermissionBLL permissionBLL = new PermissionBLL();
        public Provide_Permission()
        {
            InitializeComponent();
        }
        private void LoadPermissions()
        {
            DataTable dt = permissionBLL.GetAccountPermissions();
            dataGridViewPermission.DataSource = dt;

            // Ẩn cột ID
            dataGridViewPermission.Columns["idAccount"].Visible = false;

            // Đặt tiếng Việt cho header
            dataGridViewPermission.Columns["Username"].HeaderText = "Tên đăng nhập";
            dataGridViewPermission.Columns["RoleName"].HeaderText = "Vai trò";
            dataGridViewPermission.Columns["Account"].HeaderText = "Tài khoản";
            dataGridViewPermission.Columns["Overview"].HeaderText = "Thống Kê";
            dataGridViewPermission.Columns["Product"].HeaderText = "Sản phẩm";
            dataGridViewPermission.Columns["Customer"].HeaderText = "Khách hàng";
            dataGridViewPermission.Columns["Employee"].HeaderText = "Nhân viên";
            dataGridViewPermission.Columns["Payment"].HeaderText = "Thanh toán";
            dataGridViewPermission.Columns["Invoice"].HeaderText = "Hóa đơn";
            dataGridViewPermission.Columns["Update"].HeaderText = "Cập nhật";
        }

        private void btnSavePermission_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewPermission.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var dto = new AccountPermissionDTO
                        {
                            AccountId = row.Cells["idAccount"].Value.ToString(),
                            Username = row.Cells["Username"].Value.ToString(),
                            RoleName = row.Cells["RoleName"].Value.ToString(),
                            Account = Convert.ToBoolean(row.Cells["Account"].Value),
                            Overview = Convert.ToBoolean(row.Cells["Overview"].Value),
                            Product = Convert.ToBoolean(row.Cells["Product"].Value),
                            Customer = Convert.ToBoolean(row.Cells["Customer"].Value),
                            Employee = Convert.ToBoolean(row.Cells["Employee"].Value),
                            Payment = Convert.ToBoolean(row.Cells["Payment"].Value),
                            Invoice = Convert.ToBoolean(row.Cells["Invoice"].Value),
                            Update = Convert.ToBoolean(row.Cells["Update"].Value)
                        };

                        permissionBLL.UpdatePermissions(dto);
                    }
                }
                MessageBox.Show("Cập nhật quyền thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btnViewPermission_Click(object sender, EventArgs e)
        {
            LoadPermissions();
        }
    }
}
