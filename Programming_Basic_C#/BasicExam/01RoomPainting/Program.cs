using System;

namespace _01RoomPainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPaintBoxes = int.Parse(Console.ReadLine());
            int countTapeRolls = int.Parse(Console.ReadLine());
            double priceOneHand = double.Parse(Console.ReadLine());
            double priceOneBrush = double.Parse(Console.ReadLine());

            double pricePaint = 21.50 * countPaintBoxes;
            double priceTapes = 5.20 * countTapeRolls;
            double neededHand = Math.Ceiling(countTapeRolls * 0.35);
            double neededBrush = Math.Floor(countPaintBoxes * 0.48);
            double totalPriceBrush = priceOneBrush * neededBrush;
            double totalPriceHand = priceOneHand * neededHand;
            double totalSum = pricePaint + priceTapes + totalPriceBrush + totalPriceHand;
            double priceDelivery = totalSum / 15;
            Console.WriteLine($"This delivery will cost {priceDelivery:f2} lv.");
        }
    }
}
