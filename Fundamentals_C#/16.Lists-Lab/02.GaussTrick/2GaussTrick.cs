using System;
using System.Linq;
using System.Collections.Generic;

namespace _02GaussTrick
{
    class GaussTrick
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int index = numbers.Count / 2;
            for (int i = 0; i < index; i++)
            {
                numbers[i] += numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);

            }
            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
