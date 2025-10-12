using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Jewelry.DTO;

namespace Jewelry.DAL
{
    public class SalaryDAL
    {
        private readonly DBConnect db = new DBConnect();

        public int GetLateCount(string employeeId, int month, int year)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*) 
                    FROM Schedule 
                    WHERE idEmployee = @EmployeeId 
                    AND MONTH(WorkDate) = @Month 
                    AND YEAR(WorkDate) = @Year 
                    AND Status = 'Late'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);

                return (int)cmd.ExecuteScalar();
            }
        }

        public DataTable GetSalariesByMonth(int month, int year, string role = "", string employeeId = "")
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        e.idEmployee,
                        e.NameEmployee AS EmployeeName,
                        r.RoleName AS Role,
                        (SELECT COUNT(DISTINCT CAST(sch.WorkDate AS DATE))
                         FROM Schedule sch
                         WHERE sch.idEmployee = e.idEmployee 
                         AND MONTH(sch.WorkDate) = @Month 
                         AND YEAR(sch.WorkDate) = @Year
                         AND sch.Status IN ('Present', 'Late')) AS TotalWorkingDays,
                        (SELECT COUNT(*)
                         FROM Schedule sch
                         WHERE sch.idEmployee = e.idEmployee 
                         AND MONTH(sch.WorkDate) = @Month 
                         AND YEAR(sch.WorkDate) = @Year
                         AND sch.Status = 'Late') AS LateCount,
                        ISNULL(s.BasicSalary, 0) AS BasicSalary,
                        ISNULL(s.Commission, 0) AS Commission,
                        ISNULL(s.Allowance, 0) AS Allowance,
                        ((SELECT COUNT(*)
                          FROM Schedule sch
                          WHERE sch.idEmployee = e.idEmployee 
                          AND MONTH(sch.WorkDate) = @Month 
                          AND YEAR(sch.WorkDate) = @Year
                          AND sch.Status = 'Late') * 20000) AS Deduction,
                        (ISNULL(s.BasicSalary, 0) + ISNULL(s.Commission, 0) + ISNULL(s.Allowance, 0) - 
                         ((SELECT COUNT(*)
                           FROM Schedule sch
                           WHERE sch.idEmployee = e.idEmployee 
                           AND MONTH(sch.WorkDate) = @Month 
                           AND YEAR(sch.WorkDate) = @Year
                           AND sch.Status = 'Late') * 20000)) AS TotalSalary,
                        CASE WHEN s.idEmployee IS NOT NULL THEN 1 ELSE 0 END AS HasSalary
                    FROM Employee e
                    INNER JOIN Role r ON e.idRole = r.idRole
                    LEFT JOIN Salary s ON e.idEmployee = s.idEmployee
                    WHERE 
                        (@Role = '' OR r.RoleName = @Role)
                        AND (@EmployeeId = '' OR e.idEmployee = @EmployeeId)
                    ORDER BY e.idEmployee;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(role) ? "" : role);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", string.IsNullOrEmpty(employeeId) ? "" : employeeId);
                adapter.SelectCommand.Parameters.AddWithValue("@Month", month);
                adapter.SelectCommand.Parameters.AddWithValue("@Year", year);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable GetEmployeeSalary(string employeeId, int month, int year)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        e.idEmployee,
                        e.NameEmployee AS EmployeeName,
                        r.RoleName AS Role,
                        ISNULL(s.BasicSalary, 0) AS BasicSalary,
                        (SELECT COUNT(DISTINCT CAST(sch.WorkDate AS DATE))
                         FROM Schedule sch
                         WHERE sch.idEmployee = e.idEmployee 
                         AND MONTH(sch.WorkDate) = @Month 
                         AND YEAR(sch.WorkDate) = @Year
                         AND sch.Status IN ('Present', 'Late')) AS TotalWorkingDays,
                        ISNULL(s.Allowance, 0) AS Allowance,
                        ISNULL(s.Commission, 0) AS Commission,
                        ISNULL(s.Deduction, 0) AS Deduction,
                        ISNULL(s.TotalSalary, 0) AS TotalSalary
                    FROM Employee e
                    INNER JOIN Role r ON e.idRole = r.idRole
                    LEFT JOIN Salary s ON e.idEmployee = s.idEmployee
                    WHERE e.idEmployee = @EmployeeId;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                adapter.SelectCommand.Parameters.AddWithValue("@Month", month);
                adapter.SelectCommand.Parameters.AddWithValue("@Year", year);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        private string GenerateUniqueSalaryID()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 idSalary
                    FROM Salary
                    ORDER BY idSalary DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return "SL001";

                    string lastID = result.ToString();

                    if (lastID.StartsWith("SL") && lastID.Length > 2)
                    {
                        string numericPart = lastID.Substring(2);
                        if (int.TryParse(numericPart, out int number))
                        {
                            number++;
                            return $"SL{number:D3}";
                        }
                    }

                    return "SL" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
            }
        }
        public DataTable GetRolesWithEmployees()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT DISTINCT r.RoleName
                    FROM Role r
                    INNER JOIN Employee e ON r.idRole = e.idRole
                    WHERE EXISTS (
                        SELECT 1 FROM Employee 
                        WHERE idRole = r.idRole
                    )
                    ORDER BY r.RoleName";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool UpdateSalary(SalaryDTO salary)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Salary WHERE idEmployee = @EmployeeId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@EmployeeId", salary.EmployeeId);
                int existingCount = (int)checkCmd.ExecuteScalar();

                string query;
                if (existingCount > 0)
                {
                    query = @"UPDATE Salary 
                             SET BasicSalary = @BasicSalary,
                                 Commission = @Commission,
                                 Allowance = @Allowance,
                                 Deduction = @Deduction
                             WHERE idEmployee = @EmployeeId";
                }
                else
                {
                    query = @"INSERT INTO Salary (idSalary, idEmployee, BasicSalary, Commission, Allowance, Deduction)
                             VALUES (@idSalary, @EmployeeId, @BasicSalary, @Commission, @Allowance, @Deduction)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (existingCount == 0)
                    {
                        cmd.Parameters.AddWithValue("@idSalary", GenerateUniqueSalaryID());
                    }
                    cmd.Parameters.AddWithValue("@EmployeeId", salary.EmployeeId);
                    cmd.Parameters.AddWithValue("@BasicSalary", salary.BasicSalary);
                    cmd.Parameters.AddWithValue("@Commission", salary.Commission);
                    cmd.Parameters.AddWithValue("@Allowance", salary.Allowance);
                    cmd.Parameters.AddWithValue("@Deduction", salary.Deduction);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
