using System;

namespace TownInfo
{
    class TownInfo
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            uint population = uint.Parse(Console.ReadLine());
            decimal area = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"Town {city} has population of {population} and area {area} square km.");
        }
    }
}
