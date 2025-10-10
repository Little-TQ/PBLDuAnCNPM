using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class ScheduleDTO
    {
        public string IdSchedule { get; set; }
        public string IdEmployee { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime WorkDate { get; set; }
        public string Shift { get; set; }

        // Constructor mặc định
        public ScheduleDTO() { }

        // Constructor với tham số
        public ScheduleDTO(string idSchedule, string idEmployee, string employeeName, string role, string status, DateTime workDate, string shift)
        {
            IdSchedule = idSchedule;
            IdEmployee = idEmployee;
            EmployeeName = employeeName;
            Role = role;
            Status = status;
            WorkDate = workDate;
            Shift = shift;
        }
    }
}
