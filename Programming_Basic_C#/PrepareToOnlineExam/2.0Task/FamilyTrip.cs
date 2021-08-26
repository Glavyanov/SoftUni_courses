using System;

namespace SeconddTask
{
    class FamilyTrip
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int percentExtraBilds = int.Parse(Console.ReadLine());
            if (nights > 7)
            {
                pricePerNight *= 0.95;
            }
            double tripCost = nights * pricePerNight;
            double extraBilds = budget * (percentExtraBilds * 0.01);
            double total = tripCost + extraBilds;
            if(total <= budget)
            {
                double extra = budget - total;
                Console.WriteLine($"Ivanovi will be left with {extra:f2} leva after vacation.");
            }
            else
            {
                double needed = total - budget;
                Console.WriteLine($"{needed:f2} leva needed.");
            }

        }
    }
}
