using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, SortedSet<string>>> logger = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vLoggerName = cmdArgs[0];
                string action = cmdArgs[1];
                if (action == "joined")
                {
                    if (!logger.ContainsKey(vLoggerName))
                    {
                        logger.Add(vLoggerName, new Dictionary<string, SortedSet<string>>());
                        logger[vLoggerName].Add("followers", new SortedSet<string>());
                        logger[vLoggerName].Add("following", new SortedSet<string>());
                    }
                }
                else if (action == "followed")
                {
                    string followName = cmdArgs[2];
                    if (!logger.ContainsKey(vLoggerName) || !logger.ContainsKey(followName) || vLoggerName == followName)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    logger[followName]["followers"].Add(vLoggerName);
                    logger[vLoggerName]["following"].Add(followName);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {logger.Count} vloggers in its logs.");
            int counter = 0;

            foreach (var (name, action) in logger.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{++counter}. {name} : {action["followers"].Count} followers, {action["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var item in action["followers"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
            }
            
        }
    }
}
