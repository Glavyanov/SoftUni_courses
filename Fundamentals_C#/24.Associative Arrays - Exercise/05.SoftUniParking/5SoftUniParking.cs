using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var logger = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = input[0];
                if (action == "register")
                {
                    string user = input[1];
                    string plate = input[2];
                    if (!logger.ContainsKey(user))
                    {
                        logger.Add(user, plate);
                        Console.WriteLine($"{user} registered {plate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {logger[user]}");
                    }

                }
                else if (action == "unregister")
                {
                    string user = input[1];

                    if (!logger.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        logger.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }

            }
            foreach (var item in logger)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
