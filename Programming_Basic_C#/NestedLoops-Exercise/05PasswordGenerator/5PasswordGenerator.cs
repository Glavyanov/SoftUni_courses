using System;

namespace _05PasswordGenerator
{
    class PasswordGenerator
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i < start; i++)
            {
                count++;
                for (int j = 1; j < start; j++)
                {
                    for (int k = 97; k < 97 + end; k++)
                    {
                        for (int l = 97; l < 97 + end; l++)
                        {
                            for (int m = 1 + i; m <= start; m++)
                            {
                                if (m > i && m > j)
                                {
                                    Console.Write($"{i}{j}{(char)k}{(char)l}{m} ");
                                }

                            }

                        }

                    }

                }
            }
        }
    }
}
