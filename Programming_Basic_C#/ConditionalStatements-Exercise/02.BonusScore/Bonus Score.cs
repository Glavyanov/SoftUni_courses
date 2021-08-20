using System;

namespace BonusScore
{
class Program
{
static void Main(string[] args)
{
    int num = int.Parse(Console.ReadLine());
    double bonus = 0;
    if (num <= 100)
    {
        bonus += 5;
    }
    else if (num > 1000)
    {
        bonus += num * 0.10;
    }
    else
    {
        bonus += num * 0.20;
    }
    if (num % 2 == 0)
    {
        bonus += 1;
    }
    else if (num % 10 == 5)
    {
        bonus += 2;
    }
    Console.WriteLine(bonus);
    Console.WriteLine(num + bonus);
}
}
}
