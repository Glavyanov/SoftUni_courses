using System;

namespace _10TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintNumberDivisibleByEightAndHoldOneOdd(input);
        }

        private static void PrintNumberDivisibleByEightAndHoldOneOdd(int num)
        {
            for (int i = 16; i <= num; i++)
            {
                int currentDigit = 0;
                int sum = 0;
                int number = i;
                bool flag = false;
                while (number != 0)
                {
                    currentDigit = number % 10;
                    sum += currentDigit;
                    number = number / 10;
                    if (currentDigit % 2 != 0)
                    {
                        flag = true;
                    }
                }

                if (sum % 8 == 0 && flag)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
