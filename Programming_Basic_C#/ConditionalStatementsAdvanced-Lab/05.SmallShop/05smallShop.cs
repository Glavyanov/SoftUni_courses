using System;

namespace _05smallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());
            switch (product)
            {
                case "coffee":
                    if (city == "Sofia")
                    {
                        Console.WriteLine(number * 0.50);
                    }
                    else if (city == "Plovdiv")
                    {
                        Console.WriteLine(number * 0.40);
                    }
                    else if (city == "Varna")
                    {
                        Console.WriteLine(number * 0.45);
                    }
                    break;
                case "water":
                    if (city == "Sofia")
                    {
                        Console.WriteLine(number * 0.80);
                    }
                    else if (city == "Plovdiv")
                    {
                        Console.WriteLine(number * 0.70);
                    }
                    else if (city == "Varna")
                    {
                        Console.WriteLine(number * 0.70);
                    }
                    break;
                case "beer":
                    if (city == "Sofia")
                    {
                        Console.WriteLine(number * 1.20);
                    }
                    else if (city == "Plovdiv")
                    {
                        Console.WriteLine(number * 1.15);
                    }
                    else if (city == "Varna")
                    {
                        Console.WriteLine(number * 1.10);
                    }
                    break;
                case "sweets":
                    if (city == "Sofia")
                    {
                        Console.WriteLine(number * 1.45);
                    }
                    else if (city == "Plovdiv")
                    {
                        Console.WriteLine(number * 1.30);
                    }
                    else if (city == "Varna")
                    {
                        Console.WriteLine(number * 1.35);
                    }
                    break;
                case "peanuts":
                    if (city == "Sofia")
                    {
                        Console.WriteLine(number * 1.60);
                    }
                    else if (city == "Plovdiv")
                    {
                        Console.WriteLine(number * 1.50);
                    }
                    else if (city == "Varna")
                    {
                        Console.WriteLine(number * 1.55);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
