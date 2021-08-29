using System;

namespace _9SumofOddNumbers
{
    class SumofOddNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for(int i = 1; i<= n ;i ++ )
            {
                Console.WriteLine(2*i-1);
                sum += 2 * i - 1;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
