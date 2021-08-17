using System;

namespace InchCentimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double Inch = double.Parse(Console.ReadLine());
            double Centimeter = Inch * 2.54;
            Console.WriteLine(Centimeter);
        }
    }
}
