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
    public class AccountDAL
    {
        DBConnect db = new DBConnect();

        // Lấy toàn bộ Account với thông tin Role
        public DataTable GetAllAccounts()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT a.idAccount, a.Username, a.Password, r.RoleName, a.IsActive 
                          FROM Account a 
                          INNER JOIN Role r ON a.idRole = r.idRole";
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
        public string GenerateNewAccountId()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(idAccount, 2, LEN(idAccount)) AS INT)), 0) + 1 FROM Account";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                int nextId = (int)cmd.ExecuteScalar();
                return "A" + nextId.ToString("D3"); // Format: A001, A002, etc.
            }
        }

        // Thêm tài khoản mới
        public bool InsertAccount(AccountDTO account)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                // Lấy ID Role từ tên Role
                string roleId = GetRoleIdByName(account.RoleName);
                if (string.IsNullOrEmpty(roleId))
                    return false;

                string sql = @"INSERT INTO Account (idAccount, Username, Password, idRole, IsActive) 
                          VALUES (@idAccount, @Username, @Password, @idRole, @IsActive)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idAccount", account.IdAccount);
                cmd.Parameters.AddWithValue("@Username", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.PasswordHash); // Nên mã hóa password
                cmd.Parameters.AddWithValue("@idRole", roleId);
                cmd.Parameters.AddWithValue("@IsActive", account.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
