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
        private string connectionString = @"Data Source = LAPTOP-FKJ06BGM\SQLEXPRESS;Initial Catalog=JewelryStoreDB;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
