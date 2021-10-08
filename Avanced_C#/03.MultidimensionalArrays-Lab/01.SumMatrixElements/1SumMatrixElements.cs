using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            int[] matSize = Console.ReadLine()
                                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            int[,] matrix = new int[matSize[0], matSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] initial = Console.ReadLine()
                                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = initial[col];
                
            }
            Console.WriteLine(matSize[0]);
            Console.WriteLine(matSize[1]);
            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
    }
}
