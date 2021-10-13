using System;
using System.Collections.Generic;

namespace _05.DateModifier
{
    class DateAndTime
    {
        static void Main(string[] args)
        {
            
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculatingDiff(dateOne, dateTwo));
        }
    }
}
