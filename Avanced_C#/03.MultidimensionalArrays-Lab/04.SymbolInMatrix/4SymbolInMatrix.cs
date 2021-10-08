using System;

namespace _04.SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] @chars = new char[n, n];
            for (int row  = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    @chars[row, col] = input[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool isFind = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char current = @chars[i, j];
                    if (symbol == current)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isFind = true;
                        break;
                    }

                }
                if (isFind)
                {
                    break;
                }
            }
            if (!isFind)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
