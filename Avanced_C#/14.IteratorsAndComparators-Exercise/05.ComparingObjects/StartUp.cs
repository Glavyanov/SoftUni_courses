using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person("g", 2, "gg");
            List<Person> persons = new List<Person>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                persons.Add(person);
            }
            int count = int.Parse(Console.ReadLine());
            Person personToCompare = new Person();
            if (count > 0 && count <= persons.Count)
            {
                personToCompare = persons[count - 1];

            }
            int countMathes = 0;
            int countNonMathes = 0;
            foreach (var item in persons)
            {
                int result = personToCompare.CompareTo(item);
                if (result != 0)
                {
                    countNonMathes++;
                }
                else
                {
                    countMathes++;
                }

            }
            if (countMathes == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countMathes} {countNonMathes} {persons.Count}");
            }
        }
    }
}
