using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class FilterByAge 
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> logger = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                if (!logger.ContainsKey(name))
                {
                    logger.Add(name, 0);
                }
                logger[name] = age;

            }
            string condition = Console.ReadLine();
            int borderAge = int.Parse(Console.ReadLine());
            string[] layout = Console.ReadLine()
                                     .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);

            Func<int, bool> tester = CreateTester(condition, borderAge);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(layout);
            logger.Where(x => tester(x.Value)).ToList().ForEach(x => printer(x));
            
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string[] layout)
        {
            if (layout.Length == 2)
            {
                return person => Console.WriteLine($"{person.Key} - {person.Value}");

            }
            else if (layout[0] == "name")
            {
                return person => Console.WriteLine(person.Key);
            }
            else if (layout[0] == "age")
            {
                return person => Console.WriteLine(person.Value);
            }
            else
            {
                return null;
            }
            
        }

        private static Func<int, bool> CreateTester(string condition, int borderAge)
        {
            if (condition == "younger")
            {
                return x => x < borderAge;
            }
            else if (condition == "older")
            {
                return x => x >= borderAge;
            }
            else
            {
                return null;
            }
        }
    }
}
