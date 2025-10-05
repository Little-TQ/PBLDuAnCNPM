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
using Jewelry.DTO;

namespace Jewelry
{
    public partial class AddEmployee: Form
    {
        private string currentIdEmployee = null;
        private bool isEditMode = false;
        public AddEmployee()
        {
            InitializeComponent();
            LoadRoles();
            btnEditEmployee.Click += btnEditEmployee_Click;
        }
        public AddEmployee(string idEmployee, string nameEmployee, string phoneEmployee, DateTime dateofbirth, string addressEmployee, string rolename, bool isReadOnly) : this()
        {
            currentIdEmployee = idEmployee;
            txtNameEmployee.Text = nameEmployee;
            txtPhoneEmployee.Text = phoneEmployee;
            txtAddressEmployee.Text = addressEmployee;
            DatepkEmployee.Value = dateofbirth;
            cbxRoleEmployee.SelectedValue = rolename;
            SetReadOnly(isReadOnly);
        }
        private void SetReadOnly(bool isReadOnly)
        {
            txtNameEmployee.ReadOnly = isReadOnly;
            txtPhoneEmployee.ReadOnly = isReadOnly;
            txtAddressEmployee.ReadOnly = isReadOnly;
            DatepkEmployee.Enabled = !isReadOnly;
            cbxRoleEmployee.Enabled = !isReadOnly;
            btnCompleteE.Enabled = !isReadOnly;
        }

        private void LoadRoles()
        {
            EmployeeBLL employeeBLL = new EmployeeBLL();
            DataTable roles = employeeBLL.GetAllRoles();
            cbxRoleEmployee.DataSource = roles;
            cbxRoleEmployee.DisplayMember = "RoleName";
            cbxRoleEmployee.ValueMember = "RoleName"; // or "idRole" if you want to use the ID
            cbxRoleEmployee.SelectedIndex = -1; // No selection by default
        }
        private void btnExitAddEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnAddE_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            SetReadOnly(false);
        }

        private void btnCompleteE_Click(object sender, EventArgs e)
        {
            try
            {
                string nameEmployee = txtNameEmployee.Text.Trim();
                string phoneEmployee = txtPhoneEmployee.Text;
                string addressEmployee = txtAddressEmployee.Text;
                string roleName = cbxRoleEmployee.SelectedValue?.ToString();
                DateTime dateofbirth = DatepkEmployee.Value;

                EmployeeBLL employeeBLL = new EmployeeBLL();
                bool success;

                if (isEditMode && !string.IsNullOrEmpty(currentIdEmployee))
                {
                    // Update
                    EmployeeDTO updatedEmployee = new EmployeeDTO(currentIdEmployee, nameEmployee, phoneEmployee, dateofbirth, addressEmployee, roleName);
                    success = employeeBLL.UpdateEmployee(updatedEmployee);
                }
                else
                {
                    // Add new
                    string newId = employeeBLL.GenerateNewEmployeeId();
                    EmployeeDTO newEmployee = new EmployeeDTO(newId, nameEmployee, phoneEmployee, dateofbirth, addressEmployee, roleName);
                    success = employeeBLL.AddEmployee(newEmployee);
                }

                if (success)
                {
                    MessageBox.Show(isEditMode ? "Employee success updated!" : "Employee success added!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
