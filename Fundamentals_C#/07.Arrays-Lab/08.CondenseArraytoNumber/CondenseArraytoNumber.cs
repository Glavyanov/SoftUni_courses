using System;
using System.Linq;

namespace _08CondenseArraytoNumber
{
    class CondenseArraytoNumber
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            if (input.Length == 1)
            {
                Console.WriteLine(string.Join(' ', input.ToArray()));
            }
            else
            {
                int[] condensed = new int[input.Length - 1];
                int flag = condensed.Length;
                while (flag != 0)
                {
                    for (int j = 0; j < input.Length - 1; j++)
                    {
                        condensed[j] = input[j] + input[j + 1];
                    }
                    input = condensed;
                    condensed = new int[input.Length - 1];
                    flag--;
                }
                Console.WriteLine(string.Join(' ', input.ToArray()));
            }

        }
    }
}
