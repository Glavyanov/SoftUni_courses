using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.ManOWar
{
    class ManOWar
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                                          .Split('>', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();
            List<int> warShip = Console.ReadLine()
                                       .Split('>', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "Retire")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Fire")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int damage = int.Parse(cmdArgs[2]);
                    if (index >= 0 && index < warShip.Count)
                    {
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }

                    }

                }
                else if (action == "Defend")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    int damage = int.Parse(cmdArgs[3]);
                    if ((startIndex >= 0 && startIndex < pirateShip.Count) && (endIndex >= 0 && endIndex < pirateShip.Count))
                    {
                        if (startIndex > endIndex)
                        {
                            int temp = startIndex;
                            startIndex = endIndex;
                            endIndex = temp;
                        }
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;

                            }
                        }

                    }

                }
                else if (action == "Repair")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int health = int.Parse(cmdArgs[2]);
                    if (index >= 0 && index < pirateShip.Count)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }

                    }

                }
                else if (action == "Status")
                {
                    int count = 0;
                    double comparison = maxHealth * 0.20;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < comparison)
                        {
                            count++;
                        }

                    }
                    Console.WriteLine("{0} sections need repair.", count);

                }

                command = Console.ReadLine();

            }
            int sumPirateShip = pirateShip.Sum();
            int sumWarShip = warShip.Sum();
            Console.WriteLine("Pirate ship status: {0}", sumPirateShip);
            Console.WriteLine("Warship status: {0}", sumWarShip);
        }
    }
}
