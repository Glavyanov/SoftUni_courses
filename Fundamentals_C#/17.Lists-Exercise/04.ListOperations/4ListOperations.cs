using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();
            string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            while(command[0] != "End")
            {
                string action = command[0];
                if (action == "Add")
                {
                    int num = int.Parse(command[1]);
                    numbers.Add(num);

                }
                else if (action == "Remove")
                {
                    int num = int.Parse(command[1]);
                    if (num >= 0 && num < numbers.Count)
                    {
                        numbers.RemoveAt(num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                }
                else if (action == "Insert")
                {
                    int num = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                }
                else if (action == "Shift")
                {
                    if (command[1] == "left")
                    {
                        int num = int.Parse(command[2]);
                        for (int i = 0; i < num; i++)
                        {
                            int current = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(current);

                        }

                    }
                    else if (command[1] == "right")
                    {
                        int num = int.Parse(command[2]);
                        for (int i = 0; i < num; i++)
                        {
                            int current = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, current);

                        }

                    }

                }


                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
