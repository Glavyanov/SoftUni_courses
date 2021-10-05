using System;

namespace _01.WorldTour
{
    class WorldTour
    {
        static void Main(string[] args)
        {
            string allStops = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] cmdArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string text = cmdArgs[2];
                    if (index > -1 && index < allStops.Length)
                    {
                        allStops = allStops.Insert(index, text);
                    }
                    Console.WriteLine(allStops);

                }
                else if (action == "Remove Stop")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int end = int.Parse(cmdArgs[2]);
                    if ((start > -1 && start < allStops.Length) && (end > -1 && end < allStops.Length))
                    {
                        if (start > end)
                        {
                            int temp = end;
                            end = start;
                            start = temp;
                        }
                        allStops = allStops.Remove(start, end - start + 1);

                    }
                    Console.WriteLine(allStops);

                }
                else if (action == "Switch")
                {
                    string oldText = cmdArgs[1];
                    string @newText = cmdArgs[2];
                    allStops = allStops.Replace(oldText, @newText);
                    Console.WriteLine(allStops);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {allStops}");
        }
    }
}
