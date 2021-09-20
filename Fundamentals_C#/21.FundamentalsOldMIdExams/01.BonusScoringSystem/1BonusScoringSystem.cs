using System;

namespace _01.BonusScoringSystem
{
    class BonusScoringSystem
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            int countLectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int maxattended = 0;
            for (int i = 0; i < countStudents; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double currentBonus = attendances * 1.0 / countLectures * (5 + bonus);
                if (currentBonus > maxBonus)
                {
                    maxBonus = currentBonus;
                    maxattended = attendances;
                }

            }
            maxBonus = Math.Ceiling(maxBonus);
            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxattended} lectures.");



        }
    }
}
