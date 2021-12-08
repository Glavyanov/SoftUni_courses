using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<IBirthable> birthables = new List<IBirthable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personsArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                IBirthable birthable = null;
                if (personsArgs[0].ToLower() == "citizen")
                {
                    birthable = new Citizen(personsArgs[1], int.Parse(personsArgs[2]), personsArgs[3], personsArgs[4]);
                    
                }
                else if (personsArgs[0].ToLower() == "pet")
                {
                    birthable = new Pet(personsArgs[1], personsArgs[2]);
                }
                if (birthable != null)
                {
                    birthables.Add(birthable);
                }
            }
            string filter = Console.ReadLine();
            Console.WriteLine(string.Join(Environment.NewLine, birthables.Where(p => p.BirthDate.EndsWith(filter)).Select(p => p.BirthDate)));
            //foreach (var person in birthables)
            //{
            //    if (person.BirthDate.EndsWith(filter))
            //    {
            //        Console.WriteLine(person.BirthDate);
            //    }
            //}

        }
    }
}
