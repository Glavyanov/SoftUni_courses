using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class JaggedArrayModificationam
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagArr = new int[n][];
            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
                jagArr[row] = currentRow;

            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);
                if ( row < 0 || row >= n || col < 0 || col >= jagArr[row].Length )
                {
                    Console.WriteLine("Invalid coordinates");

                }
                else
                {
                    if (cmdArgs[0] == "Add")
                    {
                        jagArr[row][col] += value;

                    }
                    else if (cmdArgs[0] == "Subtract")
                    {
                        jagArr[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }
            for (int i = 0; i < jagArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagArr[i]));

            }
        }
    }
}
