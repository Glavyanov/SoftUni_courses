using System;

namespace ProjectCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"The architect {name} will need {number * 3} hours to complete {number} project/s.");
        }
    }
}
