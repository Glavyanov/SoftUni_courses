using System;

namespace _07.RecursiveFibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        private static int GetFibonacci(int n)
        {
            if (n is 0)
            {
                return 1;
            }

            if (n is 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
