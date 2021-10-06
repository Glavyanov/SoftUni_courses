using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            bool havecommand = false;
            for (int i = 0; i < n; i++)
            {
                string[] cmdArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArr[0] == "1")
                {
                    text.Append(cmdArr[1]);
                    stack.Push(text.ToString());
                    havecommand = true;
                }
                else if (cmdArr[0] == "2")
                {
                    int count = int.Parse(cmdArr[1]);
                    text.Remove(text.Length - count, count);
                    stack.Push(text.ToString());
                    havecommand = true;

                }
                else if (cmdArr[0] == "3")
                {
                    int index = int.Parse(cmdArr[1]);
                    if (index >= 0 && index <= text.Length)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (cmdArr[0] == "4")
                {
                    text = new StringBuilder();
                    if (stack.Any())
                    {
                        if (havecommand)
                        {
                            stack.Pop();
                            havecommand = false;
                        }
                        text.Append(stack.Pop());

                    }

                }

            }
        }
    }
}
