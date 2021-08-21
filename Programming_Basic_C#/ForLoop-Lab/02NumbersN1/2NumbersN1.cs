using System;

namespace _02NumbersN1
{
    class NumbersN1
    {
        static void Main(string[] args)
        {
            int initial = int.Parse(Console.ReadLine());
            for (int i = initial; i > 0 ; i --)
            {
                Console.WriteLine(i);
            }
        }
    }
}
