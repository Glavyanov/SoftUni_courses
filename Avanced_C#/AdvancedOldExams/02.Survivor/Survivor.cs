using System;
using System.Linq;

namespace _02.Survivor
{
    class Survivor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] map = new char[n][];
            for (int i = 0; i < n; i++)
            {
                char[] tokensAssign = Console.ReadLine()
                                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(char.Parse)
                                             .ToArray();
                map[i] = tokensAssign;
            }
            int collectedTokens = 0;
            int opponentTokens = 0;
            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                if (action == "Find")
                {
                    
                    if (ValidCoordinates(map, row, col))
                    {
                        collectedTokens = Find(map, row, col, collectedTokens);
                    }
                }
                else if (action == "Opponent")
                {
                    if (ValidCoordinates(map, row, col))
                    {
                        opponentTokens = Find(map, row, col, opponentTokens);
                        string movement = cmdArgs[3];
                        opponentTokens = Move(movement, map, row, col, opponentTokens);
                    }

                }

            }

            foreach (var item in map)
            {
                Console.WriteLine(string.Join(' ', item));
            }
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");

        }

        public static bool ValidCoordinates(char[][] map, int row, int col )
        {
            if (row < 0 || row >= map.GetLength(0) || col < 0 || col >= map[row].Length)
            {
                return false;
            }

            return true;
        }

        public static int Find(char[][] map, int row, int col, int numTokens)
        {
            if (map[row][col] == 'T')
            {
                map[row][col] = '-';
                return ++numTokens;
            }
            return numTokens;
        }

        public static int Move(string movement, char[][] map, int row, int col, int tokens)
        {
            int currRow = row;
            int currCol = col;
            if (movement == "up")
            {
                currRow--;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currRow--;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currRow--;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }

            }
            else if (movement == "down")
            {
                currRow++;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currRow++;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currRow++;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
            }
            else if (movement == "left")
            {
                currCol--;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currCol--;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currCol--;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
            }
            else if (movement == "right")
            {
                currCol++;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currCol++;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
                currCol++;
                if (ValidCoordinates(map, currRow, currCol))
                {
                    tokens = Find(map, currRow, currCol, tokens);
                }
            }
            return tokens;
        }
    }
}
