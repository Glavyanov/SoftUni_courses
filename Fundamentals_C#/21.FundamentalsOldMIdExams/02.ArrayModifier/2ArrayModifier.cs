using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayModifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse).
                                       ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];

                if (action == "swap")
                {
                    int index1 = int.Parse(cmdArgs[1]);
                    int index2 = int.Parse(cmdArgs[2]);
                    int temp = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = temp;

                }
                else if (action == "multiply")
                {
                    int index1 = int.Parse(cmdArgs[1]);
                    int index2 = int.Parse(cmdArgs[2]);
                    numbers[index1] = numbers[index1] * numbers[index2];

                }
                else if (action == "decrease")
                {
                    for (int i = 0; i < numbers.Count ; i++)
                    {
                        numbers[i] -= 1;
                    }
                }

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
