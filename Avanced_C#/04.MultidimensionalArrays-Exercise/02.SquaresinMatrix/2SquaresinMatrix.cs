using System;
using System.Linq;

namespace _02.SquaresinMatrix
{
    class SquaresinMatrix
    {
        static void Main(string[] args)
        {
            int[] matSize = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            char[,] matrix = new char[matSize[0], matSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] assign = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(char.Parse)
                                   .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = assign[col];
                }

            }
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char current = matrix[row, col];
                    bool isEqualSquare = current == matrix[row, col + 1] && current == matrix[row + 1, col] &&
                        current == matrix[row + 1, col + 1];
                    if (isEqualSquare)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
