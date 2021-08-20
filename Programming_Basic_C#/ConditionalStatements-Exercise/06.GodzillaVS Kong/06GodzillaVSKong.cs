using System;

namespace _06GodzillaVS_Kong
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            int team = int.Parse(Console.ReadLine());
            double priceDress = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;
            double totalPriceDress = priceDress * team;
            double sumneeded = 0;
            double discount = 0;

            if (team > 150)
            {
                discount = totalPriceDress * 0.10;
                totalPriceDress -= discount;
            }

            if (budget < (decor + totalPriceDress))
            {
                sumneeded = (decor + totalPriceDress) - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {sumneeded:f2} leva more.");
            }
            else
            {
                sumneeded = budget - (decor + totalPriceDress);
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {sumneeded:f2} leva left.");
            }

        }
    }
}
