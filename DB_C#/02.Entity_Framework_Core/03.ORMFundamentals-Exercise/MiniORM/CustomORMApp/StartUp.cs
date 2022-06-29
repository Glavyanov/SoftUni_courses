using CustomORMApp.Data;
using CustomORMApp.Data.Models;
using MiniORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomORMApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniDbContext(Config.connectionString);

            context.Employees.Add(new Employee 
            { 
                FirstName = "Ivo",
                LastName = "Ivov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
