using System;

namespace _05SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int go = 1; go <= number; go++)
            {
                int goOn = go;
                while (goOn != 0)
                {
                    int lastDigit = goOn % 10;
                    sum += lastDigit;
                    goOn /= 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{go} -> True");
                }
                else
                {
                    Console.WriteLine($"{go} -> False");
                }
                sum = 0;
            }
        }
    }
}
