using System;
using System.Linq;

namespace _05TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();
            int big = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (count = i + 1; count < arr.Length; count++)
                {
                    if (arr[i] > arr[count])
                    {
                        big = arr[i];
                    }
                    else
                    {
                        big = 0;
                        break;
                    }
                }
                if (big != 0 && count < arr.Length)
                {
                    Console.Write("{0} ", big);
                }
                else if (count >= arr.Length)
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
        }                                 
    }
}
