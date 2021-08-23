using System;

namespace _06Cake
{
    class Cake
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int size = widht * lenght;
            string command = Console.ReadLine();
            while(command != "STOP")
            {
                int pieceCake = int.Parse(command);
                size -= pieceCake;
                if (size <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(size)} pieces more.");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{size} pieces are left.");
        }
    }
}
