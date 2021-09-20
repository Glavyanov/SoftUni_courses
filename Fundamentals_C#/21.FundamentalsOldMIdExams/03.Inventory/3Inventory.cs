using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Inventory
{
    class Inventory
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Craft!")
            {
                string[] cmdArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Collect")
                {
                    string item = cmdArgs[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }

                }
                else if (action == "Drop")
                {
                    string item = cmdArgs[1];
                    if (items.Contains(item))
                    {
                        items.RemoveAll(x => x == item);
                    }

                }
                else if (action == "Combine Items")
                {
                    string item = cmdArgs[1];
                    string[] combine = item.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    if (items.Contains(combine[0]))
                    {
                        int index = items.FindIndex(x => x == combine[0]);
                        items.Insert(index + 1, combine[1]);
                        // for (int i = 0; i < items.Count; i++)
                        // {
                        //     if (items[i] == combine[0])            За всеки един елемент от списъка
                        //     {
                        //         items.Insert(i + 1, combine[1]);
                        //     }
                        //
                        // }

                    }
                }
                else if (action == "Renew")
                {
                    string item = cmdArgs[1];
                    if (items.Contains(item))
                    {
                        // for (int i = 0; i < items.Count; i++)
                        // {
                        //     if (items[i] == item)            За всеки един елемент от списъка
                        //     {
                        //     }
                        //
                        // }
                        items.Remove(item);
                        items.Add(item);

                    }

                }


                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(", ", items));
        }
    }
}
