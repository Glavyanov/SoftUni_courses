using System;

namespace _01SignofIntegerNumbers
{
    class SignofIntegerNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            SignOfNumbers(num);
        }

        private static void SignOfNumbers(int number)
        {
            if (number > 0)
            {
                Console.WriteLine("The number {0} is positive.", number);
            }
            else if (number < 0)
            {
                Console.WriteLine("The number {0} is negative.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is zero.", number);
            }
        }
    }
}
