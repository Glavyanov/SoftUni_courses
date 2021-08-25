using System;

namespace _04TrainTheTrainers
{
    class TrainTheTrainers
    {
        static void Main(string[] args)
        {
            int lector = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double averageGrade = 0;
            double sumGrade = 0;
            double allAverage = 0;
            string rePresentation = presentation;
            int count = 0;
            while (presentation != "Finish")
            {
                for (int i = 1; i <= lector; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumGrade += grade;
                    averageGrade = sumGrade / lector;
                }
                allAverage += averageGrade;
                sumGrade = 0;
                Console.WriteLine($"{presentation} - {averageGrade:f2}.");
                count++;
                presentation = Console.ReadLine();
            }
            if (count > 1)
            {
                Console.WriteLine($"Student's final assessment is {allAverage/ count:f2}.");
            }
            else
            {
                Console.WriteLine($"Student's final assessment is {allAverage:f2}.");
            }
        }
    }
}
