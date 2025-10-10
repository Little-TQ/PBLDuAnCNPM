using Jewelry.DTO;
using Jewelry.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jewelry.BLL
{
    internal class ScheduleBLL
    {
        private ScheduleDAL scheduleDAL = new ScheduleDAL();

        // Lấy thống kê tháng
        public DataTable GetMonthlyStatistics(DateTime month)
        {
            return scheduleDAL.GetMonthlyStatistics(month);
        }

        // Lấy danh sách chấm công
        public DataTable GetEmployeesForAttendance(DateTime workDate)
        {
            return scheduleDAL.GetEmployeesForAttendance(workDate);
        }

        // Lưu chấm công
        public bool SaveAttendance(ScheduleDTO schedule)
        {
            return scheduleDAL.SaveAttendance(schedule);
        }

        // Lưu nhiều chấm công
        public bool SaveMultipleAttendance(List<ScheduleDTO> schedules)
        {
            bool allSuccess = true;
            foreach (var schedule in schedules)
            {
                if (!SaveAttendance(schedule))
                    allSuccess = false;
            }
            return allSuccess;
        }
    }
}