using System;

namespace _03SumPrimeNonPrime
{
    class SumPrimeNonPrime
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;
            while (number != "stop")
            {
                int numberR = int.Parse(number);
                if (numberR < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    int count = 0;
                    for (int i = 1; i <= numberR; i++)
                    {
                        if (numberR % i == 0)
                        {
                            count++;
                        }

                    }
                    if (count == 2)
                    {
                        sumPrimeNumbers += numberR;
                    }
                    else
                    {
                        sumNonPrimeNumbers += numberR;
                    }
                }
                number = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");
        }
    }
}
