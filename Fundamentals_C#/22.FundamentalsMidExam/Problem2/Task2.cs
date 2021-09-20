using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem2
{
    class Task2
    {
        static void Main(string[] args)
        {
            List<string> weapon = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] cmdArgs = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Add")
                {
                    string part = cmdArgs[1];
                    int index = int.Parse(cmdArgs[2]);
                    if (index >= 0 && index < weapon.Count)
                    {
                        weapon.Insert(index, part);
                    }

                }
                else if (action == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if(index >= 0 && index < weapon.Count)
                    {
                        weapon.RemoveAt(index);
                    }

                }
                else if (action == "Check")
                {
                    string position = cmdArgs[1];
                    if (position == "Even")
                    {
                        for (int i = 0; i < weapon.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write("{0} ", weapon[i]);
                            }

                        }
                        Console.WriteLine();

                    }
                    else if (position == "Odd")
                    {
                        for (int i = 0; i < weapon.Count; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write("{0} ", weapon[i]);
                            }

                        }
                        Console.WriteLine();

                    }

                }

                command = Console.ReadLine();
            }
            Console.WriteLine("You crafted {0}!", string.Join("", weapon));
        }
    }
}
