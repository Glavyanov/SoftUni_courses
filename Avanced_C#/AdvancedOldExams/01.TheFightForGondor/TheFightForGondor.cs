using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class TheFightForGondor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> plates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int counterWaves = 0;
            int numberOfWaves = n;
            List<int> orcsWin = new List<int>();
            bool gameOver = false;
            while (numberOfWaves != 0)
            {
                numberOfWaves--;
                int[] orcsAssign = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Stack<int> orcs = new Stack<int>();
                for (int i = 0; i < orcsAssign.Length; i++)
                {
                    orcs.Push(orcsAssign[i]);
                }
                counterWaves++;
                if (counterWaves == 3)
                {
                    counterWaves = 0;
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }
                if (!gameOver)
                {
                    while (plates.Count != 0 && orcs.Count != 0)
                    {
                        int plate = plates[0];
                        int orc = orcs.Peek();
                        if (orc < 1)
                        {
                            orcs.Pop();
                            continue;

                        }
                        if (plate == 0)
                        {
                            plates.RemoveAt(0);
                            continue;
                        }
                        if (orc > plate)
                        {
                            orc -= plate;
                            orcs.Pop();
                            orcs.Push(orc);
                            plates.RemoveAt(0);

                        }
                        else if (orc < plate)
                        {
                            plates[0] -= orc;
                            orcs.Pop();

                        }
                        else
                        {
                            plates.RemoveAt(0);
                            orcs.Pop();

                        }

                        if (plates.Count == 0)
                        {
                            while (orcs.Count != 0)
                            {
                                orcsWin.Add(orcs.Pop());
                            }
                            gameOver = true;
                        }
                    }
                }

            }
            if (gameOver)
            {

                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsWin)}");

            }
            else if (orcsWin.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");

            }

        }
    }
}
