using System;

namespace SecondTaskShopping
{
    class Shopping
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countVideocard = int.Parse(Console.ReadLine());
            int countProcessor = int.Parse(Console.ReadLine());
            int countRamMemory = int.Parse(Console.ReadLine());

            double priceVideocard = countVideocard * 250;
            double priceProcessor = countProcessor * (priceVideocard * 0.35);
            double priceRamMemory = countRamMemory * (priceVideocard * 0.10);
            double total = priceVideocard + priceProcessor + priceRamMemory;

            if (countVideocard > countProcessor)
            {
                total *= 0.85;
            }
            if (budget >= total )
            {
                double overBudget = budget - total;
                Console.WriteLine($"You have {overBudget:f2} leva left!");
            }
            else
            {
                double needed = total - budget;
                Console.WriteLine($"Not enough money! You need {needed:f2} leva more!");
            }
        }
    }
}
