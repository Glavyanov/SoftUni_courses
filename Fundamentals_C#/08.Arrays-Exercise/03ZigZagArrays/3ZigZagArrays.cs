using System;

namespace _03ZigZagArrays
{
    class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] resultOne = new string[n];
            string[] resultTwo = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (i % 2 == 0)
                {

                    for (int j = 0; j < arr.Length; j++)
                    {
                        string current = arr[j];
                        if (j % 2 == 0)
                        {
                            resultOne[i] = current;
                        }
                        else if (j % 2 == 1)
                        {
                            resultTwo[i] = current;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        string current = arr[j];
                        if (j % 2 == 0)
                        {
                            resultTwo[i] = current;
                        }
                        else if (j % 2 == 1)
                        {
                            resultOne[i] = current;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", resultOne));
            Console.WriteLine(string.Join(" ", resultTwo));
        }
    }
}
