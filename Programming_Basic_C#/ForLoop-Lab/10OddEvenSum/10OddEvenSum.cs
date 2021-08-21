using System;

namespace evenOddSum
{
    class evenOddSum
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int numEven = 0;
            int numOdd = 0;
            for (int i = 1; i <= count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    numEven += num;
                }
                else
                {
                    numOdd += num;
                }
            }
            if (numEven == numOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {numEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(numEven - numOdd)}");
            }


        }
    }
}
