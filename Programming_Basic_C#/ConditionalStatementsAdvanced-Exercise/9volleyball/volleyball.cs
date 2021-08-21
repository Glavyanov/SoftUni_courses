using System;

namespace _9volleyball
{
    class volleyball
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int countCelebrate = int.Parse(Console.ReadLine());
            int countWeekendToTravel = int.Parse(Console.ReadLine());
            double WeekendSofia = 48 - countWeekendToTravel;
            double saturdayPlays = 0.0;
            double celebratePlays = 0.0;
            double totalPlays = 0.0;
            switch (year)
            {
                case "leap":
                    saturdayPlays = WeekendSofia * 3 / 4.0;
                    celebratePlays = countCelebrate * 2 / 3.0;
                    totalPlays = saturdayPlays + celebratePlays + countWeekendToTravel;
                    totalPlays += totalPlays * 0.15;
                    break;
                case "normal":
                    saturdayPlays = WeekendSofia * 3 / 4.0;
                    celebratePlays = countCelebrate * 2 / 3.0;
                    totalPlays = saturdayPlays + celebratePlays + countWeekendToTravel;
                    break;
                default:
                    break;
            }
            Console.WriteLine(Math.Floor(totalPlays));

        }
    }
}
