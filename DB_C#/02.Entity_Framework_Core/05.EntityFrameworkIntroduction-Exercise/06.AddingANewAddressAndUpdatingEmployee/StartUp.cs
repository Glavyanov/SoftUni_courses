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
            Console.WriteLine(AddNewAddressToEmployee(softUniContext)); 
        }
       
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);
            Employee employeeToUpdate = context.Employees.First(e => e.LastName == "Nakov");
            employeeToUpdate.Address = newAddress;
            context.SaveChanges();

            var orderedEmployees = context.Employees
                                          .OrderByDescending(e => e.AddressId)
                                          .Select(e => e.Address.AddressText)
                                          .Take(10)
                                          .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var e in orderedEmployees)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();
        }
       
    }
}
