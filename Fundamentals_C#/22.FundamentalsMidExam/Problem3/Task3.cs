using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem3
{
    class Task3
    {
        static void Main(string[] args)
        {
            List<string> logger = new List<string>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "Chat")
                {
                    string element = cmdArgs[1];
                    logger.Add(element);

                }
                else if (action == "Delete")
                {
                    string element = cmdArgs[1];
                    if (logger.Contains(element))
                    {
                        logger.Remove(element);
                    }

                }
                else if (action == "Edit")
                {
                    string elementToEdit = cmdArgs[1];
                    string elementEdited = cmdArgs[2];
                    if (logger.Contains(elementToEdit))
                    {
                        int index = logger.IndexOf(elementToEdit);
                        logger.Remove(elementToEdit);
                        logger.Insert(index, elementEdited);

                    }

                }
                else if (action == "Pin")
                {
                    string element = cmdArgs[1];
                    if (logger.Contains(element))
                    {
                        logger.Remove(element);
                        logger.Add(element);

                    }

                }
                else if (action == "Spam")
                {
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        logger.Add(cmdArgs[i]);
                    }

                }

                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join("\n",logger));
        }
    }
}
