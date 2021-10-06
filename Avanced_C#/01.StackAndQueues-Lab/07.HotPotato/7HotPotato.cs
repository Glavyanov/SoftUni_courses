using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            Queue<string> persons = new Queue<string>(arr);
            while (persons.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    persons.Enqueue(persons.Dequeue());
                }
                Console.WriteLine($"Removed {persons.Dequeue()}");
            }
            Console.WriteLine($"Last is {persons.Peek()}");
        }
    }
}
