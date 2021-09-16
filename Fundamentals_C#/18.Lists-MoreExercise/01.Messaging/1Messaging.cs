using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            string message = Console.ReadLine();
            List<char> chars = message.ToCharArray().ToList();
            string result = string.Empty;
            foreach (var item in nums)
            {
                int sum = 0;
                int current = item;
                while (current != 0)
                {
                    int digit = current % 10;
                    sum += digit;
                    current /= 10;

                }
                for (int i = 0; i < chars.Count; i++)
                {
                    if (sum == i)
                    {
                        result += chars[i];
                        chars.RemoveAt(i);
                        break;
                    }
                    if (i == chars.Count - 1)
                    {
                        i = -1;
                        sum -= chars.Count;
                    }
                }

            }
            Console.WriteLine(result);
        }
    }
}
