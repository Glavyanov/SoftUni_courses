using System;

namespace FourrTask
{
    class EasterCompetition
    {
        static void Main(string[] args)
        {
            int countCake = int.Parse(Console.ReadLine());
            int currGrade = 0;
            int sumGrade = 0;
            string bakerWon = "";
            int pointsWon = 0;
            for (int i = 0; i < countCake; i++)
            {
                string baker = Console.ReadLine();
                
                string gradeBaker = Console.ReadLine();
                while (gradeBaker != "Stop")
                {
                    int newGradeBaker = int.Parse(gradeBaker);
                    sumGrade += newGradeBaker;
                    gradeBaker = Console.ReadLine();
                }
                Console.WriteLine($"{baker} has {sumGrade} points.");
                if (sumGrade > currGrade)
                {
                    Console.WriteLine($"{baker} is the new number 1!");
                    bakerWon = baker;
                    pointsWon = sumGrade;
                }
                currGrade = sumGrade;
                sumGrade = 0;
            }
            Console.WriteLine($"{bakerWon} won competition with {pointsWon} points!");
        }
    }
}
