using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                family.AddMember(person);
                
            }
            Person result = family.GetOldestMember();
            Console.WriteLine(result);
        }
    }
}
