using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Jewelry.DAL
{
    internal class FollowOrderDAL
    {
        private DBConnect db = new DBConnect();
        //Generate ID 
        public string GenerateFollowOrderID()
        {
            string id = "FO-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return id;
        }
        public bool AddFollowOrder(FollowOrderDTO order)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO FollowOrder (idFollowOrder, idInvoice, Status, DateOrder, DateDelivery)
                                 VALUES (@idFollowOrder, @idInvoice, @Status, @DateOrder, @DateDelivery)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idFollowOrder", order.idFollowOrder);
                if (string.IsNullOrEmpty(order.idInvoice))
                    cmd.Parameters.AddWithValue("@idInvoice", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idInvoice", order.idInvoice);

                cmd.Parameters.AddWithValue("@Status", order.Status);
                cmd.Parameters.AddWithValue("@DateOrder", order.DateOrder);
                cmd.Parameters.AddWithValue("@DateDelivery", (object)order.DateDelivery ?? DBNull.Value);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }
    }
    
}
