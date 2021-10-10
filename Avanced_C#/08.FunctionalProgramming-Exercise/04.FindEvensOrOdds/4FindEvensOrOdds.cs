using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {

            int[] bounds = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int roof = Math.Abs(bounds[1] - bounds[0]);
            int counter = Math.Min(bounds[0], bounds[1]);
            string giveMe = Console.ReadLine();
            int[] arr = new int[roof + 1];
            for (int i = 0; i < roof + 1; i++)
            {
                arr[i] = counter++;
            }
            Predicate<int> predicate = x => true;
            if (giveMe == "odd")
            {
                predicate = x => x % 2 != 0;

            }
            else if (giveMe == "even")
            {
                predicate = x => x % 2 == 0;

            }
            arr = arr.Where(x => predicate(x)).ToArray();
            Console.WriteLine(string.Join(' ', arr));

        }
    }
}
