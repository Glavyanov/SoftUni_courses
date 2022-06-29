using ExerciseORM.Data;
using ExerciseORM.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ExerciseORM
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using ExerciseDBContext dbContext = new ExerciseDBContext();
            var itEmployees = dbContext.Employees.Where(x => x.Department.Name == "IT")
                                                 .Select(x => new
                                                 {
                                                     x.FirstName,
                                                     x.LastName,
                                                     x.JobTitle
                                                 })
                                                 .ToList();
            Console.WriteLine("Department: IT");
            itEmployees.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} - {x.JobTitle}"));

            //Executed Once
            /*Department it = new Department() 
            {
                Name = "IT",
                
            };
            Department hr = new Department()
            {
                Name = "HR",

            };
            Department pr = new Department()
            {
                Name = "PR",

            };

            dbContext.Departments.Add(it);
            dbContext.Departments.Add(pr);
            dbContext.Departments.Add(hr);

            Employee sava = new()
            {
                FirstName = "Sava",
                LastName = "Savov",
                JobTitle = "great IT",
                Department = it
            };

            Employee ivo = new()
            {
                FirstName = "Ivo",
                LastName = "Ivov",
                JobTitle = "great HR",
                Department = hr
            };
            Employee sevda = new()
            {
                FirstName = "Sevda",
                LastName = "Arnaudova",
                JobTitle = "great PR",
                Department = pr
            };

            dbContext.Employees.Add(sava);
            dbContext.Employees.Add(ivo);
            dbContext.Employees.Add(sevda);

            dbContext.SaveChanges();
            Console.WriteLine("GO");*/
        }
    }
}
