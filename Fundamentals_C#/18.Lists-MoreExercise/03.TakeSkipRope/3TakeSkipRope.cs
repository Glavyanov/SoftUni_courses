using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _03TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                bool digit = char.IsDigit(current);
                if (digit)
                {
                    int currentDigit = int.Parse(current.ToString());
                    numbers.Add(currentDigit);

                }
                else
                {
                    result.Append(current.ToString());
                }
               
            }
            string resultStr = result.ToString();

            List<int> taken = new List<int>(numbers.Count/2);
            List<int> skip = new List<int>(numbers.Count/2);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    int current = numbers[i];
                    taken.Add(current);
                }
                else
                {
                    int current = numbers[i];
                    skip.Add(current);
                }

            }

            string total = string.Empty;
            StringBuilder final = new StringBuilder();
            for (int i = 0; i < taken.Count; i++)
            {
                if (taken[i] > resultStr.Length)
                {
                    taken[i] = resultStr.Length;
                }
                else if (taken[i] < 0)
                {
                    taken[i] = 0;
                }
                total = resultStr.Substring(0, taken[i]);
                resultStr = resultStr.Remove(0, taken[i]);
                if (skip[i] > resultStr.Length)
                {
                    skip[i] = resultStr.Length;
                }
                else if (skip[i] < 0)
                {
                    skip[i] = 0;
                }        
                resultStr = resultStr.Remove(0, skip[i]);
                final.Append(total);
            }
            Console.WriteLine(final.ToString());
        }
    }
}
