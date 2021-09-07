using System;

namespace AnotherPascalTriangle
{
    class AnotherPascaLTriangle
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long number = 1;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{number} ");
                    number = number * (i - j) / (j + 1);
                }
                Console.WriteLine();

            }
        }
    }
}
