using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class StarUp
    {
        public static void Main(string[] args)
        {
            List<IPerson> persons = new List<IPerson>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personsArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                IPerson person;
                if (personsArgs.Length > 2)
                {
                    person = new Citizen(personsArgs[0], int.Parse(personsArgs[1]), personsArgs[2]);
                    persons.Add(person);
                }
                else
                {
                    person = new Robot(personsArgs[0], personsArgs[1]);
                    persons.Add(person);
                }
            }
            string filter = Console.ReadLine();
            foreach (var person in persons)
            {
                if (person.Id.EndsWith(filter))
                {
                    Console.WriteLine(person.Id);
                }
            }
        }
    }
}
