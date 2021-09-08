using System;

namespace _11MathOperations
{
    class MathOperations
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            double calculator = Calculator(num1, @operator, num2);
            Console.WriteLine(calculator);

        }

        private static double Calculator(int one, string @operator, int two)
        {
            double result = 0d;
            if (@operator == "/")
            {
                result = one * 1.0 / (two * 1.0);
                result = Math.Round(result, 2);
            }
            else if (@operator == "*")
            {
                result = one * two;
            }
            else if (@operator == "+")
            {
                result = one + two;
            }
            else if (@operator == "-")
            {
                result = one - two;
            }

            return result;
        }
    }
}
