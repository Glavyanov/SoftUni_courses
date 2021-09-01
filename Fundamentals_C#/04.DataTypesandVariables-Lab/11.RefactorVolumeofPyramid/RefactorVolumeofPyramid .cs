using System;

namespace _11RefactorVolumeofPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = 0.0D;
            volume = (length * width * height) / 3D;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
