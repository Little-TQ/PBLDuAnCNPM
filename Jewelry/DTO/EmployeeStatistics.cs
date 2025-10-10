using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO
{
    public class EmployeeStatistics
    {
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public int PresentDays { get; set; }
        public int LateCount { get; set; }
        public int AbsentDays { get; set; }
        public int LeaveDays { get; set; }
        public int TotalShifts { get; set; }
        public int TotalWorkingDays { get; set; }
    }
}
