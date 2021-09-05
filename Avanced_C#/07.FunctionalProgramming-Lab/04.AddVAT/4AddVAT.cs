using System;
using System.Linq;

namespace _04.AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {

            Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(double.Parse)
                   .Select(x => x * 1.2)
                   .ToList()
                   .ForEach(x => Console.WriteLine($"{x:F2}"));
                   
        }
    }
}
