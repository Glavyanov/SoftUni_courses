using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while(command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    int num = int.Parse(command[1]);
                    numbers.RemoveAll(x => x == num);
                }
                else if (command[0] == "Insert")
                {
                    int num = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, num);

                }

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }
                    Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
