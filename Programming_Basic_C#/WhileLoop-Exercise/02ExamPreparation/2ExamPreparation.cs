using System;

namespace _02ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int badGrade = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();
            int grade = 0;
            int score = 0;
            int countTask = 0;
            string lastTask = task;
            int countBadGrade = 0;
            while (badGrade > countBadGrade)
            {
                grade = int.Parse(Console.ReadLine());
                score += grade;
                countTask++;
                if (grade <= 4)
                {
                    countBadGrade++;
                    if (countBadGrade == badGrade)
                    {
                        break;
                    }
                }
                lastTask = task;
                task = Console.ReadLine();
                if (task == "Enough")
                {
                    double averageScore = 1.0 * score / countTask;
                    Console.WriteLine($"Average score: {averageScore:f2}");
                    Console.WriteLine($"Number of problems: {countTask}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    return;
                }
            }
            Console.WriteLine($"You need a break, {countBadGrade} poor grades.");
        }
    }
}
