using System;

namespace _07WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            byte nline = byte.Parse(Console.ReadLine());
            int tankCapacity = 0;
            for (byte i = 0; i < nline; i++)
            {
                int quantityOfWater = int.Parse(Console.ReadLine());
                if (quantityOfWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    quantityOfWater = 0;
                }
                tankCapacity += quantityOfWater;
                if (tankCapacity > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    tankCapacity -= quantityOfWater;
                }
            }
            Console.WriteLine(tankCapacity);
        }
    }
}
