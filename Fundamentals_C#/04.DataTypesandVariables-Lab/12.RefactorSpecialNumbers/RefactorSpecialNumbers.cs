using System;

namespace _12RefactorSpecialNumbers
{
    class RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int digit = 1; digit <= number; digit++)
            {
                int current = digit;
                int sum = 0;
                while (current > 0)
                {
                    sum += current % 10;
                    current = current / 10;
                }
                bool flag = false;
                flag = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", digit, flag);
                sum = 0;
            }
        }
    }
}
