using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewelry.DTO;

namespace Jewelry.DAL
{
    public class UpdateDAL
    {
        private DBConnect db = new DBConnect();

        // Lấy tất cả lịch sử cập nhật giá
        public DataTable GetAllUpdatePrices()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
            SELECT 
                CONVERT(VARCHAR(5), up.UpdateTime, 108)       AS [Thời Gian],
                FORMAT(up.Price, 'N0')                        AS [Giá],
                FORMAT(up.ChangePrice, 'N0')                  AS [Thay Đổi],
                m.NameMaterial                               AS [Loại Vàng]
            FROM UpdatePrice up
            INNER JOIN Material m ON up.idMaterial = m.idMaterial
            WHERE CAST(up.UpdateTime AS DATE) = CAST(GETDATE() AS DATE)
            ORDER BY up.UpdateTime DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Lấy giá mới nhất của một chất liệu
        public decimal GetLatestPriceByMaterial(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
                    SELECT TOP 1 Price 
                    FROM UpdatePrice 
                    WHERE idMaterial = @idMaterial 
                    ORDER BY UpdateTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                conn.Open();

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        // Thêm bản ghi cập nhật giá mới
        public bool InsertUpdatePrice(UpdateDTO update)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
                    INSERT INTO UpdatePrice (idUpdate, idMaterial, UpdateTime, Price, ChangePrice) 
                    VALUES (@idUpdate, @idMaterial, @UpdateTime, @Price, @ChangePrice)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUpdate", update.idUpdate);
                cmd.Parameters.AddWithValue("@idMaterial", update.idMaterial);
                cmd.Parameters.AddWithValue("@UpdateTime", update.UpdateTime);
                cmd.Parameters.AddWithValue("@Price", update.Price);
                cmd.Parameters.AddWithValue("@ChangePrice", update.ChangePrice);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật giá PricePerOunce trong bảng Product
        public bool UpdateProductPricePerOunce(string idMaterial, decimal newPricePerOunce)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
                    UPDATE Product 
                    SET PriceSilver = @newPriceSilver
                    WHERE idMaterial = @idMaterial";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                cmd.Parameters.AddWithValue("@newPriceSilver", newPricePerOunce);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy PricePerOunce hiện tại từ Product
        public decimal GetCurrentPricePerOunce(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
                    SELECT TOP 1 PriceSilver
                    FROM Product 
                    WHERE idMaterial = @idMaterial";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                conn.Open();

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        // Lấy tất cả chất liệu
        public DataTable GetAllMaterials()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT idMaterial, NameMaterial FROM Material";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Lấy thông tin thống kê giá
        public DataTable GetPriceStatistics(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
                    SELECT 
                        MAX(Price) as MaxPrice,
                        MIN(Price) as MinPrice,
                        MAX(UpdateTime) as LastUpdateTime
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
    }
}