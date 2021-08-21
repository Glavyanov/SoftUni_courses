using System;

namespace _07SumNumbers
{
class SumNumbers
{
static void Main(string[] args)
{
    int count = int.Parse(Console.ReadLine());
    int sum = 0;
    if (count > 0)
    {
        int first = int.Parse(Console.ReadLine());
        sum += first;
    }
    for (int i = 1; i < count; i++)
    {
        int second = int.Parse(Console.ReadLine());
        sum += second;
    }
    Console.WriteLine(sum);
}
}
}
