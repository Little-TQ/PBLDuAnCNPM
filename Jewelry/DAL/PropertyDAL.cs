using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DAL
{
    internal class PropertyDAL
    {
        private DBConnect db = new DBConnect();
        //Get Data
         public DataTable GetPropertyData(string tableName)
        {

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = $"SELECT * FROM {tableName}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        //Generate ID
        public string GenerateNewPropertyID(string tableName)
        {
            string prefix = "";
            string idColumn = "";

            switch (tableName.ToLower())
            {
                case "category":
                    prefix = "Cat";
                    idColumn = "idCategory";
                    break;
                case "material":
                    prefix = "Mat";
                    idColumn = "idMaterial";
                    break;
                case "color":
                    prefix = "Col";
                    idColumn = "idColor";
                    break;
                case "collection":
                    prefix = "Collect";
                    idColumn = "idCollection";
                    break;
                default:
                    throw new Exception("Invalid property table name");
            }

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = $@"
            SELECT TOP 1 {idColumn} 
            FROM {tableName} 
            ORDER BY 
                TRY_CAST(REPLACE({idColumn}, '{prefix}', '') AS INT) DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return $"{prefix}01";

                    string lastID = result.ToString();
                    string numericPart = lastID.Replace(prefix,"");
                    int number;
                    if (!int.TryParse(numericPart, out number))
                        number = 0;

                    number++;
                    return $"{prefix}{number:D2}";
                }
            }
        }

        //Add new item
        public bool AddPropertyItem(string tableName, string columnName, string value, string id)
        {
            string idColumn = "";

            switch (tableName.ToLower())
            {
                case "category": idColumn = "idCategory"; break;
                case "material": idColumn = "idMaterial"; break;
                case "color": idColumn = "idColor"; break;
                case "collection": idColumn = "idCollection"; break;
                default: throw new Exception("Invalid table name");
            }

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = $"INSERT INTO {tableName} ({idColumn}, {columnName}) VALUES (@ID, @Value)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Value", value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //Delete
        public bool DeletePropertyItem(string tableName, string idColumn, string id)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = $"DELETE FROM {tableName} WHERE {idColumn} = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //Update
        public bool UpdatePropertyItem(string tableName, string idColumn, string id, string nameColumn, string newValue)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = $"UPDATE {tableName} SET {nameColumn} = @Value WHERE {idColumn} = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Value", newValue);
                    cmd.Parameters.AddWithValue("@ID", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //Get Material Name by ID
        public string GetMaterialNameByID(string idMaterial)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT NameMaterial FROM Material WHERE idMaterial = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idMaterial);
                conn.Open();
                var result = cmd.ExecuteScalar();
                conn.Close();
                return result?.ToString() ?? "";
            }
        }


    }
}
