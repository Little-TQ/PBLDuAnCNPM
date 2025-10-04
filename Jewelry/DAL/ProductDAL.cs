using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    public class ProductDAL
    {
        private DBConnect db = new DBConnect();
        //Get all products from the database
        public DataTable GetAllProducts()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"
            SELECT 
                p.idProduct AS ID,
                p.NameProduct AS Name,
                p.PriceSilver AS Price,
                p.Wage,
                p.Sold,
                p.Instock,
                c.NameCategory AS Category,
                m.NameMaterial AS Material,
                co.NameColor AS Color,
                col.NameCollection AS Collection,
                p.Gender,
                p.Weight,
                p.Size,
                p.Photo 
            FROM Product p
            LEFT JOIN Category c ON p.idCategory = c.idCategory
            LEFT JOIN Material m ON p.idMaterial = m.idMaterial
            LEFT JOIN Color co ON p.idColor = co.idColor
            LEFT JOIN Collection col ON p.idCollection = col.idCollection";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        //Get product by ID
        public ProductDTO GetProductByID(string idProduct)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Product WHERE IDProduct = @IDProduct";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDProduct", idProduct);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ProductDTO(
                       reader["idProduct"].ToString(),
                       reader["NameProduct"].ToString(),
                       reader["PriceSilver"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["PriceSilver"]),
                       reader["Wage"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["Wage"]),
                       Convert.ToInt32(reader["Sold"]),
                       Convert.ToInt32(reader["Instock"]),
                       reader["idCategory"].ToString(),
                       reader["idMaterial"].ToString(),
                       reader["idColor"].ToString(),
                       reader["idCollection"].ToString(),
                       reader["Gender"].ToString(),
                       reader["Weight"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Weight"]),
                       reader["Size"] == DBNull.Value ? 0 : Convert.ToDouble(reader["Size"]),
                       reader["Photo"].ToString()
                   );

                }
                return null;
            }
        }
        //Generate a new unique product ID
        public string GenerateProductID(string categoryName, string materialName)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string catSymbol = categoryName.Substring(0, 1).ToUpper();
                string matSymbol = materialName.Substring(0, 1).ToUpper();
                string prefix = "P" + catSymbol + matSymbol;

                string query = "SELECT MAX(idProduct) FROM Product WHERE idProduct LIKE @prefix + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prefix", prefix + "-");
                conn.Open();
                object result = cmd.ExecuteScalar();

                int nextNumber = 1; 
                if (result != DBNull.Value && result != null)
                {
                    string lastId = result.ToString(); 
                    string[] parts = lastId.Split('-');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int currentNumber))
                    {
                        nextNumber = currentNumber + 1;
                    }
                }
                return prefix + "-" + nextNumber.ToString("D3"); // ví dụ: PRG-005
            }
        }

        //Add a new product to the database
        public bool InsertProduct(ProductDTO product)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO Product 
                    (idProduct, NameProduct, PriceSilver, Wage, Sold, Instock, idCategory, idMaterial, idColor, idCollection, Gender, Weight, Size, Photo) 
                    VALUES (@idProduct, @NameProduct, @PriceSilver, @Wage, @Sold, @Instock, @idCategory, @idMaterial, @idColor, @idCollection, @Gender, @Weight, @Size, @Photo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idProduct", product.idProduct);
                cmd.Parameters.AddWithValue("@NameProduct", product.NameProduct);
                cmd.Parameters.AddWithValue("@PriceSilver", (object)product.PriceSilver ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Wage", (object)product.Wage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Sold", product.Sold);
                cmd.Parameters.AddWithValue("@Instock", product.Instock);
                cmd.Parameters.AddWithValue("@idCategory", product.idCategory);
                cmd.Parameters.AddWithValue("@idMaterial", product.idMaterial);
                cmd.Parameters.AddWithValue("@idColor", product.idColor);
                cmd.Parameters.AddWithValue("@idCollection", (object)product.idCollection ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", product.Gender);
                cmd.Parameters.AddWithValue("@Weight", product.Weight);
                cmd.Parameters.AddWithValue("@Size", (object)product.Size ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Photo", product.Photo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //Update an existing product in the database
        public bool UpdateProduct(ProductDTO product)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"UPDATE Product SET 
                        NameProduct = @NameProduct,
                        PriceSilver = @PriceSilver,
                        Wage = @Wage,
                        Sold = @Sold,
                        Instock = @Instock,
                        idCategory = @idCategory,
                        idMaterial = @idMaterial,
                        idColor = @idColor,
                        idCollection = @idCollection,
                        Gender = @Gender,
                        Weight = @Weight,
                        Size = @Size,
                        Photo = @Photo
                       WHERE idProduct = @idProduct";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idProduct", product.idProduct);
                cmd.Parameters.AddWithValue("@NameProduct", product.NameProduct);
                cmd.Parameters.AddWithValue("@PriceSilver", (object)product.PriceSilver ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Wage", (object)product.Wage ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Sold", product.Sold);
                cmd.Parameters.AddWithValue("@Instock", product.Instock);
                cmd.Parameters.AddWithValue("@idCategory", product.idCategory);
                cmd.Parameters.AddWithValue("@idMaterial", product.idMaterial);
                cmd.Parameters.AddWithValue("@idColor", product.idColor);
                cmd.Parameters.AddWithValue("@idCollection", (object)product.idCollection ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", product.Gender);
                cmd.Parameters.AddWithValue("@Weight", product.Weight);
                cmd.Parameters.AddWithValue("@Size", (object)product.Size ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Photo", product.Photo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //Delete a product from the database
        public bool DeleteProduct(string idProduct)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "DELETE FROM Product WHERE idProduct = @idProduct";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idProduct", idProduct);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
