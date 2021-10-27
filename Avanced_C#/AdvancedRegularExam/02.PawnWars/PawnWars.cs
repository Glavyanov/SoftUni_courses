using System;

namespace _02.PawnWars
{
    class PawnWars
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int blackRow = -1;
            int blackCol = -1;
            int whiteRow = -1;
            int whiteCol = -1;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                char[] assignRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = assignRow[j];
                    if (board[i, j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }
                    if (board[i, j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }
                }
            }
            bool whitePromoted = false;
            bool whiteCapture = false;
            bool blackPromoted = false;
            bool blackCapture = false;
            while (true)
            {
                board[whiteRow, whiteCol] = '-';
                if (whiteCol - 1 >= 0)                //catchLeft
                {
                    if (board[whiteRow - 1, whiteCol - 1] == 'b')
                    {
                        whiteRow--;
                        whiteCol--;
                        whiteCapture = true;
                        break;
                    }

                }
                if (whiteCol + 1 < board.GetLength(1)) // catchRight
                {
                    if (board[whiteRow - 1, whiteCol + 1] == 'b')
                    {
                        whiteRow--;
                        whiteCol++;
                        whiteCapture = true;
                        break;
                    }
                }
                whiteRow--;
                if (whiteRow == 0)
                {
                    whitePromoted = true;
                    break;
                }

                board[whiteRow, whiteCol] = 'w';
                board[blackRow, blackCol] = '-';
                if (blackCol - 1 >= 0)   // catchLeft
                {
                    if (board[blackRow + 1, blackCol - 1] == 'w')
                    {
                        blackRow++;
                        blackCol--;
                        blackCapture = true;
                        break;
                    }

                }
                if (blackCol + 1 < board.GetLength(1))                        // catchRight
                {
                    if (board[blackRow + 1, blackCol + 1] == 'w')
                    {
                        blackRow++;
                        blackCol++;
                        blackCapture = true;
                        break;
                    }
                }
                blackRow++;
                if (blackRow == board.GetLength(0) - 1)
                {
                    blackPromoted = true;
                    break;
                }
               
                board[blackRow, blackCol] = 'b';
            }

            if (whitePromoted)
            {
                char row = '8';
                char col = '\0';
                if (whiteCol == 0)
                {
                    col = 'a';
                }
                else if (whiteCol == 1)
                {
                    col = 'b';

                }
                else if (whiteCol == 2)
                {
                    col = 'c';

                }
                else if (whiteCol == 3)
                {
                    col = 'd';

                }
                else if (whiteCol == 4)
                {
                    col = 'e';

                }
                else if (whiteCol == 5)
                {
                    col = 'f';

                }
                else if (whiteCol == 6)
                {
                    col = 'g';

                }
                else if (whiteCol == 7)
                {
                    col = 'h';

                }
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {col}{row}.");
            }
            if (blackPromoted)
            {
                char row = '1';
                char col = '\0';
                if (blackCol == 0)
                {
                    col = 'a';
                }
                else if (blackCol == 1)
                {
                    col = 'b';
                }
                else if (blackCol == 2)
                {
                    col = 'c';
                }
                else if (blackCol == 3)
                {
                    col = 'd';
                }
                else if (blackCol == 4)
                {
                    col = 'e';
                }
                else if (blackCol == 5)
                {
                    col = 'f';
                }
                else if (blackCol == 6)
                {
                    col = 'g';
                }
                else if (blackCol == 7)
                {
                    col = 'h';
                }
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {col}{row}.");
            }
            if (whiteCapture)
            {
                char row = '\0';
                char col = '\0';
                if (whiteRow == 7)
                {
                    row = '1';
                }
                else if (whiteRow == 6)
                {
                    row = '2';
                }
                else if (whiteRow == 5)
                {
                    row = '3';
                }
                else if (whiteRow == 4)
                {
                    row = '4';
                }
                else if (whiteRow == 3)
                {
                    row = '5';
                }
                else if (whiteRow == 2)
                {
                    row = '6';
                }
                else if (whiteRow == 1)
                {
                    row = '7';
                }
                else if (whiteRow == 0)
                {
                    row = '8';
                }

                if (whiteCol == 0)
                {
                    col = 'a';
                }
                else if (whiteCol == 1)
                {
                    col = 'b';

                }
                else if (whiteCol == 2)
                {
                    col = 'c';

                }
                else if (whiteCol == 3)
                {
                    col = 'd';

                }
                else if (whiteCol == 4)
                {
                    col = 'e';

                }
                else if (whiteCol == 5)
                {
                    col = 'f';

                }
                else if (whiteCol == 6)
                {
                    col = 'g';

                }
                else if (whiteCol == 7)
                {
                    col = 'h';

                }
                Console.WriteLine($"Game over! White capture on {col}{row}.");
            }
            if (blackCapture)
            {
                char row = '\0';
                char col = '\0';
                if (blackRow == 7)
                {
                    row = '1';
                }
                else if (blackRow == 6)
                {
                    row = '2';
                }
                else if (blackRow == 5)
                {
                    row = '3';
                }
                else if (blackRow == 4)
                {
                    row = '4';
                }
                else if (blackRow == 3)
                {
                    row = '5';
                }
                else if (blackRow == 2)
                {
                    row = '6';
                }
                else if (blackRow == 1)
                {
                    row = '7';
                }
                else if (blackRow == 0)
                {
                    row = '8';
                }

                if (blackCol == 0)
                {
                    col = 'a';
                }
                else if (blackCol == 1)
                {
                    col = 'b';

                }
                else if (blackCol == 2)
                {
                    col = 'c';

                }
                else if (blackCol == 3)
                {
                    col = 'd';

                }
                else if (blackCol == 4)
                {
                    col = 'e';

                }
                else if (blackCol == 5)
                {
                    col = 'f';

                }
                else if (blackCol == 6)
                {
                    col = 'g';

                }
                else if (blackCol == 7)
                {
                    col = 'h';

                }
                Console.WriteLine($"Game over! Black capture on {col}{row}.");
            }
        }
        
    }
}
