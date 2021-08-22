using System;

namespace _03SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int newNumber = 0;
            int sum = 0;
            while (sum < number)
            {
                newNumber = int.Parse(Console.ReadLine());
                sum += newNumber;
            }
            Console.WriteLine(sum);

        }
    }
}
