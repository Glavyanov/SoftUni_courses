using System;

namespace _07.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];
            for (int i = 0; i < n; i++)
            {
                long[] current = new long[i + 1];
                current[0] = 1;
                current[current.Length - 1] = 1;
                pascalTriangle[i] = current;

            }
            for (int i = 2; i < pascalTriangle.Length; i++)
            {
                for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }
            }
            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ",pascalTriangle[i]));
            }
        }
    }
}
