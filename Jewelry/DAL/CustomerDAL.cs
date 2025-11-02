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
    internal class CustomerDAL
    {
        private DBConnect db= new DBConnect();

       //Get all customers
       public DataTable GetAllCustomers()
        {
            using (SqlConnection conn= db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customer";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        //Generate ID
        public string GenerateCustomerID()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                            SELECT TOP 1 idCustomer
                            FROM Customer
                            ORDER BY TRY_CAST(REPLACE(idCustomer, 'C', '') AS INT) DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return "C001"; 

                    string lastID = result.ToString(); // ví dụ "C005"
                    string numericPart = lastID.Replace("C", "");
                    int number = 0;

                    if (!int.TryParse(numericPart, out number))
                        number = 0;

                    number++;
                    return $"C{number:D3}"; // C001, C002, ...
                }
            }
        }
        //Add new Customer
        public bool AddCustomer(CustomerDTO c)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Customer (idCustomer, NameCustomer, PhoneNumberC, Point, Membership, AddressC)
                         VALUES (@id, @name, @phone, @point, @membership, @address)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", c.idCustomer);
                    cmd.Parameters.AddWithValue("@name", c.NameCustomer);
                    cmd.Parameters.AddWithValue("@phone", c.PhoneNumberC);
                    cmd.Parameters.AddWithValue("@point", c.Point);
                    cmd.Parameters.AddWithValue("@membership", c.Membership);
                    cmd.Parameters.AddWithValue("@address", c.AddressC);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //Update Customer
        public bool UpdateCustomer(CustomerDTO c)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Customer 
                                 SET NameCustomer = @name, 
                                     PhoneNumberC = @phone, 
                                     Point = @point, 
                                     Membership = @member, 
                                     AddressC = @address
                                 WHERE idCustomer = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", c.idCustomer);
                    cmd.Parameters.AddWithValue("@name", c.NameCustomer);
                    cmd.Parameters.AddWithValue("@phone", c.PhoneNumberC);
                    cmd.Parameters.AddWithValue("@point", c.Point);
                    cmd.Parameters.AddWithValue("@member", c.Membership);
                    cmd.Parameters.AddWithValue("@address", c.AddressC);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //Delete Customer
        public bool DeleteCustomer(string id)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Customer WHERE idCustomer = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //Statistic
        public (int diamond, int gold, int silver, int bronze, int total, string topRank) GetCustomerRankStatistics()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

               
                string query = @"
            SELECT 
                Membership, 
                COUNT(*) AS Total
            FROM Customer
            GROUP BY Membership";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                int diamond = 0, gold = 0, silver = 0, bronze = 0;
                int total = 0;
                string topRank = "N/A";
                int maxCount = 0;

                while (reader.Read())
                {
                    string membership = reader["Membership"].ToString().Trim();
                    int count = Convert.ToInt32(reader["Total"]);
                    total += count;

                    switch (membership.ToLower())
                    {
                        case "diamond": diamond = count; break;
                        case "gold": gold = count; break;
                        case "silver": silver = count; break;
                        case "bronze": bronze = count; break;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                        topRank = membership;
                    }
                }

                reader.Close();
                return (diamond, gold, silver, bronze, total, topRank);
            }
        }
        // Get customer by phone number
        public CustomerDTO GetCustomerByPhone(string phone)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customer WHERE PhoneNumberC = @phone";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerDTO
                            {
                                idCustomer = reader["idCustomer"].ToString(),
                                NameCustomer = reader["NameCustomer"].ToString(),
                                PhoneNumberC = reader["PhoneNumberC"].ToString(),
                                Point = Convert.ToInt32(reader["Point"]),
                                Membership = reader["Membership"].ToString(),
                                AddressC = reader["AddressC"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
        //Update Customer Point
        //Update Customer Membership
        public bool UpdateCustomerPointAndMembership(string idCustomer, decimal total)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                int addPoint = (int)Math.Floor(total / 500000);

                string getPointQuery = "SELECT Point FROM Customer WHERE idCustomer = @id";
                SqlCommand getCmd = new SqlCommand(getPointQuery, conn);
                getCmd.Parameters.AddWithValue("@id", idCustomer);
                int currentPoint = Convert.ToInt32(getCmd.ExecuteScalar() ?? 0);

                int newPoint = currentPoint + addPoint;

                string membership = "";
                if (newPoint >= 100)
                    membership = "Diamond";
                else if (newPoint >= 50)
                    membership = "Gold";
                else if (newPoint >= 20)
                    membership = "Silver";
                else if (newPoint < 20 && newPoint >= 0)
                    membership = "Bronze";

                string updateQuery = @"UPDATE Customer 
                               SET Point = @newPoint, Membership = @membership 
                               WHERE idCustomer = @id";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@newPoint", newPoint);
                updateCmd.Parameters.AddWithValue("@membership", membership);
                updateCmd.Parameters.AddWithValue("@id", idCustomer);

                return updateCmd.ExecuteNonQuery() > 0;
            }
        }
        public CustomerDTO GetCustomerById(string customerId)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customer WHERE idCustomer = @idCustomer";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCustomer", customerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CustomerDTO
                        {
                            idCustomer = reader["idCustomer"].ToString(),
                            NameCustomer = reader["NameCustomer"].ToString(),
                            PhoneNumberC = reader["PhoneNumberC"].ToString(),
                            AddressC = reader["AddressC"]?.ToString(),
                            Point = reader["Point"] != DBNull.Value ? Convert.ToInt32(reader["Point"]) : 0,
                            Membership = reader["Membership"]?.ToString()
                        };
                    }
                }
                return null;
            }
        }

    }
}
