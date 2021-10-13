
using System;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public static int CalculatingDiff(string date1, string date2)
        {
            DateTime dateOne = DateTime.Parse(date1);
            DateTime dateTwo = DateTime.Parse(date2);

            return Math.Abs((dateOne - dateTwo).Days);
        }
    }
}
