using System;

namespace _02HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNum = int.MinValue;
            int sumWithoutMax = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > maxNum)
                {
                    maxNum = num;
                }
                sum += num;
                sumWithoutMax = sum - maxNum;

            }
            if (sumWithoutMax == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");

            }
            else
            {
                int diff = Math.Abs(maxNum - sumWithoutMax);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
