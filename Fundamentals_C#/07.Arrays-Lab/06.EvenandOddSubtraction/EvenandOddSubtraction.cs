using System;
using System.Linq;

namespace _06EvenandOddSubtraction
{
    class EvenandOddSubtraction
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int evenSum = 0;
            int oddSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                if (num %2==0)
                {
                    evenSum += num;
                }
                else
                {
                    oddSum += num;       
                }

            }
            Console.WriteLine(evenSum -oddSum);
        }
    }
}
