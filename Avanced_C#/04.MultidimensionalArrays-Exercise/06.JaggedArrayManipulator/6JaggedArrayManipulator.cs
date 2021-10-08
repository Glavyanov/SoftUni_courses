using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] assign = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(double.Parse)
                                      .ToArray();
                matrix[row] = assign;
            }
            for (int row = 0; row < n - 1; row ++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] *= 2;
                        matrix[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] /= 2;
                        
                    }
                    for (int i = 0; i < matrix[row + 1].Length; i++)
                    {
                        matrix[row + 1][i] /= 2;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);
                if (row < 0 || row >= n || col < 0 || col >= matrix[row].Length )
                {

                }
                else
                {
                    if (action == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }

                }

                command = Console.ReadLine();
            }
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ",matrix[row]));
            }
        }
    }
}
