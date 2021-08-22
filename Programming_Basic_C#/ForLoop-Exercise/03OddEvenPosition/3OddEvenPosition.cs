using System;

namespace _03OddEvenPosition
{
class Program
{
static void Main(string[] args)
{
    int n = int.Parse(Console.ReadLine());
    double evenSum = 0;
    double evenMin = double.MaxValue;
    double evenMax = double.MinValue;
    double oddSum = 0;
    double oddMin = double.MaxValue;
    double oddMax = double.MinValue;

    for (int i = 1; i <= n; i++)
    {
        double num = double.Parse(Console.ReadLine());
        if (i % 2 == 0)
        {
            evenSum += num;
            if (num < evenMin)
            {
                evenMin = num;
            }
            if (num > evenMax)
            {
                evenMax = num;
            }
        }
        else
        {
            oddSum += num;
            if (num < oddMin)
            {
                oddMin = num;
            }
            if (num > oddMax)
            {
                oddMax = num;
            }
        }
    }
    if (oddSum != 0)
    {
        Console.WriteLine($"OddSum={oddSum:f2},");
        Console.WriteLine($"OddMin={oddMin:f2},");
        Console.WriteLine($"OddMax={oddMax:f2},");
    }
    else
    {
        Console.WriteLine($"OddSum={oddSum:f2},");
        Console.WriteLine("OddMin=No,");
        Console.WriteLine("OddMax=No,");
    }
    if (evenSum != 0)
    {
        Console.WriteLine($"EvenSum={evenSum:f2},");
        Console.WriteLine($"EvenMin={evenMin:f2},");
        Console.WriteLine($"EvenMax={evenMax:f2}");
    }
    else
    {
        Console.WriteLine($"EvenSum={evenSum:f2},");
        Console.WriteLine("EvenMin=No,");
        Console.WriteLine("EvenMax=No");
    }
}
}
}
