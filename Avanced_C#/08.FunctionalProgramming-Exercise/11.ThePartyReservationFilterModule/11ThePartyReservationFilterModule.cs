using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command;
            List<string> filters = new List<string>();
            while ((command = Console.ReadLine()) != "Print")
            {
                int index = command.IndexOf(';');
                string type = command.Substring(index);
                
                if (filters.Contains(filters.Find(x => x.EndsWith(type))))
                {
                    filters.Remove(filters.Find(x => x.EndsWith(type)));
                }
                else
                {
                    filters.Add(command);
                }

            }
            foreach (var filter in filters)
            {
                string[] filterArgs = filter.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (filterArgs[1] == "Starts with")
                {
                    names = names.Where(x => !x.StartsWith(filterArgs[2])).ToList();
                }
                else if (filterArgs[1] == "Ends with")
                {
                    names = names.Where(x => !x.EndsWith(filterArgs[2])).ToList();

                }
                else if (filterArgs[1] == "Length")
                {
                    names = names.Where(x => x.Length != int.Parse(filterArgs[2])).ToList();

                }
                else if (filterArgs[1] == "Contains")
                {
                    names = names.Where(x => !x.Contains(filterArgs[2])).ToList();
                }

            }
            Console.WriteLine(string.Join(' ', names));
        }
    }
}
