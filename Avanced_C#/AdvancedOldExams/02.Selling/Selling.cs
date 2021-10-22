using System;

namespace _02.Selling
{
    class Selling
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] bakery = new char[n, n];
            int rowPillarOne = -1;
            int colPillarOne = -1;
            int rowPillarTwo = -1;
            int colPillarTwo = -1;
            int rowOwner = -1;
            int colOwner = -1;
            bool pillarOne = true;
            for (int i = 0; i < n; i++)
            {
                char[] rowAssign = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    bakery[i, j] = rowAssign[j];
                    if (bakery[i, j] == 'S')
                    {
                        rowOwner = i;
                        colOwner = j;
                    }
                    else if (bakery[i, j] == 'O' && pillarOne)
                    {
                        rowPillarOne = i;
                        colPillarOne = j;
                        pillarOne = false;
                    }
                    else if (bakery[i, j] == 'O' && !pillarOne)
                    {
                        rowPillarTwo = i;
                        colPillarTwo = j;
                    }
                }
            }
            int money = 0;
            bool outFromBakery = false;
            while (money < 50 && !outFromBakery)
            {
                string command = Console.ReadLine().ToLower();

                bakery[rowOwner, colOwner] = '-';
                if (command == "right" && colOwner + 1 < n)
                {
                    colOwner++;
                    if (bakery[rowOwner, colOwner] == '-')
                    {
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else if (bakery[rowOwner, colOwner] == 'O')
                    {
                        bakery[rowOwner, colOwner] = '-';
                        rowOwner = rowPillarTwo;
                        colOwner = colPillarTwo;
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else
                    {
                        money += int.Parse(bakery[rowOwner, colOwner].ToString());
                        bakery[rowOwner, colOwner] = 'S';
                    }

                }
                else if (command == "left" && colOwner - 1 >= 0)
                {
                    colOwner--;
                    if (bakery[rowOwner, colOwner] == '-')
                    {
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else if (bakery[rowOwner, colOwner] == 'O')
                    {
                        bakery[rowOwner, colOwner] = '-';
                        rowOwner = rowPillarTwo;
                        colOwner = colPillarTwo;
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else
                    {
                        money += int.Parse(bakery[rowOwner, colOwner].ToString());
                        bakery[rowOwner, colOwner] = 'S';
                    }
                }
                else if (command == "up" && rowOwner - 1 >= 0)
                {
                    rowOwner--;
                    if (bakery[rowOwner, colOwner] == '-')
                    {
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else if (bakery[rowOwner, colOwner] == 'O')
                    {
                        bakery[rowOwner, colOwner] = '-';
                        rowOwner = rowPillarTwo;
                        colOwner = colPillarTwo;
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else
                    {
                        money += int.Parse(bakery[rowOwner, colOwner].ToString());
                        bakery[rowOwner, colOwner] = 'S';
                    }
                }
                else if (command == "down" && rowOwner + 1 < n)
                {
                    rowOwner++;
                    if (bakery[rowOwner, colOwner] == '-')
                    {
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else if (bakery[rowOwner, colOwner] == 'O')
                    {
                        bakery[rowOwner, colOwner] = '-';
                        rowOwner = rowPillarTwo;
                        colOwner = colPillarTwo;
                        bakery[rowOwner, colOwner] = 'S';
                    }
                    else
                    {
                        money += int.Parse(bakery[rowOwner, colOwner].ToString());
                        bakery[rowOwner, colOwner] = 'S';
                    }

                }
                else
                {
                    outFromBakery = true;
                }

            }
            if (outFromBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");
            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    Console.Write(bakery[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
