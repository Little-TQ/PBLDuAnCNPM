using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DTO;

namespace Jewelry.DAL
{
    public class RepurchaseDetailDAL
    {
        private DBConnect db = new DBConnect();

        public bool InsertRepurchaseDetail(RepurchaseDetailDTO repurchase)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO RepurchaseDetail 
                               (idRepurchaseDetail, idInvoice, idMaterial, Weight, RepurchasePrice)
                               VALUES (@idRepurchaseDetail, @idInvoice, @idMaterial, @Weight, @RepurchasePrice)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idRepurchaseDetail", repurchase.idRepurchaseDetail);
                cmd.Parameters.AddWithValue("@idInvoice", repurchase.idInvoice);
                cmd.Parameters.AddWithValue("@idMaterial", repurchase.idMaterial ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Weight", repurchase.Weight);
                cmd.Parameters.AddWithValue("@RepurchasePrice", repurchase.RepurchasePrice);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertRepurchaseDetails(List<RepurchaseDetailDTO> repurchases)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                foreach (var repurchase in repurchases)
                {
                    string query = @"INSERT INTO RepurchaseDetail 
                                   (idRepurchaseDetail, idInvoice, idMaterial, Weight, RepurchasePrice)
                                   VALUES (@idRepurchaseDetail, @idInvoice, @idMaterial, @Weight, @RepurchasePrice)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idRepurchaseDetail", repurchase.idRepurchaseDetail);
                    cmd.Parameters.AddWithValue("@idInvoice", repurchase.idInvoice);
                    cmd.Parameters.AddWithValue("@idMaterial", repurchase.idMaterial ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Weight", repurchase.Weight);
                    cmd.Parameters.AddWithValue("@RepurchasePrice", repurchase.RepurchasePrice);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }
    }
}
