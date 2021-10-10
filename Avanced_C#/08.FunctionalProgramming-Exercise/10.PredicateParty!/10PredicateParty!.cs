using System;
using System.Collections.Generic;
using System.Linq;


namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "Remove")
                {
                    Func<string, string, bool> startsWith = (x, y) => !x.StartsWith(y);
                    Func<string, string, bool> endsWith = (x, y) => !x.EndsWith(y);
                    Func<string, int, bool> length = (x, y) => x.Length != y;
                    names = cmdArgs[1] == "StartsWith" ? names = names.Where(x => startsWith(x, cmdArgs[2])).ToList() :
                            cmdArgs[1] == "EndsWith" ? names = names.Where(x => endsWith(x, cmdArgs[2])).ToList() :
                            cmdArgs[1] == "Length" ? names = names.Where(x => length(x, int.Parse(cmdArgs[2]))).ToList() :
                            names = names.Where(x => true).ToList();
                }
                else if (cmdArgs[0] == "Double")
                {
                    Func<string, string, List<string>, List<string>> operationDouble = (x, y, z) =>
                    {
                        List<string> result = new List<string>();
                        if (x == "StartsWith")
                        {
                            foreach (var item in z)
                            {
                                result.Add(item);
                                if (item.StartsWith(y))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                        else if (x == "EndsWith")
                        {
                            foreach (var item in z)
                            {
                                result.Add(item);
                                if (item.EndsWith(y))
                                {
                                    result.Add(item);
                                }
                            }
                        }
                        else if (x == "Length")
                        {
                            int length = int.Parse(y);
                            foreach (var item in z)
                            {
                                result.Add(item);
                                if (item.Length == length)
                                {
                                    result.Add(item);
                                }
                            }
                        }
                        return result;
                    };
                    names = operationDouble(cmdArgs[1], cmdArgs[2], names);
                }

            }
            if (names.Count == 0)
            {
                names.Add("Nobody is going to the party!");
            }
            else
            {
                names[names.Count - 1] = $"{names[names.Count - 1]} are going to the party!";
            }
            Console.WriteLine(string.Join(", ",names));
                   
        }
    }
}
