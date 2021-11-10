using System;

namespace _03.Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> stackNums = new MyStack<int>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command
                                  .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Push")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        stackNums.Push(int.Parse(input[i]));
                    }
                }
                else if (input[0] == "Pop")
                {
                    try
                    {
                        stackNums.Pop();
                    }
                    catch (InvalidOperationException excptn)
                    {
                        Console.WriteLine(excptn.Message);
                    }

                }
            }
            foreach (var item in stackNums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(string.Join(Environment.NewLine, stackNums));
        }
    }
}
