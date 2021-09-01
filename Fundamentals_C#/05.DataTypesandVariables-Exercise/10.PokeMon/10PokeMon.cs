using System;

namespace _10PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int targetDistance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int currentPokePower = pokePower;
            int count = 0;
            while (targetDistance <= currentPokePower)
            {
                currentPokePower -= targetDistance;
                count++;
                if ((pokePower / 2 )== currentPokePower && exhaustionFactor > 0)
                {
                    currentPokePower /= exhaustionFactor;
                }

            }
            Console.WriteLine(currentPokePower);
            Console.WriteLine(count);
        }
    }
}
