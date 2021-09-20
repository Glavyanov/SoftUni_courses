using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            double average = 0;
            if (numbers.Count < 2)
            {
                Console.WriteLine("No");
                return;
            }
            foreach (var item in numbers)
            {
                average += item;
            }
            average /= numbers.Count;
            numbers.Sort();
            numbers.Reverse();
            int count = 0;
            bool flag = true;
            foreach (var item in numbers)
            {
                if (item > average && count < 5)
                {
                    Console.Write($"{item} ");
                    count++;
                    flag = false;

                }

            }
            if (flag)
            {
                Console.WriteLine("No");
            }



        }
    }
}
