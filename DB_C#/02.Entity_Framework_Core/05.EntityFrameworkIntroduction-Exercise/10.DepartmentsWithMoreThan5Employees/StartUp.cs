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
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(softUniContext)); 
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                                     .Where(d => d.Employees.Count > 5)
                                     .Select(d => new
                                     {
                                         d.Name,
                                         ManagerFirstName = d.Manager.FirstName,
                                         ManagerLastName = d.Manager.LastName,
                                         d.Employees
                                     })
                                     .OrderBy(x => x.Employees.Count)
                                     .ThenBy(y => y.Name)
                                     .ToList();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName}  - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
