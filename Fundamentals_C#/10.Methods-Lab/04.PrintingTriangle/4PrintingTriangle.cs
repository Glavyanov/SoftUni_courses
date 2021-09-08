﻿using System;

namespace _04PrintingTriangle
{
    class PrintingTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintLine(1, i);
            }
            for (int i = n -1; i >= 1; i--)
            {
                PrintLine(1, i);
            }

        }
        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

        }
    }
}
