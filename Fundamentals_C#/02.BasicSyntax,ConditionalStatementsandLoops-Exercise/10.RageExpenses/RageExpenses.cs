using System;

namespace _10RageExpenses
{
    class RageExpenses
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            double costAllHeadset = (lostGames / 2 )* priceHeadset;
            double costAllMouse = (lostGames / 3 )* priceMouse;
            double costAllKeyboard = (lostGames / 6 )* priceKeyboard;
            double costAllDisplay = (lostGames / 12 )* priceDisplay;
            double total = costAllHeadset + costAllMouse + costAllKeyboard + costAllDisplay;
            Console.WriteLine($"Rage expenses: {total:F2} lv.");
        }
    }
}
