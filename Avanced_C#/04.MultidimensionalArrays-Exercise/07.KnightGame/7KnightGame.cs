using System;

namespace _07.KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];


            for (int row = 0; row < n; row++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int counterAttack = -1;
            int counterRemoved = 0;
            int counterMaxAttack = 0;
            int rowMaxAttack = -1;
            int colMaxAttack = -1;

            while (counterAttack != 0)
            {
                counterAttack = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int currentAttack = 0;
                        char current = matrix[row, col];
                        if (current == 'K')
                        {
                            
                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                            
                            if (row - 2 >= 0 && col + 1 < n)
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                           
                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                            
                            if (row - 1 >= 0 && col + 2 < n)
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                            
                            if (row + 1 < n && col - 2 >= 0)
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                            
                            if (row + 1 < n && col + 2 < n)
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                            
                            if (row + 2 < n && col - 1 >= 0)
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                           
                            if (row + 2 < n && col + 1 < n)
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    counterAttack++;
                                    currentAttack++;
                                }
                            }
                            
                        }
                        else
                        {
                            continue;
                        }
                        if (currentAttack > counterMaxAttack)
                        {
                            counterMaxAttack = currentAttack;
                            rowMaxAttack = row;
                            colMaxAttack = col;
                        }

                    }
                }
                if (rowMaxAttack >= 0)
                {
                    matrix[rowMaxAttack, colMaxAttack] = '0';
                    counterRemoved++;
                    counterMaxAttack = 0;
                    rowMaxAttack = -1;
                    colMaxAttack = -1;
                }

            }
            Console.WriteLine(counterRemoved);
            
        }
    }
}
