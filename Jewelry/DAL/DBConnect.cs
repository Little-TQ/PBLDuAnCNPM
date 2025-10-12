using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
   public class DBConnect
    {
        private string connectionString = @"Data Source=LITTLE\SQLEXPRESS;Initial Catalog=PBL;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
