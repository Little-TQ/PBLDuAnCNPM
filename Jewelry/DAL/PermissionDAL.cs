using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    public class PermissionDAL
    {
        DBConnect db = new DBConnect();

        // Lấy toàn bộ Permission
        public DataTable GetAllPermissions()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM Permission";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool HasPermission(string accountId, string permissionName)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT COUNT(*) 
                       FROM Account_Permission ap
                       INNER JOIN Permission p ON ap.idPermission = p.idPermission
                       WHERE ap.idAccount = @AccountId 
                       AND p.PermissionName = @PermissionName
                       AND ap.IsGranted = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                cmd.Parameters.AddWithValue("@PermissionName", permissionName);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
