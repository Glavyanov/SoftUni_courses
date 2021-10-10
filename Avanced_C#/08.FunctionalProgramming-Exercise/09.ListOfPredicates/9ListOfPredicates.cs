using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int upperBond = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int[] numbers = new int[upperBond];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }
            Func<int, int[], bool> filter = (x, y) => 
            {
                foreach (var item in y)
                {
                    if (x % item != 0)
                    {
                        return false;
                        break;
                    }
                }
                return true;
            };
            numbers = numbers.Where(x => filter(x, dividers)).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
