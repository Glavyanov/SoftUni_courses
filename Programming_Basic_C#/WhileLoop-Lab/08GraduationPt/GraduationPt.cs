using System;

namespace _08GraduationPt
{
    class GraduationPt
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string input = Console.ReadLine();
            int counter = 1;
            int badGrade = 0;
            double average = 0;
            while (counter < 13)
            {
                double grade = double.Parse(input);
                average += grade;
                if (grade < 4)
                {
                    badGrade++;
                }
                if (badGrade == 2)
                {
                    Console.WriteLine($"{name} has been excluded at {counter - 1} grade ");
                    break;
                }
                if (counter == 12)
                {
                    break;
                }


                input = Console.ReadLine();
                counter++;
            }
            if (counter == 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {(average / (counter * 1.0)):f2}");
            }


        }
    }
}
