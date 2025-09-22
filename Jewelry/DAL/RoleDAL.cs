using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    public class RoleDAL
    {

        DBConnect db = new DBConnect();

        // Lấy toàn bộ Role
        public DataTable GetAllRoles()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT * FROM Role";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
