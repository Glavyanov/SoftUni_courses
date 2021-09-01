using System;

namespace _08BeerKegs
{
    class BeerKegs
    {
        static void Main(string[] args)
        {
            int kegs = int.Parse(Console.ReadLine());
            string maxKeg = "";
            decimal maxVolume = 0.0M;
            for (int i = 0; i < kegs; i++)
            {
                string kindKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                uint height = uint.Parse(Console.ReadLine());
                decimal volume = 0.0M;
                volume = (decimal)Math.PI * ((decimal)radius * (decimal)radius) * (decimal)height;
                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    maxKeg = kindKeg;
                }
            }
            Console.WriteLine(maxKeg);
        }
    }
}
