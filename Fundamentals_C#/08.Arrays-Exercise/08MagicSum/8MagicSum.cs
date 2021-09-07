using System;
using System.Linq;

namespace _08MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int magicNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int currentNext = arr[j];
                    if (current + currentNext == magicNum)
                    {
                        Console.WriteLine("{0} {1}", current, currentNext);
                    }

                }

            }
                                
        }
    }
}
