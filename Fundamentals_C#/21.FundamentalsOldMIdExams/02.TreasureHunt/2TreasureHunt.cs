using System;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] chest = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();
            string[] newChest = null;
            string[] current = null;

            int countLoot = 0;
            while (command != "Yohoho!")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "Loot")
                {
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        bool flag = true;
                        if (countLoot == 0)
                        {
                            for (int j = 0; j < chest.Length; j++)
                            {
                                if (cmdArgs[i] == chest[j])
                                {
                                    flag = false;
                                    break;
                                }

                            }

                        }
                        else
                        {
                            for (int j = 0; j < newChest.Length; j++)
                            {
                                if (cmdArgs[i] == newChest[j])
                                {
                                    flag = false;
                                    break;
                                }

                            }
                        }
                        if (flag && countLoot == 0)
                        {

                            newChest = new string[chest.Length + 1];
                            for (int k = 0; k <= chest.Length; k++)
                            {
                                if (k == 0)
                                {
                                    newChest[k] = cmdArgs[i];
                                    continue;
                                }
                                newChest[k] = chest[k - 1];
                            }
                            current = new string[newChest.Length];
                            current = newChest;
                            countLoot++;
                        }
                        else if (flag && countLoot > 0)
                        {

                            newChest = new string[current.Length + 1];
                            for (int k = 0; k <= current.Length; k++)
                            {
                                if (k == 0)
                                {
                                    newChest[k] = cmdArgs[i];
                                    continue;
                                }
                                newChest[k] = current[k - 1];
                            }
                            current = newChest;

                        }

                    }

                }
                else if (action == "Drop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (countLoot == 0 && (index >= 0 && index < chest.Length))
                    {
                        string temp = chest[index];
                        for (int i = index; i < chest.Length; i++)
                        {
                            if (i == chest.Length - 1)
                            {
                                chest[i] = temp;
                                break;
                            }
                            chest[i] = chest[i + 1];

                        }

                    }
                    else if (countLoot > 0)
                    {
                        if (index >= 0 && index < newChest.Length)
                        {

                            string temp = newChest[index];
                            for (int i = index; i < newChest.Length; i++)
                            {
                                if (i == newChest.Length - 1)
                                {
                                    newChest[i] = temp;
                                    break;
                                }
                                newChest[i] = newChest[i + 1];

                            }

                        }

                    }

                }
                else if (action == "Steal")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (countLoot == 0)
                    {
                        if (chest.Length > 0)
                        {
                            if (index <= chest.Length)
                            {
                                for (int i = chest.Length - index; i < chest.Length; i++)
                                {
                                    if (i == chest.Length - 1)
                                    {
                                        Console.Write("{0}", chest[i]);
                                    }
                                    else
                                    {
                                        Console.Write("{0}, ", chest[i]);

                                    }
                                }
                                Console.WriteLine();
                                string[] curr = new string[chest.Length];
                                curr = chest;
                                chest = new string[curr.Length - index];
                                for (int i = 0; i <= curr.Length - 1 - index; i++)
                                {
                                    chest[i] = curr[i];
                                }

                            }
                            else
                            {
                                Console.WriteLine(string.Join(", ", chest));
                                chest = new string[0];

                            }

                        }

                    }
                    else if (countLoot > 0)
                    {
                        if (newChest.Length > 0)
                        {
                            if (index <= newChest.Length)
                            {
                                for (int i = newChest.Length - index; i < newChest.Length; i++)
                                {
                                    if (i == newChest.Length - 1)
                                    {
                                        Console.Write("{0}", newChest[i]);

                                    }
                                    else
                                    {
                                        Console.Write("{0}, ", newChest[i]);

                                    }
                                }
                                Console.WriteLine();
                                string[] curr = new string[newChest.Length];
                                curr = newChest;
                                newChest = new string[curr.Length - index];
                                for (int i = 0; i <= curr.Length - 1 - index; i++)
                                {
                                    newChest[i] = curr[i];
                                }

                            }
                            else
                            {
                                Console.WriteLine(string.Join(", ", newChest));
                                newChest = new string[0];

                            }

                        }

                    }

                }
                command = Console.ReadLine();

            }
            if (countLoot == 0 && chest.Length > 0)
            {
                int sum = 0;
                for (int i = 0; i < chest.Length; i++)
                {
                    sum += chest[i].Length;
                }

                double result = sum * 1.0 / chest.Length;
                Console.WriteLine($"Average treasure gain: {result:f2} pirate credits.");

            }
            else if (countLoot > 0 && newChest.Length > 0)
            {
                int sum = 0;
                for (int i = 0; i < newChest.Length; i++)
                {
                    sum += newChest[i].Length;
                }

                double result = sum * 1.0 / newChest.Length;
                Console.WriteLine($"Average treasure gain: {result:f2} pirate credits.");

            }
            else if (countLoot == 0 && chest.Length == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else if (countLoot > 0 && newChest.Length == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            //Console.WriteLine(string.Join(' ', newChest));
        }
    }
}
