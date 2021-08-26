using System;

namespace FiveTask
{
    class Renovation
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int percentNoPaint = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int volumeToPaint = height * width * 4;
            double realVolume = Math.Ceiling(volumeToPaint - volumeToPaint * (percentNoPaint * 0.01));
            while (command != "Tired!")
            {
                int paintLiters = int.Parse(command);
                realVolume -= paintLiters;
                if (realVolume == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    return;
                }
                else if (realVolume < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(realVolume)} l paint left!");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{realVolume} quadratic m left.");
        }
    }
}
