using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            Stack<int> box = new Stack<int>(Console.ReadLine()
                                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int rack = 1;
            int currentCacity = rackCapacity;
            while (box.Any())
            {
                currentCacity -= box.Peek();
                if (currentCacity >= 0)
                {
                    box.Pop();
                }
                else
                {
                    rack++;
                    currentCacity = rackCapacity;
                }

            }
            Console.WriteLine(rack);
        }
    }
}
