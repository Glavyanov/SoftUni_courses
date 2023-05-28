using System;
using System.Collections.Generic;

namespace _05.PathsInLabyrinth
{
    public class Program
    {

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            var lab = new char[row, col];

            FillLab(row, col, lab);

            PrintPaths(lab, new List<string>());
        }

        private static void PrintPaths(char[,] lab, List<string> paths, int row = 0, int col = 0, string direction = "")
        {
            if (IsInvalidPath(row, col, lab)) return;

            if (lab[row, col] is '*' || lab[row, col] is 'v') return;

            paths.Add(direction);

            if (lab[row, col] is 'e')
            {
                Console.WriteLine(string.Join(string.Empty, paths));
                paths.RemoveAt(paths.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            PrintPaths(lab, paths, row, col + 1, "R");
            PrintPaths(lab, paths, row + 1, col, "D");
            PrintPaths(lab, paths, row, col - 1, "L");
            PrintPaths(lab, paths, row - 1, col, "U");

            paths.RemoveAt(paths.Count - 1);

            if (lab[row, col] is 'v')
            {
                lab[row, col] = '-';
            }

        }

        private static bool IsInvalidPath(int row, int col, char[,] lab)
        {
            return row < 0 || row >= lab.GetLength(0) ||
                   col < 0 || col >= lab.GetLength(1);
        }

        private static void FillLab(int row, int col, char[,] lab)
        {
            for (int i = 0; i < row; i++)
            {
                string c = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    lab[i, j] = c[j];
                }
            }
        }
    }
}
