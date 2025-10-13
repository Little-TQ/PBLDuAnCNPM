using System;
using System.Data;
using System.Data.SqlClient;
using Jewelry.DTO;

namespace Jewelry.DAL
{
    internal class UpdateDAL
    {
        private DBConnect db = new DBConnect();

        //Lấy toàn bộ lịch sử cập nhật giá (hoặc theo chất liệu)
        public DataTable GetAllUpdatePrices(string idMaterial = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                m.NameMaterial AS [Material],
                FORMAT(up.Price, 'N0') AS [Price],
                FORMAT(up.ChangePrice, 'N0') AS [Change],
                CONVERT(VARCHAR(5), up.UpdateTime, 108) + ' ' +
                CONVERT(VARCHAR(10), up.UpdateTime, 103) AS [Time]
            FROM UpdatePrice up
            INNER JOIN Material m ON up.idMaterial = m.idMaterial";

                if (!string.IsNullOrEmpty(idMaterial))
                    query += " WHERE up.idMaterial = @idMaterial";

                query += " ORDER BY up.idUpdate ASC"; 

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(idMaterial))
                    cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // InsertUpdatePrice
        public bool InsertUpdatePrice(UpdateDTO update)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                const string prevQuery = @"
            SELECT TOP 1 Price
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial AND UpdateTime < @UpdateTime
            ORDER BY UpdateTime DESC";

                decimal prevPrice = 0;
                using (SqlCommand prevCmd = new SqlCommand(prevQuery, conn))
                {
                    prevCmd.Parameters.AddWithValue("@idMaterial", update.idMaterial);
                    prevCmd.Parameters.AddWithValue("@UpdateTime", update.UpdateTime);

                    object prev = prevCmd.ExecuteScalar();
                    if (prev != null && prev != DBNull.Value)
                        prevPrice = Convert.ToDecimal(prev);
                }

                // change = Giá mới - Giá trước đó
                decimal change = update.Price - prevPrice;

                const string insertQuery = @"
            INSERT INTO UpdatePrice (idUpdate, idMaterial, UpdateTime, Price, ChangePrice)
            VALUES (@idUpdate, @idMaterial, @UpdateTime, @Price, @ChangePrice)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@idUpdate", update.idUpdate);
                    cmd.Parameters.AddWithValue("@idMaterial", update.idMaterial);
                    cmd.Parameters.AddWithValue("@UpdateTime", update.UpdateTime);
                    cmd.Parameters.AddWithValue("@Price", update.Price);
                    cmd.Parameters.AddWithValue("@ChangePrice", change);
                    return cmd.ExecuteNonQuery() > 0;
                }
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

        //Lấy thống kê giá (cao nhất, thấp nhất, cập nhật gần nhất)
        public DataTable GetPriceStatistics(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                MAX(Price)       AS MaxPrice,
                MIN(Price)       AS MinPrice,
                MAX(UpdateTime)  AS LastUpdateTime
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial";  

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        //Lấy giá + thay đổi mới nhất cho 1 chất liệu
        public (decimal Price, decimal Change) GetLatestPriceAndChange(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                // lấy bản ghi mới nhất theo idUpdate (vì idUpdate sinh theo thời gian)
                string query = @"
            SELECT TOP 1 Price, ChangePrice
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial
            ORDER BY idUpdate DESC";   // ✅ thay vì ORDER BY UpdateTime DESC

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0;
                        decimal change = reader["ChangePrice"] != DBNull.Value ? Convert.ToDecimal(reader["ChangePrice"]) : 0;
                        return (price, change);
                    }
                }
                return (0, 0);
            }
        }

        //Lấy bản ghi mới nhất (DataRow)
        public DataRow GetLatestRowByMaterial(string idMaterial)
        {
           using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT TOP 1 Price, ChangePrice, UpdateTime
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial
            ORDER BY idUpdate DESC"; 

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        // Cập nhật cột PriceSilver trong Product Công thức: PriceSilver = (newPrice * Weight) + Cost
        public bool UpdateProductPriceByMaterial(string idMaterial, decimal newPrice)
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
    }
}
