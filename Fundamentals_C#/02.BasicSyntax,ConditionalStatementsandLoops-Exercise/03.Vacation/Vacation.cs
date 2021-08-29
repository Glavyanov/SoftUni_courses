using System;

namespace _03Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double totalPrice = 0;
            if (typeGroup == "Students")
            {
                switch (day)
                {
                    case "Friday":
                        price = 8.45;
                        break;
                    case "Saturday":
                        price = 9.80;
                        break;
                    case "Sunday":
                        price = 10.46;
                        break;
                }
                totalPrice = price * countPeople;
                if (countPeople >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (typeGroup == "Business")
            {
                switch (day)
                {
                    case "Friday":
                        price = 10.90;
                        break;
                    case "Saturday":
                        price = 15.60;
                        break;
                    case "Sunday":
                        price = 16;
                        break;
                }
                totalPrice = price * countPeople;
                if (countPeople >= 100)
                {
                    totalPrice = price * (countPeople - 10);
                }
            }
            else if (typeGroup == "Regular")
            {
                switch (day)
                {
                    case "Friday":
                        price = 15;
                        break;
                    case "Saturday":
                        price = 20;
                        break;
                    case "Sunday":
                        price = 22.50;
                        break;
                }
                totalPrice = price * countPeople;
                if (countPeople > 10 && countPeople <= 20)
                {
                    totalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}
 