using System;

namespace _07ConcatNames
{
    class ConcatNames
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string limit = Console.ReadLine();
            Console.WriteLine($"{name1}{limit}{name2}");
        }
    }
}
