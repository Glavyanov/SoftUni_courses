using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DemoEFCore
{
    public class DataBaseFirstModel
    {
        public async static Task Main(string[] args)
        {
            using var context = new SoftUniContext();
            //Returns second emlpoyee in Employees ordered by Id
            var secondEmployee = await context.Employees.OrderBy(e => e.EmployeeId).Take(2).LastOrDefaultAsync();
            //Joins
            var firstEmployee = await context.Employees
                                             .Include(e => e.Address)
                                             .ThenInclude(t => t.Town)
                                             .Include(d => d.Department)
                                             .FirstOrDefaultAsync();
            //Next Employee
            var nextEmployee = await context.Employees
                                        .Include(e => e.Address)
                                        .ThenInclude(t => t.Town)
                                        .Include(d => d.Department)
                                        .Where(e => e.EmployeeId == 2)
                                        .FirstOrDefaultAsync();



        }
    }
}
