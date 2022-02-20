using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var companies = new Dictionary<string, List<string>>();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string id = cmdArgs[1];
                if (!companies.ContainsKey(name))
                {
                    companies.Add(name, new List<string>() {id});
                }
                else
                {
                    bool flag = true;
                    foreach (var item in companies[name])
                    {
                        if (item == id)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        companies[name].Add(id);

                    }

                }
                command = Console.ReadLine();

            }
            foreach (var item in companies.OrderBy(x=> x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var employee in item.Value)
                {
                    Console.WriteLine($"-- {string.Join("\n", employee)}");
                }
            }
        }
    }
}
