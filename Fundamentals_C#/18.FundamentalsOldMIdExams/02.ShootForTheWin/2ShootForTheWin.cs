using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class ShootForTheWin
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            string command = Console.ReadLine();
            int count = 0;
            while (command!= "End")
            {
                int index = int.Parse(command);
                if (index >=0 && index < targets.Length)
                {
                    if (targets[index] != -1)
                    {
                        int temp = targets[index];
                        targets[index] = -1;
                        count++;
                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i] != -1)
                            {
                                if (targets[i] > temp)
                                {
                                    targets[i] -= temp;

                                }
                                else
                                {
                                    targets[i] += temp;

                                }

                            }

                        }

                    }

                }

                command = Console.ReadLine();

            }
            Console.WriteLine($"Shot targets: {count} -> {string.Join(' ', targets)}");
        }
    }
}
