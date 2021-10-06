using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] operatingNums = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();
            int[] numbers = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();
            Queue<int> query = new Queue<int>();
            int countToAdd = operatingNums[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (countToAdd == i)
                {
                    break;
                }
                query.Enqueue(numbers[i]);
            }
            int countToRemove= operatingNums[1];
            if (query.Count > 0)
            {
                for (int i = 0; i < countToRemove; i++)
                {
                    if (countToRemove == i)
                    {
                        break;
                    }
                    query.Dequeue();
                }

            }
            if (query.Count < 1)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }
            int numToCheck = operatingNums[2];
            if (query.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(query.Min());
            }

        }
    }
}
