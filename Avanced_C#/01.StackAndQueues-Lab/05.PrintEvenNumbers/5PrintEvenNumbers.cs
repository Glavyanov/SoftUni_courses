using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            Queue<int> tail = new Queue<int>(arr);
            if (tail.All(x => x % 2 == 0))
            {
                Console.WriteLine(string.Join(", ", tail));
                return;
            }
            for (int i = 0; i < tail.Count; i++)
            {
                if (tail.Peek() % 2 != 0)
                {
                    tail.Dequeue();
                    i--;
                    continue;
                }
                else
                {
                    int num = tail.Dequeue();
                    tail.Enqueue(num);
                    i--;
                }
                if (tail.All(x => x % 2 == 0))
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(", ",tail));
        }
    }
}
