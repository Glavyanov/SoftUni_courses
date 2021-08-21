using System;

namespace _11CleverLilly
{
    class CleverLilly
    {
        static void Main(string[] args)
        {
            int ageLilly = int.Parse(Console.ReadLine());
            double priceWashMachine = double.Parse(Console.ReadLine());
            double priceToys = double.Parse(Console.ReadLine());
            double toys = 0.0;
            double money = 0.0;
            double gift = 10;
            

            for(int i = 1; i <= ageLilly; i++ )
            {
                if (i % 2 == 1)
                {
                    toys += 1;
                }
                else 
                {
                    money += gift;
                    gift += 10;
                    money = money - 1;
                }

                
            }
            double moneyToys = toys * priceToys;
            if ((money + moneyToys) >= priceWashMachine)
            {
                double result = (money + moneyToys) - priceWashMachine;
                Console.WriteLine($"Yes! {result:f2}");
            }
            else
            {
                double result = priceWashMachine -(money + moneyToys) ;
                Console.WriteLine($"No! {result:f2}");
            }
        }
    }
}
