using System;

namespace _04Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pOne = 0;
            int pTwo = 0;
            int pThree = 0;
            int pFour = 0;
            int pFive = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    pOne++;

                }
                else if (num < 400)
                {
                    pTwo++;
                }
                else if (num < 600)
                {
                    pThree++;
                }
                else if (num < 800)
                {
                    pFour++;
                }
                else
                {
                    pFive++;
                }
            }
            double perOne = 1.0 * pOne / n * 100;
            Console.WriteLine($"{perOne:f2}%");
            double perTwo = 1.0 * pTwo / n * 100;
            Console.WriteLine($"{perTwo:f2}%");
            double perThree = 1.0 * pThree / n * 100;
            Console.WriteLine($"{perThree:f2}%");
            double perFour = 1.0 * pFour / n * 100;
            Console.WriteLine($"{perFour:f2}%");
            double perFive = 1.0 * pFive / n * 100;
            Console.WriteLine($"{perFive:f2}%");
            // Console.WriteLine($"{(((double)pOne)/n*100):f2}%");

        }
    }
}
