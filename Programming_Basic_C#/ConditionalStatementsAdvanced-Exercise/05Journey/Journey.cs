using System;

namespace _05Journey
{
class Journey
{
static void Main(string[] args)
{
    double budget = double.Parse(Console.ReadLine());
    string season = Console.ReadLine();
    double spend = 0;
    string destination = "";
    string holiday = "";

    if (budget > 1000)
    {
        destination = "Europe";
        spend = budget * 0.90;
        holiday = "Hotel";
    }
    else if (budget <= 1000 && budget > 100)
    {
        switch (season)
        {
            case "summer":
                destination = "Balkans";
                spend = budget * 0.40;
                holiday = "Camp";
                break;
            case "winter":
                destination = "Balkans";
                spend = budget * 0.80;
                holiday = "Hotel";
                break;
            default:
                break;
        }
    }
    else
    {
        switch (season)
        {
            case "summer":
                destination = "Bulgaria";
                spend = budget * 0.30;
                holiday = "Camp";
                break;
            case "winter":
                destination = "Bulgaria";
                spend = budget * 0.70;
                holiday = "Hotel";
                break;
            default:
                break;
        }
    }
    Console.WriteLine($"Somewhere in {destination}");
    Console.WriteLine($"{holiday} - {spend:f2}");
}
}
}
