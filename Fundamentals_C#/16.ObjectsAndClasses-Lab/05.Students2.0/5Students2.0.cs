using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Students2._0
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }

    }
    class _5Students20
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
                bool flag = true;
                int index = 0;
                foreach (var item in student)
                {
                    if (item.LastName == nextStudent.LastName && item.FirstName == nextStudent.FirstName)
                    {
                        index = student.FindIndex(x => x.FirstName == nextStudent.FirstName && x.LastName == nextStudent.LastName);
                            flag = false;
                            break;
                        
                    }

                }
                if (flag)
                {
                    student.Add(nextStudent);

                }
                else
                {
                    student.RemoveAt(index);
                    student.Add(nextStudent);

                }
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
