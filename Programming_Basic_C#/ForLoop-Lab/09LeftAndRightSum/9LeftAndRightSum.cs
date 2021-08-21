using System;

namespace _09LeftAndRightSum
{
class LeftAndRightSum
{
static void Main(string[] args)
{
    int num = int.Parse(Console.ReadLine());
    int sumLeft = 0;
    int sumRight = 0;
    for (int i = 0; i < num; i++)
    {
        int leftOne = int.Parse(Console.ReadLine());
        sumLeft += leftOne;
    }
    for (int i = 0; i < num; i++)
    {
        int rightOne = int.Parse(Console.ReadLine());
        sumRight += rightOne;
    }
    if (sumLeft == sumRight)
    {
        Console.WriteLine($"Yes, sum = {sumLeft}");
    }
    else
    {
        int diff = Math.Abs(sumLeft - sumRight);
        Console.WriteLine($"No, diff = {diff}");
    }

}
}
}
