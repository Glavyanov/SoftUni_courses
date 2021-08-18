using System;

namespace fishTank
{
class fishTank
{
static void Main(string[] args)
{
    int lenght = int.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());
    int width = int.Parse(Console.ReadLine());
    double percent = double.Parse(Console.ReadLine());
    int volume = lenght * height * width;
    double liters = volume * 0.001;
    double receivedPercent = percent * 0.01;
    double realLiters = liters * (1 - receivedPercent);
    Console.WriteLine($"{realLiters:f5}");
}
}
}
