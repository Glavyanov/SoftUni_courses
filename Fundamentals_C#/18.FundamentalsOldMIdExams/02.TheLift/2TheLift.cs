using System;
using System.Linq;

namespace _02.TheLift
{
    class TheLift
    {
        static void Main(string[] args)
        {
            int queue = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            for (int i = 0; i < lift.Length; i++)
            {
                while (lift[i] != 4)
                {
                    if (queue > 0)
                    {
                        lift[i]++;
                        queue--;

                    }
                    if (queue <= 0)
                    {
                        if (lift[i] < 4)
                        {
                            Console.WriteLine("The lift has empty spots!");
                            Console.WriteLine(string.Join(" ", lift));
                            return;
                        }

                    }

                }

            }
            if (queue > 0)
            {
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));

            }
            else
            {
                Console.WriteLine(string.Join(" ", lift));

            }
        }
    }
}
