using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(softUniContext)); 
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesFromResearch = context.Employees
                                               .Select(e => new
                                               {
                                                   e.FirstName,
                                                   e.LastName,
                                                   DepartmentName = e.Department.Name,
                                                   e.Salary
                                               })
                                               .Where(e => e.DepartmentName == "Research and Development")
                                               .OrderBy(e => e.Salary)
                                               .ThenByDescending(e => e.FirstName)
                                               .ToArray();
            foreach (var e in employeesFromResearch)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }
     
}
