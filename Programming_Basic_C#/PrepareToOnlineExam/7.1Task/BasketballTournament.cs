using System;

namespace ExtraaTask
{
    class BasketballTournament
    {
        static void Main(string[] args)
        {
            string tour = Console.ReadLine();
            int countWin = 0;
            int countLost = 0;
            int all = 0;
            while(tour != "End of tournaments")
            {
                int countMatch = int.Parse(Console.ReadLine());
                for (int i = 1; i <= countMatch; i++)
                {
                    int scoreDesi = int.Parse(Console.ReadLine());
                    int scoreEnemy = int.Parse(Console.ReadLine());
                    all++;
                    if (scoreDesi > scoreEnemy)
                    {
                        Console.WriteLine($"Game {i} of tournament {tour}: win with {scoreDesi - scoreEnemy} points.");
                        countWin++;
                    }
                    else
                    {
                        Console.WriteLine($"Game {i} of tournament {tour}: lost with {scoreEnemy - scoreDesi} points.");
                        countLost++;
                    }
                }
                tour = Console.ReadLine();
            }
            double percentWin = countWin * 1.0 / (all * 1.0) * 100;
            double percentLost = countLost * 1.0 / (all * 1.0) * 100;
            Console.WriteLine($"{percentWin:f2}% matches win");
            Console.WriteLine($"{percentLost:f2}% matches lost");
        }
    }
}
