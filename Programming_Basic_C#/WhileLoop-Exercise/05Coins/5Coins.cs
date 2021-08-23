using System;

namespace _05Coins
{
    class Coins
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            change = change * 100;
            int convertChange = (int)change;
            int coins = 0;
            while (convertChange != 0 && convertChange > 0)
            {
                if (convertChange >= 200)
                {
                    coins++;
                    convertChange -= 200;
                }
                else if (convertChange >= 100)
                {
                    coins++;
                    convertChange -= 100;
                }
                else if (convertChange >= 50)
                {
                    coins++;
                    convertChange -= 50;
                }
                else if (convertChange >= 20)
                {
                    coins++;
                    convertChange -= 20;
                }
                else if (convertChange >= 10)
                {
                    coins++;
                    convertChange -= 10;
                }
                else if (convertChange >= 5)
                {
                    coins++;
                    convertChange -= 5;
                }
                else if (convertChange >= 2)
                {
                    coins++;
                    convertChange -= 2;
                }
                else if (convertChange >= 1)
                {
                    coins++;
                    convertChange -= 1;
                }
            }
            Console.WriteLine(coins);
        }
    }
}
