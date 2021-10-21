using System;
using System.Linq;

namespace _02.Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] garden = new int[dimension[0]][];
            for (int i = 0; i < dimension[0]; i++)
            {
                int[] row = new int[dimension[1]].Select(p => 0).ToArray();
                garden[i] = row;

            }
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = cmdArgs[0];
                int col = cmdArgs[1];
                if (InvalidCoordinates(garden, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                
                for (int i = 0; i < dimension[1]; i++) // Bloom row
                {
                    if (garden[row][i] != 0)
                    {
                        garden[row][i]++;
                    }
                    else
                    {
                        garden[row][i] = 1;
                    }

                }
                for (int i = 0; i < dimension[0]; i++)                // Bloom col
                {
                    if (garden[i][col] != 0)
                    {
                        garden[i][col]++;
                    }
                    else
                    {
                        garden[i][col] = 1;
                    }
                }
                garden[row][col] = 1;

            }

            PrintMatrix(garden);

        }
        public static bool InvalidCoordinates(int[][] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix[row].Length)
            {
                return true;
            }

            return false;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(' ', matrix[i]));
            }
        }
    }
}
