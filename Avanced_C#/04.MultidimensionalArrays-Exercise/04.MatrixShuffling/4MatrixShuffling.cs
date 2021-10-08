using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] matSize = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            string[,] matrix = new string[matSize[0], matSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] assign = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = assign[col];
                }
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                if (command[0] != "swap" || command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                else
                {
                    int currentRow = int.Parse(command[1]);
                    int currentCol = int.Parse(command[2]);
                    int swapRow = int.Parse(command[3]);
                    int swapCol = int.Parse(command[4]);
                    bool isValidCoordinates = currentRow >= 0 && currentRow < matrix.GetLength(0) && currentCol >= 0 && currentCol < matrix.GetLength(1) && swapRow >= 0 && swapRow < matrix.GetLength(0) && swapCol >= 0 &&
                        swapCol < matrix.GetLength(1);
                    if (isValidCoordinates)
                    {
                        string temp = matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = matrix[swapRow, swapCol];
                        matrix[swapRow, swapCol] = temp;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
