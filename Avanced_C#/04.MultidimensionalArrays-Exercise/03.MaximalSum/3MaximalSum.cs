using System;
using System.Linq;

namespace _03.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] matSize = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            int[,] matrix = new int[matSize[0], matSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] assign = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = assign[col];
                }

            }
            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;
                    currentSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                  matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                  matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            if (maxRow > -1)
            {
                for (int i = maxRow; i < maxRow + 3; i++)
                {
                    for (int j = maxCol; j < maxCol + 3; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
