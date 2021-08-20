using System;

namespace MetricConverter
{
class metricConverter
{
static void Main(string[] args)
{
    double numToChange = double.Parse(Console.ReadLine());
    string units = Console.ReadLine();
    string unitsToResult = Console.ReadLine();
    // 1000 mm   cm100  m1

    if (units == "mm" && unitsToResult == "m")
    {
        Console.WriteLine("{0:f3}", (numToChange / 1000));
    }
    else if (units == "m" && unitsToResult == "mm")
    {
        Console.WriteLine($"{ numToChange * 1000:f3}");
    }
    else if (units == "mm" && unitsToResult == "cm")
    {
        Console.WriteLine($"{ numToChange / 10:f3}");
    }
    else if (units == "cm" && unitsToResult == "mm")
    {
        Console.WriteLine($"{ numToChange * 10:f3}");
    }
    else if (units == "cm" && unitsToResult == "m")
    {
        Console.WriteLine($"{ numToChange / 100:f3}");
    }
    else if (units == "m" && unitsToResult == "cm")
    {
        Console.WriteLine($"{ numToChange * 100:f3}");
    }



}
}
}
