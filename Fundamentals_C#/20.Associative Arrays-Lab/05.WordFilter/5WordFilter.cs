using System;
using System.Linq;

namespace _05.WordFilter
{
    class WordFilter
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(x=> 
            x.Length %2 == 0 ).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
