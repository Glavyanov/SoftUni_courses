using System;

namespace _09._Moving
{
class Moving
{
static void Main(string[] args)
{
    int width = int.Parse(Console.ReadLine());
    int lenght = int.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());
    int countBoxes = 0;
    int volume = width * lenght * height;
    int sumBoxes = 0;
    string input = Console.ReadLine();
    while (input != "Done")
    {
        countBoxes = int.Parse(input);
        sumBoxes += countBoxes;
        if (volume <= sumBoxes)
        {
            int needed = Math.Abs(volume - sumBoxes);
            Console.WriteLine($"No more free space! You need {needed} Cubic meters more.");
            break;
        }
        input = Console.ReadLine();
    }
    if (input == "Done")
    {
        Console.WriteLine($"{volume - sumBoxes} Cubic meters left.");
    }
}
}
}
