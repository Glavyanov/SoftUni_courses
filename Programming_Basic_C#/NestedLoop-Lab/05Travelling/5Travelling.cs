using System;

namespace _05Travelling
{
    class Travelling
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            while (destination != "End")
            {
                double minBudget = double.Parse(Console.ReadLine());
                double savedMoney = 0;
                while (savedMoney < minBudget)
                {
                    savedMoney += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }
            
        }
    }
}
