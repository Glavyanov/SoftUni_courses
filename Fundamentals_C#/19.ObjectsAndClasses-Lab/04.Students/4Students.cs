using System;
using System.Linq;
using System.Collections.Generic;

namespace _04Students
{
     class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public override string  ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }

    }
    class _4Students
    {
        static void Main(string[] args)
        {
            List<Students> student = new List<Students>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] current = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Students nextStudent = new Students();
                nextStudent.FirstName = current[0];
                nextStudent.LastName = current[1];
                nextStudent.Age = int.Parse(current[2]);
                nextStudent.HomeTown = current[3];
                student.Add(nextStudent);

                command = Console.ReadLine();
            }
            
            string city = Console.ReadLine();
            foreach (var nextStudent in student)
            {
                if (nextStudent.HomeTown == city)
                {
                    Console.WriteLine(nextStudent);
                }

            }
        }
    }
}
