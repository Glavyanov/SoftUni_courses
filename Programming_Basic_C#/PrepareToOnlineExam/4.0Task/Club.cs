using System;

namespace FourTask
{
    class Club
    {
        static void Main(string[] args)
        {
            double wantedProfit = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double clubProfit = 0;
            bool flag = true;
            while (command != "Party!")
            {
                int numCoctails = int.Parse(Console.ReadLine());
                int length = int.Parse(command.Length.ToString());
                double currentProfit = numCoctails * length;
                if (currentProfit % 2 == 1)
                {
                    currentProfit *= 0.75;
                }
                clubProfit += currentProfit;
                if (clubProfit >= wantedProfit)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {clubProfit:f2} leva.");
                    flag = false;
                    break;
                }
                currentProfit = 0;
                command = Console.ReadLine();
            }
            if (flag)
            {
                double needed = wantedProfit - clubProfit;
                Console.WriteLine($"We need {needed:f2} leva more.");
                Console.WriteLine($"Club income - {clubProfit:f2} leva.");
            }
        }
    }
}
