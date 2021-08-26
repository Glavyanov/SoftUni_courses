using System;

namespace FirstTask
{
    class PoolDay
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            double taxxEntry = double.Parse(Console.ReadLine());
            double priceSunChair = double.Parse(Console.ReadLine());
            double priceOneUmbrella = double.Parse(Console.ReadLine());

            double allTaxxEntry = countPeople * taxxEntry;
            double pricePerChair = Math.Ceiling(countPeople * 0.75) * priceSunChair;
            double pricePerUmbrella = Math.Ceiling(countPeople * 0.50) * priceOneUmbrella;
            double total = allTaxxEntry + pricePerChair + pricePerUmbrella;
            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
