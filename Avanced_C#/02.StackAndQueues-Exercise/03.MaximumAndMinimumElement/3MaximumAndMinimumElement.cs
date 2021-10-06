using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
                if (arr[0] == 1)
                {
                    stack.Push(arr[1]);
                }
                else if (arr[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (arr[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (arr[0] == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }

                }

            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
