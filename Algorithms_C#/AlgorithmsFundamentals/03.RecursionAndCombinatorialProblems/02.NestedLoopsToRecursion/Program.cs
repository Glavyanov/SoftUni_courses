using System;

namespace _02.NestedLoopsToRecursion
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Loop(new int[n]);
        }

        private static void Loop(int[] arr, int index = 0)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(' ', arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                Loop(arr, index + 1);
            }
        }
    }
}
