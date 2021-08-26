using System;

namespace ThirdTask
{
    class TravelAgency
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string kindPackage = Console.ReadLine();
            string vipDiscount = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double priceDays = 0;
            bool count = true;
            if (days > 7)
            {
                days -= 1;
            }
            if ((city != "Bansko" && city != "Borovets" && city != "Varna" && city != "Burgas") || (kindPackage != "withEquipment"&& kindPackage != "noEquipment"&& kindPackage != "withBreakfast"&& kindPackage != "noBreakfast"))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                switch (city)
                {
                    case "Bansko":
                    case "Borovets":
                        if (kindPackage == "withEquipment")
                        {
                            if (vipDiscount == "yes")
                            {
                                priceDays = 100 * 0.90;
                                priceDays *= (days * 1.0);
                            }
                            else if(vipDiscount == "no")
                            {
                                priceDays = 100;
                                priceDays *= (days * 1.0);
                            }
                        }
                        else if (kindPackage == "noEquipment")
                        {
                            if (vipDiscount == "yes")
                            {
                                priceDays = 80 * 0.95;
                                priceDays *= (days * 1.0);
                            }
                            else if(vipDiscount == "no")
                            {
                                priceDays = 80;
                                priceDays *= (days * 1.0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        break;
                    case "Varna":
                    case "Burgas":
                        if (kindPackage == "withBreakfast")
                        {
                            if (vipDiscount == "yes")
                            {
                                priceDays = 130 * 0.88;
                                priceDays *= (days * 1.0);
                            }
                            else if(vipDiscount == "no")
                            {
                                priceDays = 130;
                                priceDays *= (days * 1.0);
                            }
                        }
                        else if (kindPackage == "noBreakfast")
                        {
                            if (vipDiscount == "yes")
                            {
                                priceDays = 100 * 0.93;
                                priceDays *= (days * 1.0);
                            }
                            else if(vipDiscount == "no")
                            {
                                priceDays = 100;
                                priceDays *= (days * 1.0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        count = false;
                        break;
                }
                if (count)
                {
                    Console.WriteLine($"The price is {priceDays:f2}lv! Have a nice time!");
                }
            }
        }
    }
}
