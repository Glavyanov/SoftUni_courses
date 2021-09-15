using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagon = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int num = int.Parse(command[1]);
                    wagon.Add(num);

                }
                else
                {
                    int num = int.Parse(command[0]);

                    for (int i = 0; i < wagon.Count; i++)
                    {
                        if (maxCapacity - wagon[i] >= num )
                        {
                            wagon[i] += num;
                            break;
                        }
                    }
                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ', wagon));
        }
    }
}
