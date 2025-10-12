using System;

namespace Jewelry.DTO
{
    public class SalaryDTO
    {
        public string SalaryId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Commission { get; set; }
        public decimal Allowance { get; set; }
        public decimal Deduction { get; set; }
        public decimal TotalSalary { get; set; }
    }
}