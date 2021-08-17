using System;

namespace Concatenate
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            string LastName = Console.ReadLine();
            int Age = int.Parse(Console.ReadLine());
            string Town = Console.ReadLine();
            Console.WriteLine($"You are " + Name + " " + LastName + ", a " + Age + "-years old person from " + Town + ".");

        }
    }
}