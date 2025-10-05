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

namespace Jewelry.FolderEmployee
{
    public partial class InformationEmployee: UserControl
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public InformationEmployee()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            if (addEmployee.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees(); // load lại DataGridView
            }
        }
        public void LoadEmployees()
        {
            try
            {
                dataGridViewInfoEmployee.DataSource = employeeDAL.GetAllEmployees();

                // Đặt tên cột hiển thị
                if (dataGridViewInfoEmployee.Columns.Count > 0)
                {
                    dataGridViewInfoEmployee.Columns["idEmployee"].HeaderText = "Mã NV";
                    dataGridViewInfoEmployee.Columns["NameEmployee"].HeaderText = "Tên Nhân Viên";
                    dataGridViewInfoEmployee.Columns["PhoneNumberE"].HeaderText = "Số Điện Thoại";
                    dataGridViewInfoEmployee.Columns["DateOfBirth"].HeaderText = "Ngày Sinh";
                    dataGridViewInfoEmployee.Columns["AddressE"].HeaderText = "Địa Chỉ";
                    dataGridViewInfoEmployee.Columns["RoleName"].HeaderText = "Vai Trò";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dataGridViewInfoEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewInfoEmployee.CurrentRow != null && dataGridViewInfoEmployee.CurrentRow.Index >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dataGridViewInfoEmployee.CurrentRow;

                // Lấy thông tin nhân viên
                string idEmployee = row.Cells["idEmployee"].Value?.ToString();
                string nameEmployee = row.Cells["NameEmployee"].Value?.ToString();
                string phoneEmployee = row.Cells["PhoneNumberE"].Value?.ToString();
                DateTime dateofbirth = row.Cells["DateOfBirth"].Value != DBNull.Value
                        ? Convert.ToDateTime(row.Cells["DateOfBirth"].Value)
                        : DateTime.MinValue;
                string addressEmployee = row.Cells["AddressE"].Value?.ToString();
                string roleName = row.Cells["RoleName"].Value?.ToString();

                // Mở form AddEmployee ở chế độ chỉnh sửa (tham số cuối = false hoặc bỏ readonly flag)
                AddEmployee frm = new AddEmployee(idEmployee, nameEmployee, phoneEmployee, dateofbirth, addressEmployee, roleName, true);

                // Hiện form chỉnh sửa
                frm.btnEditEmployee.Visible = true;   // đảm bảo nút Edit hiện
                frm.ShowDialog();

                // Sau khi edit thì reload danh sách nhân viên
                LoadEmployees();
            }
        }
        private void btnViewInfoEmployee_Click(object sender, EventArgs e)

        {
            
        }

        private void btnDeleteInfoEmployee_Click(object sender, EventArgs e)
        {

            if (dataGridViewInfoEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select employees to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Delete {dataGridViewInfoEmployee.SelectedRows.Count} selected employees?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                EmployeeBLL employeeBLL = new EmployeeBLL();

                foreach (DataGridViewRow row in dataGridViewInfoEmployee.SelectedRows)
                {
                    string EmployeeId = row.Cells["idEmployee"].Value.ToString();
                    employeeBLL.DeleteEmployee(EmployeeId);
                }

                MessageBox.Show("Employees deleted successfully!");
                LoadEmployees(); // Refresh DataGridView
            }
        }

        private void InformationEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
