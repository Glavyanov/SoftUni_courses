using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                persons.Add(person);
            }
            persons = persons.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, persons));
        }
    }
}
