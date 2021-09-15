using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BombNumbers
{
    class BombNumbers
    {
        
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            int[] bombPower = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
            for (int i = 0; i < numbers.Count ; i++)
            {
                int bomb = bombPower[0];
                int power = bombPower[1];
                if (numbers[i] == bomb)
                {
                    int startindex = i - power;
                    int endindex = i + power;
                    int count = power + power + 1;
                    if (startindex < 0)
                    {
                        count += startindex;
                        startindex = 0;
                    }
                    if (endindex > numbers.Count)
                    {
                        count = numbers.Count - startindex;
                    }

                    numbers.RemoveRange(startindex, count);
                    i = -1;
                }

            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
