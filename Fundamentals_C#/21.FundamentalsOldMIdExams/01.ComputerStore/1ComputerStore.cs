using System;

namespace _01.ComputerStore
{
    class ComputerStore
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double total = 0;
            while (command != "special" && command != "regular")
            {
                double price = double.Parse(command);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;

                }
                total += price;
                command = Console.ReadLine();

            }
            if (total <= 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double priceWTax = total * 1.20;
                double taxes = priceWTax - total;
                if (command == "special")
                {
                    priceWTax *= 0.90;
                }

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {total:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {priceWTax:f2}$");

            }
        }
    }
}
