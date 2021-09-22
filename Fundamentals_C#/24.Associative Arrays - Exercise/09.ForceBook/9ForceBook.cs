using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> sideAndUsers = new Dictionary<string, List<string>>();
           
            while (command != "Lumpawaroo")
            {
                if (command.Contains(" | "))
                {
                    string[] cmdArgs = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = cmdArgs[0];
                    string user = cmdArgs[1];
                    if (!sideAndUsers.ContainsKey(side))
                    {
                        if (!sideAndUsers.Any(x => x.Value.Contains(user)))
                        {
                            sideAndUsers[side] = new List<string>();
                            sideAndUsers[side].Add(user);
                        }
                       
                    }
                    else
                    {
                        if (!sideAndUsers.Any(x => x.Value.Contains(user)))
                        {
                            sideAndUsers[side].Add(user);
                        }
                    }

                }
                else if (command.Contains(" -> "))
                {
                    string[] cmdArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user = cmdArgs[0];
                    string side = cmdArgs[1];
                    if (!sideAndUsers.ContainsKey(side))
                    {
                        if (!sideAndUsers.Any(x => x.Value.Contains(user)))
                        {
                            sideAndUsers[side] = new List<string>();
                            sideAndUsers[side].Add(user);
                            JoinsTheSide(user, side);

                        }
                        else
                        {
                            if (string.Join("", sideAndUsers.Where(y => y.Value.Contains(user)).Select(x => x.Key)) != side)
                            {
                                if (sideAndUsers.Values.Any(x => x.Contains(user)))
                                {
                                    string sideToSubtract = string
                                                             .Join("", sideAndUsers.Where(x => x.Value.Contains(user))
                                                             .Select(x => x.Key));
                                    sideAndUsers[sideToSubtract].Remove(user);
                                }

                            }
                            sideAndUsers[side] = new List<string>();
                            sideAndUsers[side].Add(user);
                            JoinsTheSide(user, side);

                        }

                    }
                    else
                    {
                        if (!sideAndUsers[side].Any(x => x == user))
                        {
                            if (string.Join("", sideAndUsers.Where(y => y.Value.Contains(user)).Select(x => x.Key)) != side)
                            {
                                if (sideAndUsers.Values.Any(x => x.Contains(user)))
                                {
                                    string sideToSubtract = string
                                                             .Join("", sideAndUsers.Where(x => x.Value.Contains(user))
                                                             .Select(x => x.Key));
                                    sideAndUsers[sideToSubtract].Remove(user);
                                }

                            }
                            sideAndUsers[side].Add(user);
                            JoinsTheSide(user, side);
                        }

                    }
                }

                command = Console.ReadLine();
            }
            foreach (var (side, user) in sideAndUsers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (user.Count > 0)
                {
                    Console.WriteLine($"Side: {side}, Members: {user.Count}");

                }

                foreach (var item in user.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }

            }
        }

        public static void JoinsTheSide(string user, string side)
        {
            Console.WriteLine($"{user} joins the {side} side!");
        }
    }
}
