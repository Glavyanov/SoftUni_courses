using System;

namespace _04CenturiestoMinutes
{
    class CenturiestoMinutes
    {
        static void Main(string[] args)
        {
            uint century = uint.Parse(Console.ReadLine());
            uint years = century * 100;
            decimal days = years * 365.2422M;
            uint hours = (uint)days * 24;
            uint min = hours * 60;
            Console.WriteLine($"{century} centuries = {years} years = {(uint)days} days = {hours} hours = {min} minutes");
        }
    }
}
