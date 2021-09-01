using System;

namespace _03ExactSumofRealNumbers
{
    class ExactSumofRealNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0M;
            for (int i = 0; i < n; i ++)
            {
                double number = double.Parse(Console.ReadLine());
                sum += (decimal)number;
            }
            Console.WriteLine(sum);
        }
    }
}
