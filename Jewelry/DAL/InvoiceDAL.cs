using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    internal class InvoiceDAL
    {
        private DBConnect db = new DBConnect();

        public bool InsertInvoice(InvoiceDTO invoice)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Invoice 
                                 (idInvoice, idCustomer, DateTimeCreateInvoice, Type, Status, idEmployee, Total)
                                 VALUES (@idInvoice, @idCustomer, @DateTimeCreateInvoice, @Type, @Status, @idEmployee, @Total)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idInvoice", invoice.idInvoice);
                cmd.Parameters.AddWithValue("@idCustomer", (object)invoice.idCustomer ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateTimeCreateInvoice", invoice.DateTimeCreateInvoice);
                cmd.Parameters.AddWithValue("@Type", invoice.Type);
                cmd.Parameters.AddWithValue("@Status", invoice.Status);
                cmd.Parameters.AddWithValue("@idEmployee", invoice.idEmployee);
                cmd.Parameters.AddWithValue("@Total", invoice.Total);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertInvoiceDetails(List<InvoiceDetailDTO> details)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                foreach (var d in details)
                {
                    string query = @"INSERT INTO InvoiceDetail 
                                 (idInvoice, idProduct, Quantity, Price)
                                 VALUES (@idInvoice, @idProduct, @Quantity, @Price)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idInvoice", d.idInvoice);
                    cmd.Parameters.AddWithValue("@idProduct", d.idProduct);
                    cmd.Parameters.AddWithValue("@Quantity", d.Quantity);
                    cmd.Parameters.AddWithValue("@Price", d.Price);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }
    }
}
