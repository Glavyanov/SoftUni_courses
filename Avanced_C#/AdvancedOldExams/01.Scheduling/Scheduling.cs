using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Scheduling
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int neededTask = int.Parse(Console.ReadLine());
            while (threads.Count != 0)
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();
                if (currTask == neededTask)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {currTask}{Environment.NewLine}{string.Join(' ',threads)}");
                    return;
                }
                if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
                

            }

        }
    }
}
