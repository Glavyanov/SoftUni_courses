using System;

namespace _01.CounterStrike
{
    class CounterStrike
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int countBattle = 0;
            int countWonBattle = 0;
            int currentEnergy = 0;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                currentEnergy = initialEnergy;
                initialEnergy -= distance;
                countBattle++;

                if (initialEnergy < 0)
                {
                    Console.WriteLine("Not enough energy! Game ends with {0} won battles and {1} energy", countWonBattle, currentEnergy);
                    return;
                }
                countWonBattle++;
                if (countBattle == 3)
                {
                    initialEnergy += countWonBattle;
                    countBattle = 0;
                }
                command = Console.ReadLine();

            }
            Console.WriteLine("Won battles: {0}. Energy left: {1}", countWonBattle, initialEnergy);
        }
    }
}
