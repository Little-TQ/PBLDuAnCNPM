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
    public class ProductDAL
    {
        private DBConnect db = new DBConnect();
        //Get all products from the database
        public DataTable GetAllProducts()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Product";
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
                cmd.Parameters.AddWithValue("@idColor", product.idCategory);
                cmd.Parameters.AddWithValue("@idCollection", (object)product.idCategory ?? DBNull.Value);
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
