using System;

namespace _01.ReverseArray
{
    public class ReverseArray
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Reverse(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(' ', arr));
        }

        private static void Reverse(string[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            (arr[start], arr[end]) = (arr[end], arr[start]);
            Reverse(arr, ++start, --end);
        }
    }
}
