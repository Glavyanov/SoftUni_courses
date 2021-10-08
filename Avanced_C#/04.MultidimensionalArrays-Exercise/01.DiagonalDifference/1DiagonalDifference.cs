using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int leftDiagonal = 0;
            int rightDiagonal = 0;
            int counter = n;
            for (int i = 0; i < n; i++)
            {
                leftDiagonal += matrix[i, i];
                rightDiagonal += matrix[i, --counter];
            }
            Console.WriteLine(Math.Abs(leftDiagonal - rightDiagonal));
        }
    }
}
