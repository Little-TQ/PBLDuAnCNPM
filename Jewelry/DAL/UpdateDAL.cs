using System;
using System.Data;
using System.Data.SqlClient;
using Jewelry.DTO;

namespace Jewelry.DAL
{
    internal class UpdateDAL
    {
        private DBConnect db = new DBConnect();

        // Lấy toàn bộ lịch sử cập nhật giá (hoặc riêng theo chất liệu)
        public DataTable GetAllUpdatePrices(string idMaterial = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        up.idUpdate AS [Mã Cập Nhật],
                        m.NameMaterial AS [Chất Liệu],
                        FORMAT(up.Price, 'N0') AS [Giá],
                        FORMAT(up.ChangePrice, 'N0') AS [Thay Đổi],
                        CONVERT(VARCHAR(10), up.UpdateTime, 103) + ' ' + CONVERT(VARCHAR(5), up.UpdateTime, 108) AS [Thời Gian]
                    FROM UpdatePrice up
                    INNER JOIN Material m ON up.idMaterial = m.idMaterial";

                if (!string.IsNullOrEmpty(idMaterial))
                    query += " WHERE up.idMaterial = @idMaterial";

                query += " ORDER BY up.UpdateTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(idMaterial))
                    cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Thêm bản ghi mới vào UpdatePrice
        public bool InsertUpdatePrice(UpdateDTO update)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO UpdatePrice (idUpdate, idMaterial, UpdateTime, Price, ChangePrice)
                    VALUES (@idUpdate, @idMaterial, @UpdateTime, @Price, @ChangePrice)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUpdate", update.idUpdate);
                cmd.Parameters.AddWithValue("@idMaterial", update.idMaterial);
                cmd.Parameters.AddWithValue("@UpdateTime", update.UpdateTime);
                cmd.Parameters.AddWithValue("@Price", update.Price);
                cmd.Parameters.AddWithValue("@ChangePrice", update.ChangePrice);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy giá gần nhất của một chất liệu
        public decimal GetCurrentPricePerOunce(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 Price 
                    FROM UpdatePrice 
                    WHERE idMaterial = @idMaterial
                    ORDER BY UpdateTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        // Lấy danh sách chất liệu
        public DataTable GetAllMaterials()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT idMaterial, NameMaterial FROM Material";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Cập nhật giá vàng trong Product
        public bool UpdateProductPrice(string idMaterial, decimal newPrice)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Product 
                    SET PriceSilver = @newPrice 
                    WHERE idMaterial = @idMaterial";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                cmd.Parameters.AddWithValue("@newPrice", newPrice);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy thống kê giá (cao nhất, thấp nhất, cập nhật gần nhất)
        public DataTable GetPriceStatistics(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        MAX(Price) AS MaxPrice,
                        MIN(Price) AS MinPrice,
                        MAX(UpdateTime) AS LastUpdateTime
                    FROM UpdatePrice
                    WHERE idMaterial = @idMaterial";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        //Lấy bản ghi gần nhất (Giá + Thay đổi)
        public (decimal Price, decimal Change) GetLatestPriceAndChange(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 Price, ChangePrice
                    FROM UpdatePrice
                    WHERE idMaterial = @idMaterial
                    ORDER BY UpdateTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    decimal price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0;
                    decimal change = reader["ChangePrice"] != DBNull.Value ? Convert.ToDecimal(reader["ChangePrice"]) : 0;
                    return (price, change);
                }
                return (0, 0);
            }
        }
    }
}
