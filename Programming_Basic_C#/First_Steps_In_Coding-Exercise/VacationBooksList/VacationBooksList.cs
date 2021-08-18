using System;

namespace VacationBooksList
{
    class VacationBooksList
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double pagePerOneHour = double.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            double allHours = count / pagePerOneHour;
            double timePerDay = allHours / numberOfDays;
            Console.WriteLine(timePerDay);


        }
    }
}
