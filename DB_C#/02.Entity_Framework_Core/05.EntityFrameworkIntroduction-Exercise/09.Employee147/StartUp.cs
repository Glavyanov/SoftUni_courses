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
            Console.WriteLine(GetEmployee147(softUniContext)); 
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee = context.Employees
                                  .Select(e => new
                                  {
                                      e.EmployeeId,
                                      e.FirstName,
                                      e.LastName,
                                      e.JobTitle,
                                      Projects = e.EmployeesProjects.Select(p => p.Project.Name).ToArray()
                                  })
                                  .FirstOrDefault(e => e.EmployeeId == 147);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (string project in employee.Projects.OrderBy(p => p))
            {
                sb.AppendLine($"{project}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
