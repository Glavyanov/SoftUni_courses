using System;

namespace _02PoundstoDollars
{
    class PoundstoDollars
    {
        static void Main(string[] args)
        {
            decimal britishPound = decimal.Parse(Console.ReadLine());
            decimal dollar = britishPound * 1.31M;
            Console.WriteLine($"{dollar:f3}");
        }
    }
}
