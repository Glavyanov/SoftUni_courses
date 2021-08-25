using System;

namespace _01NumberPyramid
{
    class NumberPyramid
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            bool flag = false;
            for (int row = 1; row <= n; row++)
            {
                for (int column = 1; column <= row; column++)
                {

                    Console.Write(num + " ");
                    num++;
                    if (num > n)
                    {
                        n = 0;
                        break;
                    }

                }
                Console.WriteLine();
            }
            
        }
    }
}
