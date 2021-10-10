using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string cmnd;
            Func<int, int> func = x => x;
            while ((cmnd = Console.ReadLine()) != "end")
            {

                if (cmnd == "add")
                {
                    func = x => x + 1;
                }
                else if (cmnd == "multiply")
                {
                    func = x => x * 2;

                }
                else if (cmnd == "subtract")
                {
                    func = x => x - 1;

                }
                else if (cmnd == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                    continue;
                }
                numbers = numbers.Select(func).ToList();
            }

        }
    }
}
