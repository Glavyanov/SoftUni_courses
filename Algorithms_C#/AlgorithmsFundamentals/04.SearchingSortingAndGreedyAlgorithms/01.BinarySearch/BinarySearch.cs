using System;
using System.Linq;

namespace _01.BinarySearch
{
    public class BinarySearch
    {
        private static int[] arr;

        private static int n;

        private static int NOT_FOUND = -1;


        static void Main(string[] args)
        {
            arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            n = int.Parse(Console.ReadLine());
            int left = 0;
            int right = arr.Length - 1;
            Console.WriteLine(FindNum(left, right)); // recursive

            /*while (left <= right)
            {
                int mid = (left + right) / 2;

                if (Guess(mid) is 0)
                {
                    Console.WriteLine(mid);
                    return;
                }

                if (Guess(mid) is 1)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }
            Console.WriteLine(NOT_FOUND);*/
        }

        private static int FindNum(int left, int right)
        {
            int mid = (left + right) / 2;
            
            if (Guess(mid) is 0)
            {
                return mid;
            }

            if (left >= right)
            {
                return NOT_FOUND;
            }

            if (Guess(mid) is 1)
            {
                return FindNum(left, mid - 1);
            }
            else
            {
                return FindNum(mid + 1, right);
            }

        }

        private static int Guess(int x) => arr[x] < n ? -1 : arr[x] == n ? 0 : 1;
    }
}