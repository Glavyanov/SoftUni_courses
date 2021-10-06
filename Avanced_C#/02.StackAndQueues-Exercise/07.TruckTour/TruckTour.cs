using System;
using System.Collections.Generic;

namespace _07.TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                string pump = Console.ReadLine();
                pumps.Enqueue(pump);
            }
            int j;
            for (j = 0; j < n; j++)
            {
                bool round = true;
                long totalFuel = 0;
                for (int k = 0; k < n; k++)
                {
                    string[] current = pumps.Peek().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    long fuel = long.Parse(current[0]);
                    long distance = long.Parse(current[1]);
                    fuel += totalFuel;
                    if (fuel < distance)
                    {
                        round = false;
                    }
                    else
                    {
                        totalFuel = fuel - distance;
                    }
                    pumps.Enqueue(pumps.Dequeue());

                }
                if (round)
                {
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());

            }
            Console.WriteLine(j);
        }
    }
}
