using System;

namespace _05TimeMinutes
{
class TimeMinutes
{
static void Main(string[] args)
{
    int hour = int.Parse(Console.ReadLine());
    int minutes = int.Parse(Console.ReadLine());

    hour *= 60;
    int time = hour + minutes + 15;
    int newHour = time / 60;
    int newMinutes = time % 60;
    if (newHour >= 24)
    {
        newHour = 0;
    }
    Console.WriteLine($"{newHour}:{newMinutes:d2}");
}
}
}
