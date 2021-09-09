using System;

namespace _08FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double result1 = GetFactorialFromInteger(num1);
            double result2 = GetFactorialFromInteger(num2);
            double division = result1 / result2;
            Console.WriteLine($"{division:f2}");
        }

        private static double GetFactorialFromInteger(int num)
        {
            double result = 1;
            if (num == 0)
            {
                return result;
            }
            for (int i = num; i > 1 ;i-- )
            {
                result = result * i;

            }


            return result;
        }
    }
}
