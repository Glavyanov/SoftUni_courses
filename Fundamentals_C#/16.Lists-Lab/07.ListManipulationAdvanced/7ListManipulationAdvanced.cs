using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string[] command = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool flag = false;
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int num = int.Parse(command[1]);
                    numbers.Add(num);
                    flag = true;

                }
                else if (command[0] == "Remove")
                {
                    int num = int.Parse(command[1]);
                    numbers.Remove(num);
                    flag = true;


                }
                else if (command[0] == "RemoveAt")
                {
                    int num = int.Parse(command[1]);
                    numbers.RemoveAt(num);
                    flag = true;


                }
                else if (command[0] == "Insert")
                {
                    int num = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, num);
                    flag = true;

                }
                else if (command[0] == "Contains")
                {
                    int num = int.Parse(command[1]);
                    bool finded = numbers.Contains(num);
                    if (finded)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    Console.WriteLine(string.Join(' ',numbers.Where(x=> x % 2 == 0)));
                }
                else if (command[0] == "PrintOdd")
                {
                    Console.WriteLine(string.Join(' ', numbers.Where(x => x % 2 != 0)));
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (command[0] == "Filter")
                {
                    string @operator = command[1];
                    int num = int.Parse(command[2]);

                    if (@operator == "<")
                    {
                        Console.WriteLine(string.Join(' ', numbers.Where(x => x < num)));

                    }
                    else if (@operator == ">")
                    {
                        Console.WriteLine(string.Join(' ', numbers.Where(x => x > num)));

                    }
                    else if (@operator == ">=")
                    {
                        Console.WriteLine(string.Join(' ', numbers.Where(x => x >= num)));

                    }
                    else if (@operator == "<=")
                    {
                        Console.WriteLine(string.Join(' ', numbers.Where(x => x <= num)));

                    }

                }

                command = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            if (flag)
            {
                Console.WriteLine(string.Join(' ', numbers));

            }

        }
    }
}
