using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            Console.WriteLine(GetEmployeesFullInformation(softUniContext));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmployees = context.Employees
                                      .OrderBy(e => e.EmployeeId)
                                      .Select(e => new
                                      {
                                          e.FirstName,
                                          e.LastName,
                                          e.MiddleName,
                                          e.JobTitle,
                                          e.Salary
                                      })
                                      .ToArray();
            foreach (var employee in allEmployees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle}{employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
