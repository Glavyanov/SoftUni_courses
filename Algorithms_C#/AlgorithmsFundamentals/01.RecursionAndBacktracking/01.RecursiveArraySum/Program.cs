using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(GetSumRecursive(arr));

        }

        private static int GetSumRecursive(int[] arr, int index = 0)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSumRecursive(arr, index + 1);
        }
    }
}
