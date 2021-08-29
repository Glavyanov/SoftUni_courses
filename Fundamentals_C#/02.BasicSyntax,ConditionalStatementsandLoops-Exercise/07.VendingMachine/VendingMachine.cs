using System;

namespace _07VendingMachine
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            string commandStart = Console.ReadLine();
            double sum = 0;
            while (commandStart != "Start")
            {
                double coin = double.Parse(commandStart);
                bool flag = (coin == 0.1) || (coin == 0.2) || (coin == 0.5) || (coin == 1) || (coin == 2);
                if (!flag)
                {
                    Console.WriteLine("Cannot accept {0}", coin);
                    coin = 0;
                }
                sum += coin;
                commandStart = Console.ReadLine();
            }
            string commandEnd = Console.ReadLine();
            while (commandEnd != "End")
            {
                switch (commandEnd)
                {
                    case "Nuts":
                        if (sum < 2.0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine("Purchased nuts");
                            sum -= 2.0;
                        }
                        break;
                    case "Water":
                        if (sum < 0.7)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine("Purchased water");
                            sum -= 0.7;
                        }
                        break;
                    case "Crisps":
                        if (sum < 1.5)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            sum -= 1.5;
                            Console.WriteLine("Purchased crisps");
                        }
                        break;
                    case "Soda":
                        if (sum < 0.8)
                        {
                            Console.WriteLine("Sorry, not enough money");

                        }
                        else
                        {
                            sum -= 0.8;
                            Console.WriteLine("Purchased soda");
                        }
                        break;
                    case "Coke":
                        if (sum < 1.0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine("Purchased coke");
                            sum -= 1.0;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                commandEnd = Console.ReadLine();
            }
            Console.WriteLine("Change: {0:f2}", sum);
        }
    }
}
