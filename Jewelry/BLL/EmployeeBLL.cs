using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DAL;
using Jewelry.DTO;
using System.Windows.Forms;

namespace Jewelry.BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();

        // Get all roles
        public DataTable GetAllRoles()
        {
            return employeeDAL.GetAllRoles();
        }

        // Generate new account ID
        public string GenerateNewEmployeeId()
        {
            return employeeDAL.GenerateNewEmployeeId();
        }
        public void CheckEmployee(EmployeeDTO employee, bool isUpdate = false)
        {
            // Validate input (giữ nguyên)
            if (string.IsNullOrWhiteSpace(employee.IdEmployee))
                throw new Exception("Account ID cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.NameEmployee))
                throw new Exception("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.PhoneEmployee))
                throw new Exception("Password cannot be empty.");

            if (employee.DateOfBirth == DateTime.MinValue)
                throw new Exception("Date of birth is required.");

            if (string.IsNullOrWhiteSpace(employee.AddressEmployee))
                throw new Exception("Password cannot be empty.");

            if (string.IsNullOrWhiteSpace(employee.RoleName))
                throw new Exception("Role is invalid.");

            // Kiểm tra trùng name 
            DataTable existingEmployees = employeeDAL.GetAllEmployees();
            foreach (DataRow row in existingEmployees.Rows)
            {
                string existingNameE = row["NameEmployee"].ToString();
                string existingId = row["idEmployee"].ToString();

                // Nếu là update, bỏ qua chính employee đang được update
                if (isUpdate && existingId.Equals(employee.IdEmployee, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (existingNameE.Equals(employee.NameEmployee, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("NameEmployee already exists.");
                }
            }
        }

        public bool AddEmployee(EmployeeDTO employee)
        {
            CheckEmployee(employee, false); // false = không phải update
            return employeeDAL.InsertEmployee(employee);
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            CheckEmployee(employee, true);  // true = đang update
            return employeeDAL.UpdateEmployee(employee);
        }
        public bool DeleteEmployee(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
                throw new Exception("Employee ID cannot be empty.");

            return employeeDAL.DeleteEmployee(employeeId);
        }
    }
}
