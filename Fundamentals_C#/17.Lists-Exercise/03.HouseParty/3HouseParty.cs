using System;
using System.Collections.Generic;
using System.Linq;

namespace _03HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            for (int i = 0; i < num; i++)
            {
                string[] nameAction = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = nameAction[0];
                string action = nameAction[nameAction.Length - 2];
                if (action == "is")
                {
                    if (names.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        names.Add(name);

                    }
                }
                else if(action == "not")
                {
                    if (!names.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                    {
                        names.Remove(name);

                    }
                }

            }

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
