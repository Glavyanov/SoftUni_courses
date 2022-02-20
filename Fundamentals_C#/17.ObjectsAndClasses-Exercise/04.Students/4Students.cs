using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Students
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                string lastName = person[1];
                double grade = double.Parse(person[2]);
                Student student = new Student(name, lastName, grade);
                students.Add(student);
            }
            foreach (var item in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(item);
            }
        }
    }
    class Student
    {
        public Student(string name, string last, double grade)
        {
            Name = name;
            LastName = last;
            Grade = grade;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}: {Grade:F2}"; 
        }
    }
}
