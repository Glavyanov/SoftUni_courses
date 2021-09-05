using System;
using System.Linq;

namespace _02.SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);
            int[] arr = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(parser)
                   .ToArray();
            //int[] arr = Console.ReadLine()
            //       .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //       .Select(x =>
            //       {
            //           return Convert.ToInt32(x);
            //       })
            //       .ToArray();
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.Sum());
        }
    }
}
