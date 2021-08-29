using System;

namespace _02Division
{
class Division
{
static void Main(string[] args)
{
    int number = int.Parse(Console.ReadLine());
    bool flag = true;

    if (number % 10 == 0)
    {
        number = 10;
    }
    else if (number % 7 == 0)
    {
        number = 7;
    }
    else if (number % 6 == 0)
    {
        number = 6;
    }
    else if (number % 3 == 0)
    {
        number = 3;
    }
    else if (number % 2 == 0)
    {
        number = 2;
    }
    else
    {
        Console.WriteLine("Not divisible");
        flag = false;
    }
    if (flag)
    {
        Console.WriteLine($"The number is divisible by {number}");
    }
}
}
}
