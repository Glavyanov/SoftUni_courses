using System;

namespace Problem1
{
    class Task1
    {
        static void Main(string[] args)
        {
            double experienceNeed = double.Parse(Console.ReadLine());
            int countBattle = int.Parse(Console.ReadLine());
            double experiencePerBattle = 0;
            double sumExperience = 0;
            int count3 = 0;
            int count5 = 0;
            int count15 = 0;
            int countAll = 0;

            for (int i = 0; i < countBattle; i++)
            {
                experiencePerBattle = double.Parse(Console.ReadLine());
                count3++;
                count5++;
                count15++;
                countAll++;

                if (count3 == 3)
                {
                    experiencePerBattle *= 1.15;
                    count3 = 0;
                }
                if (count5 == 5)
                {
                    experiencePerBattle *= 0.90;
                    count5 = 0;
                }
                if (count15 == 15)
                {
                    experiencePerBattle *= 1.05;
                    count15++;
                }
                sumExperience += experiencePerBattle;
                if (sumExperience >= experienceNeed)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {countAll} battles.");
                    return;
                }

            }
            double needed = experienceNeed - sumExperience;
            Console.WriteLine($"Player was not able to collect the needed experience, {needed:f2} more needed.");
        }
    }
}
