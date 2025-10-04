using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    internal class PropertyDAL
    {
        private DBConnect db = new DBConnect();
         public DataTable GetPropertyData(string tableName)
        {

            using (SqlConnection conn = db.GetConnection())
            {

                string query = $"SELECT * FROM {tableName}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
