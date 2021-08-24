using System;

namespace _04SumOfTwoNumbers
{
    class SumOfTwoNumbers
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;
            bool stop = false;
            for (int i = start; i <= end; i++)
            {

                for (int j = start; j <= end; j++)
                {
                    sum = i + j;
                    counter++;
                    if (sum == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {sum})");
                        stop = true;
                        break;
                    }
                }
                if (stop)
                {
                    break;
                }
            }
            if (!stop)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");

            }

        }
    }
}
