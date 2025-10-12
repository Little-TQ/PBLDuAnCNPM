using Jewelry.DAL;
using Jewelry.DTO;
using System;
using System.Data;

namespace Jewelry.BLL
{
    public class SalaryBLL
    {
        private SalaryDAL salaryDAL = new SalaryDAL();

        // Get salary list by month
        public DataTable GetSalaries(int month, int year, string role = "", string employeeId = "")
            => salaryDAL.GetSalariesByMonth(month, year, role, employeeId);

        // Get salary details of a specific employee
        public DataTable GetEmployeeSalary(string employeeId, int month, int year)
            => salaryDAL.GetEmployeeSalary(employeeId, month, year);
        // Update existing salary record
        public bool UpdateSalary(SalaryDTO salary) => salaryDAL.UpdateSalary(salary);

        // Get total number of times an employee was late
        public int GetLateCount(string employeeId, int month, int year)
            => salaryDAL.GetLateCount(employeeId, month, year);

        // Get roles that currently have employees assigned
        public DataTable GetRolesWithEmployees()
        {
            try
            {
                return salaryDAL.GetRolesWithEmployees();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving roles with employees: " + ex.Message);
            }
        }
    }
}
