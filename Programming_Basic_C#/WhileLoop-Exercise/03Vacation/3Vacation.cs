using System;

namespace _03Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double moneyVacation = double.Parse(Console.ReadLine());
            double moneyDjesy = double.Parse(Console.ReadLine());
            double totalMoney = moneyDjesy;
            int countdays = 0;
            string action = "";
            double sum = 0.0;
            int countSpend = 0;
            while (moneyVacation > totalMoney)
            {
                action = Console.ReadLine();
                sum = double.Parse(Console.ReadLine());
                if (action == "spend")
                {
                    totalMoney -= sum;
                    if (totalMoney < sum)
                    {
                        totalMoney = 0;
                    }
                    countSpend++;
                }
                else if (action == "save")
                {
                    totalMoney += sum;
                    countSpend = 0;
                }
                countdays++;
                if (countSpend == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(countdays);
                    return;
                }
            }
            Console.WriteLine($"You saved the money for {countdays} days.");
        }
    }
}
