using System;

namespace UsdToBgn
{
    class Program
    {
        static void Main(string[] args)
        {
            double Course = 1.79549;
            double Usd = double.Parse(Console.ReadLine());
            double Bgn = Usd * Course;
            Console.WriteLine($"{Bgn:f2}");

        }
    }
}
