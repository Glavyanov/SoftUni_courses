using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int readyFood = int.Parse(Console.ReadLine());
            Queue<int> query = new Queue<int>(Console.ReadLine()
                                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(int.Parse));
            Console.WriteLine(query.Max());
            while (query.Any())
            {
                int order = query.Peek();
                if (readyFood >= order)
                {
                    readyFood -= order;
                    query.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (query.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ",query)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
