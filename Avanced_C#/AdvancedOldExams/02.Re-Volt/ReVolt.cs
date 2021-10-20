using System;
using System.Linq;

namespace _02.Re_Volt
{
    class ReVolt
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommannd = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;
            for (int row = 0; row < n; row++)
            {
                char[] rowAssign = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowAssign.Length; col++)
                {
                    matrix[row, col] = rowAssign[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool playerWin = false;
            for (int i = 0; i < countCommannd; i++)
            {
                string movement = Console.ReadLine();
                Move(movement, matrix, ref playerRow, ref playerCol, ref playerWin);
                if (playerWin)
                {
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }

            }
            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        public static void Move(string movement, char[,] matrix , ref int row, ref int col, ref bool playerWin)
        {
            if (movement == "up")
            {
                if (IsValid(matrix, row - 1, col)) // validMovement
                {
                    if (matrix[row - 1, col] == 'F')// Win
                    {
                        matrix[--row, col] = 'f';
                        matrix[row + 1, col] = '-';
                        playerWin = true;
                    }
                    else if (matrix[row - 1, col] == '-') // '-'
                    {
                        matrix[--row, col] = 'f';
                        matrix[row + 1, col] = '-';
                    }
                    else if (matrix[row - 1, col] == 'B') // Bonus
                    {
                        if (IsValid(matrix, row - 2, col)) // validBonus
                        {
                            if (matrix[row - 2, col] == 'F')
                            {
                                row -= 2;
                                matrix[row, col] = 'f';
                                matrix[row + 2, col] = '-';
                                playerWin = true;
                            }
                            else if (matrix[row - 2, col] == '-')
                            {
                                row -= 2;
                                matrix[row, col] = 'f';
                                matrix[row + 2, col] = '-';
                            }
                        }
                        else                                   // invalidBonus
                        {
                            matrix[row, col] = '-';
                            row = matrix.GetLength(0) - 1;
                            if (matrix[row, col] == 'F')
                            {
                                matrix[row, col] = 'f';
                                playerWin = true;
                            }
                            else if (matrix[row, col] == '-')
                            {
                                matrix[row, col] = 'f';
                            }
                        }
                    }
                }
                else                                           // invalidMovement
                {
                    matrix[row, col] = '-';
                    row = matrix.GetLength(0) - 1;
                    if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = 'f';
                        playerWin = true;
                    }
                    else if (matrix[row, col] == '-')
                    {
                        matrix[row, col] = 'f';
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        row--;
                        if (matrix[row, col] == 'F')
                        {
                            matrix[row, col] = 'f';
                            playerWin = true;
                        }
                        else if (matrix[row, col] == '-')
                        {
                            matrix[row, col] = 'f';
                        }

                    }
                }

            }
            else if (movement == "down")
            {
                if (IsValid(matrix, row + 1, col)) // validMovement
                {
                    if (matrix[row + 1, col] == 'F') // Win
                    {
                        matrix[++row, col] = 'f';
                        matrix[row - 1, col] = '-';
                        playerWin = true;

                    }
                    else if (matrix[row + 1, col] == '-') // '-'
                    {
                        matrix[++row, col] = 'f';
                        matrix[row - 1, col] = '-';
                    }
                    else if (matrix[row + 1, col] == 'B') // Bonus
                    {
                        if (IsValid(matrix, row + 2, col)) // validBonus
                        {
                            if (matrix[row + 2, col] == 'F')
                            {
                                row += 2;
                                matrix[row, col] = 'f';
                                matrix[row - 2, col] = '-';
                                playerWin = true;
                            }
                            else if (matrix[row + 2, col] == '-')
                            {
                                row += 2;
                                matrix[row, col] = 'f';
                                matrix[row - 2, col] = '-';
                            }
                        }
                        else                                   // invalidBonus
                        {
                            matrix[row, col] = '-';
                            row = 0;
                            if (matrix[row, col] == 'F')
                            {
                                matrix[row, col] = 'f';
                                playerWin = true;
                            }
                            else if (matrix[row, col] == '-')
                            {
                                matrix[row, col] = 'f';
                            }

                        }

                    }

                }
                else                                            // invalidMovement
                {
                    matrix[row, col] = '-';
                    row = 0;
                    if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = 'f';
                        playerWin = true;
                    }
                    else if (matrix[row, col] == '-')
                    {
                        matrix[row, col] = 'f';
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        row++;
                        if (matrix[row, col] == 'F')
                        {
                            matrix[row, col] = 'f';
                            playerWin = true;
                        }
                        else if (matrix[row, col] == '-')
                        {
                            matrix[row, col] = 'f';
                        }

                    }
                }

            }
            else if (movement == "left")
            {
                if (IsValid(matrix, row, col - 1)) // validMovement
                {
                    if (matrix[row, col - 1] == 'F') // Win
                    {
                        matrix[row, --col] = 'f';
                        matrix[row, col + 1] = '-';
                        playerWin = true;

                    }
                    else if (matrix[row, col - 1] == '-') // '-'
                    {
                        matrix[row, --col] = 'f';
                        matrix[row, col + 1] = '-';
                    }
                    else if (matrix[row, col - 1] == 'B')
                    {
                        if (IsValid(matrix, row, col - 2)) // validBonus
                        {
                            if (matrix[row, col - 2] == 'F')
                            {
                                col -= 2;
                                matrix[row, col] = 'f';
                                matrix[row, col + 2] = '-';
                                playerWin = true;
                            }
                            else if (matrix[row, col - 2] == '-')
                            {
                                col -= 2;
                                matrix[row, col] = 'f';
                                matrix[row, col + 2] = '-';
                            }
                        }
                        else                                   // invalidBonus
                        {
                            matrix[row, col] = '-';
                            col = matrix.GetLength(1) - 1;
                            if (matrix[row, col] == 'F')
                            {
                                matrix[row, col] = 'f';
                                playerWin = true;
                            }
                            else if (matrix[row, col] == '-')
                            {
                                matrix[row, col] = 'f';
                            }
                        }
                    }
                }
                else                                            // invalidMovement
                {
                    matrix[row, col] = '-';
                    col = matrix.GetLength(1) - 1;
                    if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = 'f';
                        playerWin = true;
                    }
                    else if (matrix[row, col] == '-')
                    {
                        matrix[row, col] = 'f';
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        col--;
                        if (matrix[row, col] == 'F')
                        {
                            matrix[row, col] = 'f';
                            playerWin = true;
                        }
                        else if (matrix[row, col] == '-')
                        {
                            matrix[row, col] = 'f';
                        }

                    }
                }

            }
            else if (movement == "right")
            {
                if (IsValid(matrix, row, col + 1)) // validMovement
                {
                    if (matrix[row, col + 1] == 'F') // Win
                    {
                        matrix[row, ++col] = 'f';
                        matrix[row, col - 1] = '-';
                        playerWin = true;

                    }
                    else if (matrix[row, col + 1] == '-') // '-'
                    {
                        matrix[row, ++col] = 'f';
                        matrix[row, col - 1] = '-';
                    }
                    else if (matrix[row, col + 1] == 'B')
                    {
                        if (IsValid(matrix, row, col + 2))
                        {
                            if (matrix[row, col + 2] == 'F')
                            {
                                col += 2;
                                matrix[row, col] = 'f';
                                matrix[row, col - 2] = '-';
                                playerWin = true;
                            }
                            else if (matrix[row, col + 2] == '-')
                            {
                                col += 2;
                                matrix[row, col] = 'f';
                                matrix[row, col - 2] = '-';
                            }
                        }
                        else
                        {
                            matrix[row, col] = '-';
                            col = 0;
                            if (matrix[row, col] == 'F')
                            {
                                matrix[row, col] = 'f';
                                playerWin = true;
                            }
                            else if (matrix[row, col] == '-')
                            {
                                matrix[row, col] = 'f';
                            }
                        }
                    }
                }
                else
                {
                    matrix[row, col] = '-';
                    col = 0;
                    if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = 'f';
                        playerWin = true;
                    }
                    else if (matrix[row, col] == '-')
                    {
                        matrix[row, col] = 'f';
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        col++;
                        if (matrix[row, col] == 'F')
                        {
                            matrix[row, col] = 'f';
                            playerWin = true;
                        }
                        else if (matrix[row, col] == '-')
                        {
                            matrix[row, col] = 'f';
                        }

                    }
                }
            }

        }

        public static bool IsValid(char[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static void PrintMatrix(char[,] matrix)
        {
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
