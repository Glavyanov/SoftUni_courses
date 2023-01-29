using System;
using System.Collections.Generic;

namespace _02.PermutationsWithRepetitions
{
    public class PermutationsWithRepetitions
    {
        private static string[] result;

        static void Main(string[] args)
        {
            result = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            PermuteWR(0);
        }

        private static void PermuteWR(int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(' ',result));
                return;
            }

            PermuteWR(index + 1);

            HashSet<string> used = new HashSet<string>() { result[index] };

            for (int i = index + 1; i < result.Length; i++)
            {
                if (!used.Contains(result[i]))
                {
                    Swap(index, i);
                    PermuteWR(index + 1);
                    Swap(index, i);

                    used.Add(result[i]);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            (result[index], result[i]) = (result[i], result[index]);
        }
    }
}
