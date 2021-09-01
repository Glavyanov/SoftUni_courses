using System;
using System.Numerics;

namespace _11Snowballs
{
    class Snowballs
    {
        static void Main(string[] args)
        {

            int countSnowballs = int.Parse(Console.ReadLine());
            int maxSize = int.MinValue;
            int maxTime = int.MinValue;
            BigInteger maxResult = int.MinValue;
            int maxQuality = int.MinValue;
            for (int i = 0; i < countSnowballs; i++)
            {
                int size = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());
                BigInteger result = BigInteger.Pow(size / time, quality); 

                if (result >= maxResult)
                {
                    maxResult = result;
                    maxTime = time;
                    maxSize = size;
                    maxQuality = quality;
                }

            }
            Console.WriteLine($"{maxSize} : {maxTime} = {maxResult} ({maxQuality})");


        }
    }
}
