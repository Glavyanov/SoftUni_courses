using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CardsGame
{
    class CardsGame
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
            List<int> secondPlayer = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {

                
                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);

                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);

                }
                else
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }
            if (firstPlayer.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
            else if (secondPlayer.Count == 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }

        }
    }
}
