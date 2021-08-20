using System;

namespace _08CinemaTicket
{
class Program
{
static void Main(string[] args)
{
    string dayOfWeek = Console.ReadLine();
    int price = 0;
    switch (dayOfWeek)
    {
        case "Monday":
        case "Tuesday":
        case "Friday":
            price = 12;
            break;
        case "Saturday":
        case "Sunday":
            price = 16;
            break;
        case "Wednesday":
        case "Thursday":
            price = 14;
            break;
        default:
            break;
    }
    Console.WriteLine(price);
}

}
}
