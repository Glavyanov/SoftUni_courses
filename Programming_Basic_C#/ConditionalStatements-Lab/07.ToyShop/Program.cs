using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfVacancy = double.Parse(Console.ReadLine());
            int countPuzz = int.Parse(Console.ReadLine());
            int countDoll = int.Parse(Console.ReadLine());
            int countBear = int.Parse(Console.ReadLine());
            int countMini = int.Parse(Console.ReadLine());
            int countTruck = int.Parse(Console.ReadLine());
            double totalSum = (countPuzz * 2.60) + (countDoll * 3) + (countBear * 4.10) + (countMini * 8.20) + (countTruck * 2);
            double countToy = countPuzz + countDoll + countBear + countMini + countTruck;
            double discount = totalSum * 0.25;
            double rent = totalSum * 0.10;
            double profit = totalSum - rent;
            double moneyLeft = Math.Abs(profit - priceOfVacancy);

            if (countToy >= 50)
            {
                totalSum -= discount;
            }
            if (countToy >= 50)
            {
                rent = totalSum * 0.10;
            }
            if (countToy >= 50)
            {
                profit = totalSum - rent;
            }
            if (profit >= priceOfVacancy)
            {
                moneyLeft = profit - priceOfVacancy;
            }
            if (profit >= priceOfVacancy)
            {
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {moneyLeft:f2} lv needed.");
            }



        }
    }
}
