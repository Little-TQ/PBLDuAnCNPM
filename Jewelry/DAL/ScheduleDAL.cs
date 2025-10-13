using Jewelry.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Jewelry.DAL
{
    internal class ScheduleDAL
    {
        private DBConnect db = new DBConnect();

        // Lấy thống kê theo tháng
        public DataTable GetMonthlyStatistics(DateTime month)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
               
                e.NameEmployee as EmployeeName,
                r.RoleName as Role,
                COUNT(CASE WHEN s.Status = 'Present' THEN 1 END) as PresentDays,
                COUNT(CASE WHEN s.Status = 'Late' THEN 1 END) as LateCount,
                COUNT(CASE WHEN s.Status = 'Absent' THEN 1 END) as AbsentDays,
                COUNT(CASE WHEN s.Status = 'On Leave' THEN 1 END) as LeaveDays,

                SUM(CASE 
                    WHEN s.Shift = 'Full-time' THEN 3
                    WHEN s.Shift IN ('Morning', 'Afternoon', 'Evening') THEN 1
                    ELSE 0 
                END) as TotalShifts,
                COUNT(CASE WHEN s.Status IN ('Present', 'Late') THEN 1 END) as TotalWorkingDays
            FROM Employee e
            INNER JOIN Role r ON e.idRole = r.idRole
            LEFT JOIN Schedule s ON e.idEmployee = s.idEmployee 
                AND MONTH(s.WorkDate) = @Month 
                AND YEAR(s.WorkDate) = @Year
            GROUP BY e.idEmployee, e.NameEmployee, r.RoleName
            ORDER BY e.idEmployee";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Month", month.Month);
                adapter.SelectCommand.Parameters.AddWithValue("@Year", month.Year);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Lấy danh sách nhân viên để chấm công
        public DataTable GetEmployeesForAttendance(DateTime workDate)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        e.idEmployee,
                        e.NameEmployee, 
                        r.RoleName as Role,
                        ISNULL(s.Status, '') as Status,
                        ISNULL(s.Shift, '') as Shift,
                        ISNULL(s.idSchedule, '') as idSchedule
                    FROM Employee e
                    INNER JOIN Role r ON e.idRole = r.idRole
                    LEFT JOIN Schedule s ON e.idEmployee = s.idEmployee AND s.WorkDate = @WorkDate
                    ORDER BY e.idEmployee";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@WorkDate", workDate.Date);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Lưu chấm công - SỬA LẠI HOÀN TOÀN
        public bool SaveAttendance(ScheduleDTO schedule)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Kiểm tra xem đã có schedule cho nhân viên này trong ngày chưa
                string checkQuery = @"
                    SELECT idSchedule 
                    FROM Schedule 
                    WHERE idEmployee = @employeeId AND WorkDate = @workDate";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@employeeId", schedule.IdEmployee);
                checkCmd.Parameters.AddWithValue("@workDate", schedule.WorkDate.Date);

                object existingId = checkCmd.ExecuteScalar();

                string query;
                if (existingId != null && !string.IsNullOrEmpty(existingId.ToString()))
                {
                    // UPDATE nếu đã tồn tại
                    query = @"UPDATE Schedule 
                             SET Status = @status, Shift = @shift
                             WHERE idEmployee = @employeeId AND WorkDate = @workDate";
                }
                else
                {
                    // INSERT mới nếu chưa tồn tại
                    query = @"INSERT INTO Schedule (idSchedule, idEmployee, Status, WorkDate, Shift)
                             VALUES (@id, @employeeId, @status, @workDate, @shift)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (existingId == null || string.IsNullOrEmpty(existingId.ToString()))
                    {
                        // Chỉ generate ID mới khi INSERT
                        cmd.Parameters.AddWithValue("@id", GenerateUniqueScheduleID());
                    }
                    cmd.Parameters.AddWithValue("@employeeId", schedule.IdEmployee);
                    cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(schedule.Status) ? "" : schedule.Status);
                    cmd.Parameters.AddWithValue("@workDate", schedule.WorkDate.Date);
                    cmd.Parameters.AddWithValue("@shift", string.IsNullOrEmpty(schedule.Shift) ? "" : schedule.Shift);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tạo ID duy nhất 
        private string GenerateUniqueScheduleID()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // Lấy ID cuối cùng từ database
                string query = @"
                    SELECT TOP 1 idSchedule
                    FROM Schedule
                    ORDER BY idSchedule DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return "SC001";

                    string lastID = result.ToString();

                    // Tách số từ ID cuối cùng
                    if (lastID.StartsWith("SC") && lastID.Length > 2)
                    {
                        string numericPart = lastID.Substring(2);
                        if (int.TryParse(numericPart, out int number))
                        {
                            number++;
                            return $"SC{number:D3}"; // Format 3 chữ số
                        }
                    }

                    // Fallback: sử dụng timestamp nếu không parse được
                    return "SC" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
            }
        }

        // Lấy schedules as List<ScheduleDTO> 
        public List<ScheduleDTO> GetSchedulesListByDate(DateTime workDate)
        {
            List<ScheduleDTO> schedules = new List<ScheduleDTO>();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        e.idEmployee,
                        e.NameEmployee, 
                        r.RoleName as Role,
                        ISNULL(s.idSchedule, '') as idSchedule,
                        ISNULL(s.Status, '') as Status,
                        ISNULL(s.Shift, '') as Shift
                    FROM Employee e
                    INNER JOIN Role r ON e.idRole = r.idRole
                    LEFT JOIN Schedule s ON e.idEmployee = s.idEmployee AND s.WorkDate = @WorkDate
                    ORDER BY e.idEmployee";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@WorkDate", workDate.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ScheduleDTO schedule = new ScheduleDTO
                            {
                                IdEmployee = reader["idEmployee"].ToString(),
                                EmployeeName = reader["NameEmployee"].ToString(),
                                Role = reader["Role"].ToString(),
                                IdSchedule = reader["idSchedule"].ToString(),
                                Status = reader["Status"].ToString(),
                                WorkDate = workDate,
                                Shift = reader["Shift"].ToString()
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }

            return schedules;
        }

        // Statistics for attendance
        public (int present, int absent, int onLeave, int late, int total) GetAttendanceStatistics(DateTime workDate)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        Status, 
                        COUNT(*) AS Total
                    FROM Schedule
                    WHERE WorkDate = @workDate
                    GROUP BY Status";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@workDate", workDate.Date);
                SqlDataReader reader = cmd.ExecuteReader();

                int present = 0, absent = 0, onLeave = 0, late = 0;
                int total = 0;

                while (reader.Read())
                {
                    string status = reader["Status"].ToString().Trim();
                    int count = Convert.ToInt32(reader["Total"]);
                    total += count;

                    switch (status.ToLower())
                    {
                        case "present": present = count; break;
                        case "absent": absent = count; break;
                        case "on leave": onLeave = count; break;
                        case "late": late = count; break;
                    }
                }

                reader.Close();
                return (present, absent, onLeave, late, total);
            }
        }
    }
}