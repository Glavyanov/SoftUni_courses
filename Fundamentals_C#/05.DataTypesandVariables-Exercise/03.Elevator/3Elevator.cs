using System;

namespace _03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)countPeople / capacity);
            Console.WriteLine(courses);
        }
    }
}
