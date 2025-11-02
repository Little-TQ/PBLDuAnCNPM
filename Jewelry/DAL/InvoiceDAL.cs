using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    internal class InvoiceDAL
    {
        private DBConnect db = new DBConnect();
        //Insert Invoice
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
        //Insert Invoice Details
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
        //Get Invoice Details by Invoice ID
        public DataTable GetInvoiceDetails(string invoiceId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT p.NameProduct as ProductName, id.Quantity, p.Weight, p.Wage, 
                   id.Price, p.idProduct, p.idMaterial
            FROM InvoiceDetail id
            INNER JOIN Product p ON id.idProduct = p.idProduct
            WHERE id.idInvoice = @idInvoice";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idInvoice", invoiceId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        //Get Invoice by ID
        public InvoiceDTO GetInvoiceById(string invoiceId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Invoice WHERE idInvoice = @idInvoice";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idInvoice", invoiceId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new InvoiceDTO
                        {
                            idInvoice = reader["idInvoice"].ToString(),
                            idCustomer = reader["idCustomer"]?.ToString(),
                            DateTimeCreateInvoice = Convert.ToDateTime(reader["DateTimeCreateInvoice"]),
                            Type = reader["Type"].ToString(),
                            Status = reader["Status"].ToString(),
                            idEmployee = reader["idEmployee"].ToString(),
                            Total = Convert.ToDecimal(reader["Total"])
                        };
                    }
                }
                return null;
            }
        }
        //Get All Invoices with Preview Link
            public DataTable GetAllInvoicesWithPreview()
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    i.idInvoice,
                    c.NameCustomer AS CustomerName,
                    e.NameEmployee AS EmployeeName,
                    i.DateTimeCreateInvoice,
                    i.Total,
                    p.LinkInvoice AS LinkInvoice
                FROM Invoice i
                LEFT JOIN Customer c ON i.idCustomer = c.idCustomer
                LEFT JOIN Employee e ON i.idEmployee = e.idEmployee
                LEFT JOIN InvoicePreview p ON i.idInvoice = p.idInvoice
                WHERE i.Type = 'Sale'
                ORDER BY i.DateTimeCreateInvoice DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        //Searrch   Invoice
        public DataTable SearchInvoices(string keyword)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
        SELECT i.idInvoice AS [Invoice ID],
               c.NameCustomer AS [Customer],
               e.NameEmployee AS [Employee],
               i.DateTimeCreateInvoice AS [Date Created],
               i.Total AS [Total (VND)],
               p.LinkInvoice AS [Invoice File]
        FROM Invoice i
        LEFT JOIN Customer c ON i.idCustomer = c.idCustomer
        LEFT JOIN Employee e ON i.idEmployee = e.idEmployee
        LEFT JOIN InvoicePreview p ON i.idInvoice = p.idInvoice
        WHERE (@keyword = '' OR 
               i.idInvoice LIKE '%' + @keyword + '%' OR
               c.NameCustomer LIKE '%' + @keyword + '%' OR
               e.NameEmployee LIKE '%' + @keyword + '%' OR
               CONVERT(VARCHAR, i.DateTimeCreateInvoice, 103) LIKE '%' + @keyword + '%')
        ORDER BY i.DateTimeCreateInvoice DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", keyword);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}

