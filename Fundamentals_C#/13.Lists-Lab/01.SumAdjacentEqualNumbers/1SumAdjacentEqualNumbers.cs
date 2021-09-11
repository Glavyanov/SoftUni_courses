using System;
using System.Linq;
using System.Collections.Generic;

namespace _01SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(double.Parse)
                                       .ToList();
            for (int i = 0 ; i < numbers.Count-1; i++)
            {
                if (numbers[i] == numbers[i+1])
                {
                    double sum = numbers[i] + numbers[i + 1];
                    numbers.RemoveRange(i , 2);
                    numbers.Insert(i , sum);
                    i = -1;
                }

            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
