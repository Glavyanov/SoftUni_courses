using System;

namespace _05Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            TotalPrice(order, quantity);
        }
        static void TotalPrice(string drink, int count)
        {
            double price = 0;
            switch (drink)
            {
                case "coffee":
                    price = count * 1.50;
                    break;
                case "water":
                    price = count * 1.00;
                    break;
                case "coke":
                    price = count * 1.40;
                    break;
                case "snacks":
                    price = count * 2.00;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
