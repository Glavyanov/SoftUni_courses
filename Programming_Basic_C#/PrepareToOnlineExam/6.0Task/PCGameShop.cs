using System;

namespace SixTask
{
    class PCGameShop
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countHearthstone = 0;
            int countFornite = 0;
            int countOverwatch = 0;
            int countOthers = 0;
            for (int i = 0; i < n; i++)
            {
                string game = Console.ReadLine();
                if (game == "Hearthstone")
                {
                    countHearthstone++;
                }
                else if (game == "Fornite")
                {
                    countFornite++;
                }
                else if (game == "Overwatch")
                {
                    countOverwatch++;
                }
                else
                {
                    countOthers++;
                }
            }
            Console.WriteLine($"Hearthstone - {((countHearthstone * 1.0 / n) * 100):f2}%");
            Console.WriteLine($"Fornite - {((countFornite * 1.0 / n) * 100):f2}%");
            Console.WriteLine($"Overwatch - {((countOverwatch * 1.0 / n) * 100):f2}%");
            Console.WriteLine($"Others - {((countOthers * 1.0 / n) * 100):f2}%");
        }
        
    }
}
