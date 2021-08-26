using System;

namespace _03ComputerRoom
{
    class ComputerRoom
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            int countHours = int.Parse(Console.ReadLine());
            int countPeople = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            double priceOnePeople = 0;
            switch (mounth)
            {
                case "march":
                    if (time == "day")
                    {
                        priceOnePeople = 10.50;
                    }
                    else
                    {
                        priceOnePeople = 8.40;
                    }
                    break;
                case "april":
                    if (time == "day")
                    {
                        priceOnePeople = 10.50;
                    }
                    else
                    {
                        priceOnePeople = 8.40;
                    }
                    break;
                case "may":
                    if (time == "day")
                    {
                        priceOnePeople = 10.50;
                    }
                    else
                    {
                        priceOnePeople = 8.40;
                    }
                    break;
                case "june":
                    if (time == "day")
                    {
                        priceOnePeople = 12.60;
                    }
                    else
                    {
                        priceOnePeople = 10.20;
                    }
                    break;
                case "july":
                    if (time == "day")
                    {
                        priceOnePeople = 12.60;
                    }
                    else
                    {
                        priceOnePeople = 10.20;
                    }
                    break;
                case "august":
                    if (time == "day")
                    {
                        priceOnePeople = 12.60;
                    }
                    else
                    {
                        priceOnePeople = 10.20;
                    }
                    break;


                default:
                    break;
            }
            if (countPeople >= 4 )
            {
                priceOnePeople = priceOnePeople * 0.90;
            }
            if (countHours >= 5)
            {
                priceOnePeople = priceOnePeople * 0.50;
            }
            double totalPrice = priceOnePeople * countPeople * countHours;
            Console.WriteLine($"Price per person for one hour: {priceOnePeople:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}
