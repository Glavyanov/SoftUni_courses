using System;

namespace _10MultiplyEvensbyOdds
{
    class MultiplyEvensbyOdds
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }
        static int GetMultipleOfEvenAndOdds(int num)
        {
            int result = 0;
            result = GetSumOfEvenDigits(num)* GetSumOfOddDigits(num);
            return result;

        }
        static int GetSumOfEvenDigits(int numEven)
        {
            int result = 0;
            while (numEven !=0)
            {
                int current = numEven % 10;
                if (current % 2==0)
                {
                    result += current;
                }
                numEven /= 10;

            }

            return result;
        }
        static int GetSumOfOddDigits(int numOdd)
        {
            int result = 0;
            while (numOdd != 0)
            {
                int current = numOdd % 10;
                if (current % 2 == 1)
                {
                    result += current;
                }
                numOdd /= 10;

            }

            return result;
        }
    }
}
