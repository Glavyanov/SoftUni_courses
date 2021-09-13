using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ListManipulationBasics
{
    class ListManipulationBasics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string[] command = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int num = int.Parse(command[1]);
                    numbers.Add(num);

                }
                else if (command[0] == "Remove")
                {
                    int num = int.Parse(command[1]);
                    numbers.Remove(num);

                }
                else if (command[0] == "RemoveAt")
                {
                    int num = int.Parse(command[1]);
                    numbers.RemoveAt(num);

                }
                else if (command[0] == "Insert")
                {
                    int num = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, num);
                }

                command = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ',numbers));

        }
    }
}
