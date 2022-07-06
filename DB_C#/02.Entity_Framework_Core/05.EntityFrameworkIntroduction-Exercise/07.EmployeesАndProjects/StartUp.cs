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
            Console.WriteLine(GetEmployeesInPeriod(softUniContext)); 
        }
       
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                                   .Include(e => e.EmployeesProjects)
                                   .Where(e => e.EmployeesProjects.Any(e => e.Project.StartDate.Year >= 2001 &&
                                                                            e.Project.StartDate.Year <= 2003))
                                   .Take(10)
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       ManagerFistName = e.Manager.FirstName,
                                       ManagerLastName = e.Manager.LastName,
                                       AllProjects = e.EmployeesProjects
                                                      .Select(p => new
                                                      {
                                                          p.Project.Name,
                                                          p.Project.StartDate,
                                                          p.Project.EndDate
                                                      })
                                                      .ToArray()
                                   })
                                   .ToArray();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFistName} {e.ManagerLastName}");
                foreach (var p in e.AllProjects)
                {
                    sb.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {(p.EndDate == null ? "not finished" : p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }

            return sb.ToString().TrimEnd();
        }
       
    }
}
