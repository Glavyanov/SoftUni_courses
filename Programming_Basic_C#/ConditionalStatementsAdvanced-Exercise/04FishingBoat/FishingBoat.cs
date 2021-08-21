using System;

namespace _04FishingBoat
{
    class FishingBoat
    {
        static void Main(string[] args)
        {

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            double price = 0;
            double needed = 0;
            double result = 0;

            switch (season)
            {
                case "Spring":
                    if (count <= 6)
                    {
                        price = 3000;
                        needed = price * 0.9;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }
                    }
                    else if (count > 6 && count < 12)
                    {
                        price = 3000;
                        needed = price * 0.85;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }
                    }
                    else
                    {
                        price = 3000;
                        needed = price * 0.75;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }

                    }
                    break;
                case "Winter":
                    if (count <= 6)
                    {
                        price = 2600;
                        needed = price * 0.9;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }
                    }
                    else if (count > 6 && count < 12)
                    {
                        price = 2600;
                        needed = price * 0.85;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }
                    }
                    else
                    {
                        price = 2600;
                        needed = price * 0.75;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }

                    }
                    break;
                case "Summer":
                    if (count <= 6)
                    {
                        price = 4200;
                        needed = price * 0.9;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }
                    }
                    else if (count > 6 && count < 12)
                    {
                        price = 4200;
                        needed = price * 0.85;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }
                    }
                    else
                    {
                        price = 4200;
                        needed = price * 0.75;
                        if (count % 2 == 0)
                        {
                            needed *= 0.95;
                        }

                    }
                    break;
                case "Autumn":
                    if (count <= 6)
                    {
                        price = 4200;
                        needed = price * 0.9;
                    }
                    else if (count > 6 && count < 12)
                    {
                        needed = price * 0.85;
                        price = 4200;
                    }
                    else
                    {
                        price = 4200;
                        needed = price * 0.75;
                    }
                    break;
                default:
                    break;
            }
            if (budget < needed)
            {
                result = needed - budget;
                Console.WriteLine($"Not enough money! You need {result:f2} leva.");

            }
            else
            {
                result = budget - needed;
                Console.WriteLine($"Yes! You have {result:f2} leva left.");
            }


        }
    }
}
