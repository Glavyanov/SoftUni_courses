using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double side = 0;
                side = double.Parse(Console.ReadLine());
                double result = side * side;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "rectangle")
            {
                double sideA = 0;
                double sideB = 0;
                sideA = double.Parse(Console.ReadLine());
                sideB = double.Parse(Console.ReadLine());
                double result = sideA * sideB;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "circle")
            {
                double sideC = 0;
                sideC = double.Parse(Console.ReadLine());
                double area = Math.PI * sideC * sideC;
                Console.WriteLine($"{area:f3}");

            }
            else if (figure == "triangle")
            {
                double sideD = 0;
                double sideE = 0;
                sideD = double.Parse(Console.ReadLine());
                sideE = double.Parse(Console.ReadLine());
                double area = sideD / 2 * sideE;
                Console.WriteLine($"{area:f3}");
            }
        }
    }
}
