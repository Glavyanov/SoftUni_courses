using System;

namespace _03NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string kindFlowers = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;
            double needed = 0.0;
            switch (kindFlowers)
            {
                case "Roses":
                    if (count > 80)
                    {
                        price = (count * 5) * 0.9;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = count * 5;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    break;
                case "Dahlias":
                    if (count > 90)
                    {
                        price = (count * 3.80) * 0.85;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = count * 3.80;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    break;
                case "Tulips":
                    if (count > 80)
                    {
                        price = (count * 2.80) * 0.85;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = count * 2.80;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    break;
                case "Narcissus":
                    if (count < 120)
                    {
                        price = (count * 3) * 1.15;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = count * 3;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    break;
                case "Gladiolus":
                    if (count < 80)
                    {
                        price = (count * 2.50) * 1.20;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = count * 2.50;
                        if (budget >= price)
                        {
                            needed = budget - price;
                            Console.WriteLine($"Hey, you have a great garden with {count} {kindFlowers} and {needed:f2} leva left.");
                        }
                        else
                        {
                            needed = price - budget;
                            Console.WriteLine($"Not enough money, you need {needed:f2} leva more.");
                        }
                    }
                    break;
                default:
                    break;
            }



        }
    }
}
