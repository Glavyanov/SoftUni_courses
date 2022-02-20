using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Student_Academy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var logger = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!logger.ContainsKey(name))
                {
                    logger.Add(name, new List<double>());
                }
                logger[name].Add(grade);

            }
            var highOrEqual4dot50 = logger.Where(x => x.Value.Average() >= 4.50).ToDictionary(x => x.Key, x => x.Value.Sum() / x.Value.Count);

            foreach (var item in highOrEqual4dot50.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }
}
