using System;

namespace _07WorldSwimmingRecord
{
class Program
{
static void Main(string[] args)
{
    double record = double.Parse(Console.ReadLine());
    double meters = double.Parse(Console.ReadLine());
    double secPerOneMeter = double.Parse(Console.ReadLine());

    double realTime = meters * secPerOneMeter;
    double slow = Math.Floor(meters / 15) * 12.5;
    realTime += +slow;
    double needed = 0;
    if (record <= realTime)
    {
        needed = realTime - record;
        Console.WriteLine($"No, he failed! He was {needed:f2} seconds slower.");
    }
    else
    {
        Console.WriteLine($"Yes, he succeeded! The new world record is {realTime:f2} seconds.");
    }
}
}
}
