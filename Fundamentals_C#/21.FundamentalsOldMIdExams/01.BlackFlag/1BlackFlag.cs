using System;

namespace _01.BlackFlag
{
    class BlackFlag
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int plunderDaily = int.Parse(Console.ReadLine());
            double expected = double.Parse(Console.ReadLine());

            double gained = 0;
            int counterRise = 0;
            int counterDecrease = 0;

            for (int i = 0; i < days; i++)
            {
                gained += plunderDaily;
                counterRise++;
                counterDecrease++;
                if (counterRise == 3)
                {
                    gained += plunderDaily * 0.5;
                    counterRise = 0;

                }
                if (counterDecrease == 5)
                {
                    gained *= 0.70;
                    counterDecrease = 0;

                }
            }
            if (gained >= expected)
            {
                Console.WriteLine($"Ahoy! {gained:f2} plunder gained.");
            }
            else
            {
                double percent = gained / expected * 100;
                Console.WriteLine($"Collected only {percent:f2}% of the plunder.");
            }
        }
    }
}
