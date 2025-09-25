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
    public class AccountPermissionDAL
    {
        DBConnect db = new DBConnect();

        public DataTable GetAccountPermissions()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT 
            a.idAccount, a.Username, r.RoleName,
            CAST(MAX(CASE WHEN p.PermissionName = 'Account' THEN 1 ELSE 0 END) AS BIT) as Account,
            CAST(MAX(CASE WHEN p.PermissionName = 'Overview' THEN 1 ELSE 0 END) AS BIT) as Overview,
            CAST(MAX(CASE WHEN p.PermissionName = 'Product' THEN 1 ELSE 0 END) AS BIT) as Product,
            CAST(MAX(CASE WHEN p.PermissionName = 'Customer' THEN 1 ELSE 0 END) AS BIT) as Customer,
            CAST(MAX(CASE WHEN p.PermissionName = 'Employee' THEN 1 ELSE 0 END) AS BIT) as Employee,
            CAST(MAX(CASE WHEN p.PermissionName = 'Payment' THEN 1 ELSE 0 END) AS BIT) as Payment,
            CAST(MAX(CASE WHEN p.PermissionName = 'Invoice' THEN 1 ELSE 0 END) AS BIT) as Invoice,
            CAST(MAX(CASE WHEN p.PermissionName = 'Update' THEN 1 ELSE 0 END) AS BIT) as [Update]
            FROM Account a
            INNER JOIN Role r ON a.idRole = r.idRole
            LEFT JOIN Account_Permission ap ON a.idAccount = ap.idAccount
            LEFT JOIN Permission p ON ap.idPermission = p.idPermission
            GROUP BY a.idAccount, a.Username, r.RoleName";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void UpdatePermissions(AccountPermissionDTO dto)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Xóa permissions cũ
                        string deleteSql = "DELETE FROM Account_Permission WHERE idAccount = @AccountId";
                        SqlCommand deleteCmd = new SqlCommand(deleteSql, conn, trans);
                        deleteCmd.Parameters.AddWithValue("@AccountId", dto.AccountId);
                        deleteCmd.ExecuteNonQuery();

                        // Thêm permissions mới
                        string[] permissions = { "Account", "Overview", "Product", "Customer", "Employee", "Payment", "Invoice", "Update" };
                        bool[] values = { dto.Account, dto.Overview, dto.Product, dto.Customer, dto.Employee, dto.Payment, dto.Invoice, dto.Update };

                        for (int i = 0; i < permissions.Length; i++)
                        {
                            if (values[i])
                            {
                                string insertSql = @"INSERT INTO Account_Permission (idAccount, idPermission) 
                                              VALUES (@AccountId, (SELECT idPermission FROM Permission WHERE PermissionName = @PermissionName))";
                                SqlCommand insertCmd = new SqlCommand(insertSql, conn, trans);
                                insertCmd.Parameters.AddWithValue("@AccountId", dto.AccountId);
                                insertCmd.Parameters.AddWithValue("@PermissionName", permissions[i]);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
