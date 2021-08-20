using System;

namespace _07WorkingHours
{
class Program
{
static void Main(string[] args)
{
    int dayTime = int.Parse(Console.ReadLine());
    string text = Console.ReadLine();

    if (dayTime >= 10 && dayTime <= 18)
    {
        switch (text)
        {
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
            case "Saturday":
                Console.WriteLine("open");
                break;
            case "Sunday":
                Console.WriteLine("closed");
                break;
            default:
                break;
        }
    }
    else
    {
        Console.WriteLine("closed");
    }
}
}
}
