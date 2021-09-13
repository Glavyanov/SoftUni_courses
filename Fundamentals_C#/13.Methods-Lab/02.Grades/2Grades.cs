using System;

namespace _02Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGradesInWords(grade);
        }

        private static void PrintGradesInWords(double grade)
        {
            string gradeWords = string.Empty;
            if (grade > 5.49)
            {
                gradeWords = "Excellent";
            }
            else if (grade > 4.49)
            {
                gradeWords = "Very good"; 
            }
            else if (grade > 3.49)
            {
                gradeWords = "Good";
            }
            else if(grade > 2.99)
            {
                gradeWords = "Poor";
            }
            else
            {
                gradeWords = "Fail";
            }
            Console.WriteLine(gradeWords);
        }
    }
}
