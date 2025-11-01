using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    internal class InvoicePreviewDAL
    {
        private DBConnect db = new DBConnect();

        //Thêm hoặc cập nhật Preview (nếu đã tồn tại)
        public bool AddOrUpdatePreview(InvoicePreviewDTO dto)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM InvoicePreview WHERE idInvoice = @idInvoice";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@idInvoice", dto.idInvoice);

                conn.Open();
                int exists = (int)checkCmd.ExecuteScalar();

                string query;
                if (exists > 0)
                {
                    // Cập nhật nếu đã tồn tại
                    query = @"UPDATE InvoicePreview 
                              SET Type = @Type, LinkInvoice = @LinkInvoice 
                              WHERE idInvoice = @idInvoice";
                }
                else
                {
                    //Thêm mới
                    query = @"INSERT INTO InvoicePreview (idInvoice, Type, LinkInvoice)
                              VALUES (@idInvoice, @Type, @LinkInvoice)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idInvoice", dto.idInvoice);
                cmd.Parameters.AddWithValue("@Type", dto.Type);

                //Chỉ lưu tên file (VD: INV-251101183336.pdf)
                string fileNameOnly = System.IO.Path.GetFileName(dto.LinkInvoice);
                cmd.Parameters.AddWithValue("@LinkInvoice", fileNameOnly);

                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

        // Lấy danh sách tất cả Preview
        public List<InvoicePreviewDTO> GetAllPreviews()
        {
            List<InvoicePreviewDTO> list = new List<InvoicePreviewDTO>();
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM InvoicePreview ORDER BY CreatedAt DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new InvoicePreviewDTO
                    {
                        idInvoice = dr["idInvoice"].ToString(),
                        Type = dr["Type"].ToString(),
                        LinkInvoice = dr["LinkInvoice"].ToString(),
                    });
                }
                dr.Close();
                conn.Close();
            }
            return list;
        }

    }
}
