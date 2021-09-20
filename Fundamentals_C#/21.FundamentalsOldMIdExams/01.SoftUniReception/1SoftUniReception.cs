using System;

namespace _01.SoftUniReception
{
    class SoftUniReception
    {
        static void Main(string[] args)
        {
            int empoyleEfficiency1 = int.Parse(Console.ReadLine());
            int empoyleEfficiency2 = int.Parse(Console.ReadLine());
            int empoyleEfficiency3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int sumEmployers = empoyleEfficiency1 + empoyleEfficiency2 + empoyleEfficiency3;
            int count = 0;
            int countbreaks = 0;
            while (studentsCount != 0)
            {
                if (countbreaks == 3)
                {
                    countbreaks = 0;
                    count++;
                    continue;
                }

                studentsCount -= sumEmployers;
                count++;
                countbreaks++;
                if (studentsCount < 0)
                {
                    studentsCount = 0;
                }
            }
            Console.WriteLine($"Time needed: {count}h.");
        }
    }
}
