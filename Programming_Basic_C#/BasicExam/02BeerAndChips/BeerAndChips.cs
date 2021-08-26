using System;

namespace _02BeerAndChips
{
    class BeerAndChips
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int countBeers = int.Parse(Console.ReadLine());
            int countChips = int.Parse(Console.ReadLine());

            double priceBeers = countBeers * 1.20;
            double priceOneChips = priceBeers * 0.45;
            double totalPriceChips =Math.Ceiling( countChips * priceOneChips);
            double totalSum = priceBeers + totalPriceChips;
            if (totalSum <= budget)
            {
                double needed = Math.Abs(totalSum - budget);
                Console.WriteLine($"{name} bought a snack and has {needed:f2} leva left.");
            }
            else
            {
                double needed = Math.Abs(budget - totalSum);
                Console.WriteLine($"{name} needs {needed:f2} more leva!");
            }
        }
    }
}
