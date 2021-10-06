using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                                                     .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(int.Parse));
            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0].ToLower() == "add")
                {
                    int num1 = int.Parse(cmdArgs[1]);
                    int num2 = int.Parse(cmdArgs[2]);
                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (cmdArgs[0].ToLower() == "remove")
                {
                    int count = int.Parse(cmdArgs[1]);
                   
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {

                            int result;
                            if (stack.TryPop(out result))
                            {
                                
                            }
                        }
                    }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
