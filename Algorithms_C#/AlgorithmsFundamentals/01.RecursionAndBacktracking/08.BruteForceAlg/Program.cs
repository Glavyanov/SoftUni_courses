using System;
using System.Linq;

namespace _08.BruteForceAlg
{
    public class Program
    {
        private static int count = 0;
        private const int size = 5;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = input[0];
            int end = input[1];
            if (end < start)
            {
                (start, end) = (end, start);
            }

            BruteForce(new int[size], 0, start, end);
        }

        private static void BruteForce(int[] ints, int index, int start, int end)
        {
            if (index >= ints.Length)
            {
                Console.WriteLine($"{(++count).ToString("000")}. {string.Join(' ', ints)}");
                return;
            }

            for (int i = start; i <= end; i++)
            {
                ints[index] = i;
                BruteForce(ints, index + 1, start, end);
            }
        }
    }
}
