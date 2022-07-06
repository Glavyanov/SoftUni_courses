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
            Console.WriteLine(GetAddressesByTown(softUniContext)); 
        }
   
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var topTenAddresses = context.Addresses
                                         .Select(a => new
                                         {
                                             a.AddressText,
                                             a.Town.Name,
                                             a.Employees.Count

                                         })
                                         .OrderByDescending(a => a.Count)
                                         .ThenBy(a => a.Name)
                                         .ThenBy(a => a.AddressText)
                                         .Take(10)
                                         .ToList();
            topTenAddresses.ForEach(a =>
            {
                sb.AppendLine($"{a.AddressText}, {a.Name} - {a.Count} employees");
            });

            return sb.ToString().TrimEnd();
        }
    }
}
