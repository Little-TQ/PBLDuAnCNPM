using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    class PermisstionDAL
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
    }
}
