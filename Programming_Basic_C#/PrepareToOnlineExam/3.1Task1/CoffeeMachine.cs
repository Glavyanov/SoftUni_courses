using System;

namespace ThirdTaskk
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string shugar = Console.ReadLine();
            byte countDrink = byte.Parse(Console.ReadLine());
            double price = 0;
            if(drink == "Espresso")
            {
                switch (shugar)
                {
                    case "Without":
                        price = countDrink * 0.90 * 0.65;
                        break;
                    case "Normal":
                        price = countDrink * 1.0;
                        break;
                    case "Extra":
                        price = countDrink * 1.20;
                        break;

                    default:
                        break;
                }
                if(countDrink >= 5)
                {
                    price *= 0.75;
                }
                if (price > 15)
                {
                    price *= 0.80;
                }
            }
            else if (drink == "Cappuccino")
            {
                switch (shugar)
                {
                    case "Without":
                        price = countDrink * 1 * 0.65;
                        break;
                    case "Normal":
                        price = countDrink * 1.20;
                        break;
                    case "Extra":
                        price = countDrink * 1.60;
                        break;

                    default:
                        break;
                }
                if (price > 15)
                {
                    price *= 0.80;
                }
            }
            else if (drink == "Tea")
            {
                switch (shugar)
                {
                    case "Without":
                        price = countDrink * 0.5 * 0.65;
                        break;
                    case "Normal":
                        price = countDrink * 0.60;
                        break;
                    case "Extra":
                        price = countDrink * 0.70;
                        break;

                    default:
                        break;
                }
                if (price > 15)
                {
                    price *= 0.80;
                }
            }
            Console.WriteLine($"You bought {countDrink} cups of {drink} for {price:f2} lv.");

        }
    }
}
