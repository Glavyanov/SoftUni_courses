using System;

namespace _13SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const double roomForOnePerson = 18.00;
            const double apartment = 25.00;
            const double presidentApartment = 35.00;

            int day = int.Parse(Console.ReadLine());
            string kind = Console.ReadLine();
            string evaluation = Console.ReadLine();
            double discount = 0.0;
            double totalPrice = 0.0;
            int nights = day - 1;
            if (kind == "room for one person")
            {
                switch (evaluation)
                {
                    case "positive":
                        totalPrice = nights * roomForOnePerson;
                        discount = totalPrice * 0.25;
                        Console.WriteLine($"{(totalPrice + discount):f2}");
                        break;
                    case "negative":
                        totalPrice = nights * roomForOnePerson;
                        discount = totalPrice * 0.10;
                        Console.WriteLine($"{(totalPrice - discount):f2}");
                        break;
                    default:
                        break;
                }
            }
            else if (kind == "apartment")
            {
                if (day > 15)
                {
                    totalPrice = nights * apartment;
                    totalPrice -= totalPrice * 0.50;
                    switch (evaluation)
                    {
                        case "positive":
                            discount = totalPrice * 0.25;
                            Console.WriteLine($"{(totalPrice + discount):f2}");
                            break;
                        case "negative":
                            discount = totalPrice * 0.10;
                            Console.WriteLine($"{(totalPrice - discount):f2}");
                            break;
                        default:
                            break;
                    }

                }
                else if (day >= 10 && day <= 15)
                {
                    totalPrice = nights * apartment;
                    totalPrice -= totalPrice * 0.35;

                    switch (evaluation)
                    {
                        case "positive":
                            discount = totalPrice * 0.25;
                            Console.WriteLine($"{(totalPrice + discount):f2}");
                            break;
                        case "negative":
                            discount = totalPrice * 0.10;
                            Console.WriteLine($"{(totalPrice - discount):f2}");
                            break;
                        default:
                            break;
                    }

                }
                else if (day < 10)
                {
                    totalPrice = nights * apartment;
                    totalPrice -= totalPrice * 0.30;

                    switch (evaluation)
                    {
                        case "positive":
                            discount = totalPrice * 0.25;
                            Console.WriteLine($"{(totalPrice + discount):f2}");
                            break;
                        case "negative":
                            discount = totalPrice * 0.10;
                            Console.WriteLine($"{(totalPrice - discount):f2}");
                            break;
                        default:
                            break;
                    }

                }

            }
            else if (kind == "president apartment")
            {
                if (day > 15)
                {
                    totalPrice = nights * presidentApartment;
                    totalPrice -= totalPrice * 0.20;
                    switch (evaluation)
                    {
                        case "positive":
                            discount = totalPrice * 0.25;
                            Console.WriteLine($"{(totalPrice + discount):f2}");
                            break;
                        case "negative":
                            discount = totalPrice * 0.10;
                            Console.WriteLine($"{(totalPrice - discount):f2}");
                            break;
                        default:
                            break;
                    }

                }
                else if (day >= 10 && day <= 15)
                {
                    totalPrice = nights * presidentApartment;
                    totalPrice -= totalPrice * 0.15;

                    switch (evaluation)
                    {
                        case "positive":
                            discount = totalPrice * 0.25;
                            Console.WriteLine($"{(totalPrice + discount):f2}");
                            break;
                        case "negative":
                            discount = totalPrice * 0.10;
                            Console.WriteLine($"{(totalPrice - discount):f2}");
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine($"{(totalPrice + discount):f2}");
                }
                else if (day < 10)
                {
                    totalPrice = nights * presidentApartment;
                    totalPrice -= totalPrice * 0.10;

                    switch (evaluation)
                    {
                        case "positive":
                            discount = totalPrice * 0.25;
                            Console.WriteLine($"{(totalPrice + discount):f2}");
                            break;
                        case "negative":
                            discount = totalPrice * 0.10;
                            Console.WriteLine($"{(totalPrice - discount):f2}");
                            break;
                        default:
                            break;
                    }

                }

            }

        }
    }
}
