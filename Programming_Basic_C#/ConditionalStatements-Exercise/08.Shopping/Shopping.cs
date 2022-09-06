using System;

namespace _08Shopping
{
    internal class Shopping
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countVideoCards = int.Parse(Console.ReadLine()), countCPU = int.Parse(Console.ReadLine()), countRAM = int.Parse(Console.ReadLine());

            double priceVideoCards = countVideoCards * 250, priceCPU = priceVideoCards * 0.35 * countCPU, priceRAM = priceVideoCards * 0.1 * countRAM, total = priceCPU + priceRAM + priceVideoCards;
            
             _= countVideoCards > countCPU ? total *= 0.85 : total;

            Console.WriteLine(budget >= total ? $"You have {(budget - total):F2} leva left!" : $"Not enough money! You need {(total - budget):F2} leva more!");

        }
    }
}
