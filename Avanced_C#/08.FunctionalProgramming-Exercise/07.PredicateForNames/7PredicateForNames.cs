using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> namesUnderN = str => str.Length <= n;
            string[] selectedNames = names.Where(namesUnderN).ToArray();
            selectedNames.ToList().ForEach(Console.WriteLine);
        }
    }
}
