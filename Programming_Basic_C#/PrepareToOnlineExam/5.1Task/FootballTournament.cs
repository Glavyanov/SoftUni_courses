using System;

namespace FiveeTask
{
    class FootballTournament
    {
        static void Main(string[] args)
        {
            string nameTeam = Console.ReadLine();
            int countGames = int.Parse(Console.ReadLine());
            int w = 0;
            int d = 0;
            int l = 0;
            int all = 0;
            int score = 0;
            double percentWon = 0;
            for (int i = 1; i <= countGames; i++)
            {
                string result = Console.ReadLine();
                switch (result)
                {
                    case "W":
                        w++;
                        score += 3;
                        break;
                    case "D":
                        d++;
                        score += 1;
                        break;
                    case "L":
                        l++;
                        break;
                    default:
                        break;
                }
                all++;
            }
            if (all > 0)
            {
                percentWon = w * 1.0 / all * 100.0;
                Console.WriteLine($"{nameTeam} has won {score} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {w}");
                Console.WriteLine($"## D: {d}");
                Console.WriteLine($"## L: {l}");
                Console.WriteLine($"Win rate: {percentWon:f2}%");
            }
            else
            {
                Console.WriteLine($"{nameTeam} hasn't played any games during this season.");
            }
        }
    }
}
