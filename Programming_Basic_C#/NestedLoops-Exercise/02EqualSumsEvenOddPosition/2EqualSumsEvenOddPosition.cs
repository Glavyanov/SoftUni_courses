using System;

namespace _02EqualSumsEvenOddPosition
{
    class EqualSumsEvenOddPosition
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            for (int i = num1; i <= num2; i++)
            {
                int evenSum = 0;
                int oddSum = 0;
                int counter = 0;
                int convert = i;
                while (convert != 0)
                {
                    int number = convert % 10;
                    if (counter % 2 == 0)
                    {
                        evenSum += number;
                    }
                    else
                    {
                        oddSum += number;
                    }
                    counter++;
                    convert = convert / 10;
                }
                if (evenSum == oddSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
