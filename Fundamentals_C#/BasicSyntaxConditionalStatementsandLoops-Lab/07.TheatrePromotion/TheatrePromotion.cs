using System;

namespace _07TheatrePromotion
{
class TheatrePromotion
{
static void Main(string[] args)
{
    string day = Console.ReadLine();
    int age = int.Parse(Console.ReadLine());
    int ticket = 0;

    if (day == "Weekday")
    {
        if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
        {
            ticket = 12;
        }
        else if (age > 18 && age <= 64)
        {
            ticket = 18;
        }
    }
    else if (day == "Weekend")
    {
        if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
        {
            ticket = 15;
        }
        else if (age > 18 && age <= 64)
        {
            ticket = 20;
        }
    }
    else if (day == "Holiday")
    {
        if (age >= 0 && age <= 18)
        {
            ticket = 5;
        }
        else if (age > 18 && age <= 64)
        {
            ticket = 12;
        }
        else if (age > 64 && age <= 122)
        {
            ticket = 10;
        }
    }
    if (ticket != 0)
    {
        Console.WriteLine(ticket + "$");
    }
    else
    {
        Console.WriteLine("Error!");
    }
}
}
}
