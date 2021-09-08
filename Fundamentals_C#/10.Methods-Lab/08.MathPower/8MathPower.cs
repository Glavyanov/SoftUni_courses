using System;

namespace _08MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = NumOnPower(num, power);
            Console.WriteLine(result);
        }

        static double NumOnPower(double number, double powered)
        {
            double result = 1D;
            for (int i = 1; i <= powered; i++)
            {
                result *= number;

            }
            return result;
        }
    }
}
