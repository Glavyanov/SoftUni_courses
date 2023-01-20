using System;
using System.Collections.Generic;

namespace _06._8QueensPuzzle
{
    public class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiag = new HashSet<int>();
        private static HashSet<int> attackedRightDiag = new HashSet<int>();

        static void Main(string[] args)
        {
            bool[,] board = new bool[8, 8];

            PutQueen(board, 0);
        }

        private static void PutQueen(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {

                if (!Occupated(row,col))
                {

                    board[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiag.Add(row - col);
                    attackedRightDiag.Add(row + col);

                    PutQueen(board, row + 1);

                    board[row, col] = false;
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiag.Remove(row - col);
                    attackedRightDiag.Remove(row + col);
                }
            }
        }

        private static bool Occupated(int row, int col)
        {
            return attackedRows.Contains(row) ||
                attackedCols.Contains(col) ||
                attackedLeftDiag.Contains(row - col) ||
                attackedRightDiag.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
