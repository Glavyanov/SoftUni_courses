using System;

namespace _02.TheBattleofTheFiveArmies
{
    class TheBattleofTheFiveArmies
    {
        static void Main(string[] args)
        {
            
            int armor = int.Parse(Console.ReadLine());
            int numRows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[numRows][];
            int currentRow = -1;
            int currentCol = -1;
            int currentArmor = armor;
            for (int i = 0; i < numRows; i++)
            {
                char[] rowAssign = Console.ReadLine().ToCharArray();
                matrix[i] = rowAssign;
                for (int j = 0; j < rowAssign.Length; j++)
                {
                    if (rowAssign[j] == 'A')
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                }
                
            }
            if (IsDead(currentArmor))
            {
                matrix[currentRow][currentCol] = 'X';
                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                PrintMatrix(matrix);
                return;
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0].ToLower();
                int enemyRow = int.Parse(cmdArgs[1]);
                int enemyCol = int.Parse(cmdArgs[2]);
                matrix[enemyRow][enemyCol] = 'O';
                if (action == "up")
                {
                    currentRow--;
                    if (OutFromField(matrix, currentRow, currentCol))
                    {
                        currentRow++;
                        currentArmor--;
                        if (IsDead(currentArmor))
                        {
                            matrix[currentRow][currentCol] = 'X';
                            Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else
                    {
                        if (matrix[currentRow][currentCol] == '-')
                        {
                            currentArmor--;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow + 1][currentCol] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[currentRow][currentCol] = 'A';
                            matrix[currentRow + 1][currentCol] = '-';

                        }
                        else if (matrix[currentRow][currentCol] == 'M')
                        {
                            currentArmor--;
                            matrix[currentRow][currentCol] = '-';
                            matrix[currentRow + 1][currentCol] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {currentArmor}");
                            PrintMatrix(matrix);
                            return;

                        }
                        else if (matrix[currentRow][currentCol] == 'O')
                        {
                            
                            currentArmor -= 3;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow + 1][currentCol] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;

                            }
                            else
                            {
                                matrix[currentRow][currentCol] = 'A';
                                matrix[currentRow + 1][currentCol] = '-';

                            }
                        }

                    }

                }
                else if (action == "down")
                {
                    currentRow++;
                    if (OutFromField(matrix, currentRow, currentCol))
                    {
                        currentRow--;
                        currentArmor--;
                        if (IsDead(currentArmor))
                        {
                            matrix[currentRow][currentCol] = 'X';
                            Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                            PrintMatrix(matrix);
                            return;
                        }

                    }
                    else
                    {
                        if (matrix[currentRow][currentCol] == '-')
                        {
                            currentArmor--;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow - 1][currentCol] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[currentRow][currentCol] = 'A';
                            matrix[currentRow - 1][currentCol] = '-';

                        }
                        else if (matrix[currentRow][currentCol] == 'M')
                        {
                            currentArmor--;
                            matrix[currentRow][currentCol] = '-';
                            matrix[currentRow - 1][currentCol] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {currentArmor}");
                            PrintMatrix(matrix);
                            return;
                        }
                        else if (matrix[currentRow][currentCol] == 'O')
                        {
                            currentArmor -= 3;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow - 1][currentCol] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;

                            }
                            else
                            {
                                matrix[currentRow][currentCol] = 'A';
                                matrix[currentRow - 1][currentCol] = '-';

                            }
                        }
                    }

                }
                else if (action == "left")
                {
                    currentCol--;
                    if (OutFromField(matrix, currentRow, currentCol))
                    {
                        currentCol++;
                        currentArmor--;
                        if (IsDead(currentArmor))
                        {
                            matrix[currentRow][currentCol] = 'X';
                            Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                            PrintMatrix(matrix);
                            return;
                        }

                    }
                    else
                    {
                        if (matrix[currentRow][currentCol] == '-')
                        {
                            currentArmor--;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow][currentCol + 1] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[currentRow][currentCol] = 'A';
                            matrix[currentRow][currentCol + 1] = '-';

                        }
                        else if (matrix[currentRow][currentCol] == 'M')
                        {
                            currentArmor--;
                            matrix[currentRow][currentCol] = '-';
                            matrix[currentRow][currentCol + 1] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {currentArmor}");
                            PrintMatrix(matrix);
                            return;

                        }
                        else if (matrix[currentRow][currentCol] == 'O')
                        {
                            currentArmor -= 3;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow][currentCol + 1] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;

                            }
                            else
                            {
                                matrix[currentRow][currentCol] = 'A';
                                matrix[currentRow][currentCol + 1] = '-';

                            }

                        }
                    }

                }
                else if (action == "right")
                {
                    currentCol++;
                    if (OutFromField(matrix, currentRow, currentCol))
                    {
                        currentCol--;
                        currentArmor--;
                        if (IsDead(currentArmor))
                        {
                            matrix[currentRow][currentCol] = 'X';
                            Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                            PrintMatrix(matrix);
                            return;
                        }

                    }
                    else
                    {
                        if (matrix[currentRow][currentCol] == '-')
                        {
                            currentArmor--;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow][currentCol - 1] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;
                            }
                            matrix[currentRow][currentCol] = 'A';
                            matrix[currentRow][currentCol - 1] = '-';

                        }
                        else if (matrix[currentRow][currentCol] == 'M')
                        {
                            currentArmor--;
                            matrix[currentRow][currentCol] = '-';
                            matrix[currentRow][currentCol - 1] = '-';
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {currentArmor}");
                            PrintMatrix(matrix);
                            return;
                        }
                        else if (matrix[currentRow][currentCol] == 'O')
                        {
                            currentArmor -= 3;
                            if (IsDead(currentArmor))
                            {
                                matrix[currentRow][currentCol] = 'X';
                                matrix[currentRow][currentCol - 1] = '-';
                                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
                                PrintMatrix(matrix);
                                return;

                            }
                            else
                            {
                                matrix[currentRow][currentCol] = 'A';
                                matrix[currentRow][currentCol - 1] = '-';

                            }

                        }
                    }

                }

            }

        }

        static bool OutFromField(char[][] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix[row].Length)
            {
                return true;
            }

            return false;
        }

        static bool IsDead(int currArmor)
        {
            if (currArmor <= 0)
            {
                return true;
            }
            return false;
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
