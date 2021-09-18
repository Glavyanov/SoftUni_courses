using System;
using System.Numerics;

namespace _02BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            FactorialFinder calc = new FactorialFinder(n);
            Console.WriteLine(calc.FactorialGet());
        }

    }
    class FactorialFinder
    {
        public FactorialFinder(int n)
        {
            N = n;
        }
        public int N { get; set; }
        public BigInteger FactorialGet()
        {
            BigInteger result = 1;
            for(int i = 2; i <= N; i++)
            {
                result *= i;
            }
            return result;
        }

    }
}
