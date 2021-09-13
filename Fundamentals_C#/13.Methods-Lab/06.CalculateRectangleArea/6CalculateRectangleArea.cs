using System;

namespace _06CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            double h = int.Parse(Console.ReadLine());
            double a = int.Parse(Console.ReadLine());
            double area = Rectangle(h, a);
            Console.WriteLine(area);
        }

        static double Rectangle(double height, double width)
        {
            return height * width;
        }
    }
}
