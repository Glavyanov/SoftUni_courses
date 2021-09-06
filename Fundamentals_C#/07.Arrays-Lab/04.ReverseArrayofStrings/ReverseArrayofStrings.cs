using System;
using System.Linq;

namespace _04ReverseArrayofStrings
{
    class ReverseArrayofStrings
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ",Console.ReadLine().Split().Reverse().ToArray()));

        }
    }
}
