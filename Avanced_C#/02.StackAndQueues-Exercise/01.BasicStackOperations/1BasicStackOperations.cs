using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class BasicStackOperations
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
            Stack<int> stack = new Stack<int>();
            int countToPush = operatingNums[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (countToPush == i)
                {
                    break;
                }
                stack.Push(numbers[i]);

            }
            int countToPop = operatingNums[1];
            if (stack.Count > 0)
            {
                for (int i = 0; i < countToPop; i++)
                {
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    stack.Pop();
                }
                
            }
            if (stack.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }
            int numToCheck = operatingNums[2];
            if (stack.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }

        }
    }
}
