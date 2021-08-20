using System;

namespace _10InvalidNumber
{
class Program
{
static void Main(string[] args)
{
    int num = int.Parse(Console.ReadLine());
    if ((num <= -1 || num >= 1) && (num < 100 || num > 200))
    {
        Console.WriteLine("invalid");
    }

}
}
}
