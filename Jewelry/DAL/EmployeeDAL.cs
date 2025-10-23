using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DTO;

namespace Jewelry.DAL
{
   public  class EmployeeDAL
    {
        DBConnect db = new DBConnect();
        public DataTable GetAllEmployees()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT e.idEmployee, e.NameEmployee, e.PhoneNumberE, e.DateOfBirth, e.AddressE, r.RoleName
                          FROM Employee e 
                          INNER JOIN Role r ON e.idRole = r.idRole";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy danh sách Role từ database
        public DataTable GetAllRoles()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT idRole, RoleName FROM Role";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy ID Role từ tên Role
        public string GetRoleIdByName(string roleName)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT idRole FROM Role WHERE RoleName = @RoleName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@RoleName", roleName);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        // Tạo ID mới tự động tăng
        public string GenerateNewEmployeeId()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(idEmployee, 2, LEN(idEmployee)) AS INT)), 0) + 1 FROM Employee";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                int nextId = (int)cmd.ExecuteScalar();
                return "E" + nextId.ToString("D3"); // Format: A001, A002, etc.
            }
        }

        // Thêm nhân viên mới
        public bool InsertEmployee(EmployeeDTO employee)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                // Lấy ID Role từ tên Role
                string roleId = GetRoleIdByName(employee.RoleName);
                if (string.IsNullOrEmpty(roleId))
                    return false;

                string sql = @"INSERT INTO Employee (idEmployee, NameEmployee, PhoneNumberE, DateOfBirth, AddressE, idRole) 
                          VALUES (@idEmployee, @NameEmployee, @PhoneNumberE, @DateOfBirth, @AddressE, @idRole)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idEmployee", employee.IdEmployee);
                cmd.Parameters.AddWithValue("@NameEmployee", employee.NameEmployee);
                cmd.Parameters.AddWithValue("@PhoneNumberE",employee.PhoneEmployee); 
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                cmd.Parameters.AddWithValue("@AddressE", employee.AddressEmployee);
                cmd.Parameters.AddWithValue("@idRole", roleId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // chỉnh sửa thông tin nhân viên
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                // Get role ID from role name
                string roleId = GetRoleIdByName(employee.RoleName);
                if (string.IsNullOrEmpty(roleId))
                    return false;

                string sql = @"UPDATE Employee 
                       SET NameEmployee = @NameEmployee,
                           PhoneNumberE = @PhoneNumberE,
                           DateOfBirth = @DateOfBirth,
                           AddressE = @AddressE,
                           idRole = @idRole
                       WHERE idEmployee = @idEmployee";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idEmployee", employee.IdEmployee);
                cmd.Parameters.AddWithValue("@NameEmployee", employee.NameEmployee);
                cmd.Parameters.AddWithValue("@PhoneNumberE", employee.PhoneEmployee);
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                cmd.Parameters.AddWithValue("@AddressE", employee.AddressEmployee);
                cmd.Parameters.AddWithValue("@idRole", roleId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DeleteEmployee(string employeeID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "DELETE FROM Employee WHERE idEmployee = @idEmployee";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idEmployee", employeeID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        
        }
        public string GetEmployeeIDByName(string nameEmployee)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT TOP 1 idEmployee FROM Employee WHERE NameEmployee = @NameEmployee";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NameEmployee", nameEmployee);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }
    }
}

