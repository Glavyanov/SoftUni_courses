using System;

namespace _06GoldMine
{
    class GoldMine
    {
        static void Main(string[] args)
        {
            int numLocation = int.Parse(Console.ReadLine());
            int extractionPerDay = 0;
            double averageExtractionPerDay = 0;
            for (int i = numLocation; i > 0; i--)
            {
                double expectedExtraction = double.Parse(Console.ReadLine());
                int daysForExtraction = int.Parse(Console.ReadLine());
                extractionPerDay = 0;
                for (int j = daysForExtraction; j > 0; j--)
                {
                    extractionPerDay += int.Parse(Console.ReadLine());

                }
                averageExtractionPerDay = 1.0 * extractionPerDay / daysForExtraction;
                if (averageExtractionPerDay >= expectedExtraction)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageExtractionPerDay:f2}.");

                }
                else
                {
                    double needed = expectedExtraction - averageExtractionPerDay;
                    Console.WriteLine($"You need {needed:f2} gold.");
                }



            }

        }
    }
}
