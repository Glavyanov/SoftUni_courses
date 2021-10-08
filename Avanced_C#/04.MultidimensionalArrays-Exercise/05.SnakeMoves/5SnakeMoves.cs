using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
           
            int[] matSize = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            char[,] matrix = new char[matSize[0], matSize[1]];
            string snake = Console.ReadLine();
            int currentRow = 0;
            int counter = 0;
            while (currentRow != matSize[0])
            {
                if (currentRow % 2 == 0)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[currentRow, col] = snake[counter];
                        counter++;
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }
                    }

                }
                else if (currentRow % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[currentRow, col] = snake[counter];
                        counter++;
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }
                    }

                }
                currentRow++;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
