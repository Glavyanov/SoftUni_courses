using System;

namespace _02.RecursiveDrawing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            RecursiveDrawing(n);
        }

        private static void RecursiveDrawing(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            RecursiveDrawing(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
