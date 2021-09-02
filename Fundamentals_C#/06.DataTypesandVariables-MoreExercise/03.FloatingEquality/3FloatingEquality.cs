using System;

namespace _03FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal one = decimal.Parse(Console.ReadLine());
            decimal two = decimal.Parse(Console.ReadLine());
            const decimal eps = 0.000001m;
            decimal? result = null;
            bool compare = false;
            if (one < 0 && two > 0)
            {
                result = Math.Abs(one) + two;
            }
            else if (one > 0 && two < 0)
            {
                result = Math.Abs(two) + one;
            }
            else if (one < 0 && two < 0)
            {
                if (one < two)
                {
                    result = Math.Abs(one) - Math.Abs(two);
                }
                else if (two < one)
                {
                    result = Math.Abs(two) - Math.Abs(one);
                }
                else
                {
                    compare = true;
                }

            }
            else if (one > 0 && two > 0)
            {
                if (one > two)
                {
                    result = one - two;
                }
                else if (two > one)
                {
                    result = two - one;
                }
                else
                {
                    compare = true;
                }
            }

            if (result < eps )
            {
                compare = true;
            }
            Console.WriteLine(compare);
        }
    }
}
