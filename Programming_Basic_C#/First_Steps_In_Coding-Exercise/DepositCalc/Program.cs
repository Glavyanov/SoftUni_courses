using System;

namespace DepositCalc
{
class Program
{
static void Main(string[] args)
{
    double depositSum = double.Parse(Console.ReadLine());
    int range = int.Parse(Console.ReadLine());
    double percentPerYear = double.Parse(Console.ReadLine());

    double rate = percentPerYear / 100;
    double calcRate = depositSum * rate;
    double calcRatePerMonth = calcRate / 12;
    Console.WriteLine(depositSum + (range * calcRatePerMonth));

}
}
}
