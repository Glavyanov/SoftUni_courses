using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
