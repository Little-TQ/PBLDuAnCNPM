using System;
using System.Data;
using System.Data.SqlClient;
using Jewelry.DTO;

namespace Jewelry.DAL
{
    internal class UpdateDAL
    {
        private DBConnect db = new DBConnect();

        //Lấy toàn bộ lịch sử cập nhật giá 
        public DataTable GetAllUpdatePrices(string idMaterial = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT 
                    m.NameMaterial AS [Material],
                    FORMAT(up.Price, 'N0') AS [SalePrice],
                    FORMAT(up.ChangePrice, 'N0') AS [SaleChange],
                    FORMAT(up.Repurchase, 'N0') AS [RepurchasePrice],
                    FORMAT(up.RepurchaseChange, 'N0') AS [RepurchaseChange],
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

                // Lấy giá bán và giá mua trước đó
                const string prevQuery = @"
                SELECT TOP 1 Price, Repurchase
                FROM UpdatePrice
                WHERE idMaterial = @idMaterial AND UpdateTime < @UpdateTime
                ORDER BY UpdateTime DESC";

                decimal prevSalePrice = 0;
                decimal prevRepurchasePrice = 0;

                using (SqlCommand prevCmd = new SqlCommand(prevQuery, conn))
                {
                    prevCmd.Parameters.AddWithValue("@idMaterial", update.idMaterial);
                    prevCmd.Parameters.AddWithValue("@UpdateTime", update.UpdateTime);

                    using (SqlDataReader reader = prevCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prevSalePrice = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0;
                            prevRepurchasePrice = reader["Repurchase"] != DBNull.Value ? Convert.ToDecimal(reader["Repurchase"]) : 0;
                        }
                    }
                }

                // Tính thay đổi: Giá mới - Giá trước đó
                decimal saleChange = update.Price - prevSalePrice; // Thay đổi giá bán
                decimal repurchaseChange = update.RepurchasePrice - prevRepurchasePrice; // Thay đổi giá mua

                const string insertQuery = @"
                INSERT INTO UpdatePrice (idUpdate, idMaterial, UpdateTime, Price, ChangePrice, Repurchase, RepurchaseChange)
                VALUES (@idUpdate, @idMaterial, @UpdateTime, @Price, @ChangePrice, @Repurchase, @RepurchaseChange)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@idUpdate", update.idUpdate);
                    cmd.Parameters.AddWithValue("@idMaterial", update.idMaterial);
                    cmd.Parameters.AddWithValue("@UpdateTime", update.UpdateTime);
                    cmd.Parameters.AddWithValue("@Price", update.Price); // Giá bán
                    cmd.Parameters.AddWithValue("@ChangePrice", saleChange); // Thay đổi giá bán
                    cmd.Parameters.AddWithValue("@Repurchase", update.RepurchasePrice); // Giá mua vào
                    cmd.Parameters.AddWithValue("@RepurchaseChange", repurchaseChange); // Thay đổi giá mua vào

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Lấy cả giá bán và giá mua gần nhất của một chất liệu
        public (decimal SalePrice, decimal RepurchasePrice) GetCurrentPrices(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT TOP 1 Price, Repurchase
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial
            ORDER BY UpdateTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal salePrice = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0;
                        decimal repurchasePrice = reader["Repurchase"] != DBNull.Value ? Convert.ToDecimal(reader["Repurchase"]) : 0;
                        return (salePrice, repurchasePrice);
                    }
                }
                return (0, 0);
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
                MAX(Repurchase) AS MaxPurchasePrice,
                MIN(Repurchase) AS MinPurchasePrice,
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
            ORDER BY idUpdate DESC";   //thay vì ORDER BY UpdateTime DESC

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

        //Lấy giá mua vào + thay đổi giá mua vào mới nhất
        public (decimal Repurchase, decimal RepurchaseChange) GetLatestRepurchasePriceAndChange(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT TOP 1 Repurchase, RepurchaseChange
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial
            ORDER BY idUpdate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal repurchasePrice = reader["Repurchase"] != DBNull.Value ? Convert.ToDecimal(reader["Repurchase"]) : 0;
                        decimal repurchaseChange = reader["RepurchaseChange"] != DBNull.Value ? Convert.ToDecimal(reader["RepurchaseChange"]) : 0;
                        return (repurchasePrice, repurchaseChange);
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
            SELECT TOP 1 Price, ChangePrice, Repurchase, RepurchaseChange, UpdateTime
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
        public DataTable GetDailyPriceChartData(string idMaterial, DateTime selectedDate)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                CONVERT(VARCHAR(5), UpdateTime, 108) AS [Time],
                Price AS SalePrice,
                Repurchase AS RepurchasePrice,
                ChangePrice AS SaleChange,
                RepurchaseChange AS RepurchaseChange
            FROM UpdatePrice
            WHERE idMaterial = @idMaterial 
                AND CAST(UpdateTime AS DATE) = CAST(@SelectedDate AS DATE)
            ORDER BY UpdateTime ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
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
