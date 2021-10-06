using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);
            while (stack.Count>1)
            {
                int num1 = int.Parse(stack.Pop());
                string symbol = stack.Pop();
                int num2 = int.Parse(stack.Pop());
                if (symbol == "+")
                {
                    stack.Push((num1 + num2).ToString());
                }
                else if (symbol == "-")
                {
                    stack.Push((num1 - num2).ToString());
                }
                
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
