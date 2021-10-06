using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int count = 0;
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        string car;
                        if (cars.TryDequeue(out car))
                        {
                            Console.WriteLine($"{car} passed!");
                            count++;
                        }
                        
                    }
                }
                else
                {
                    cars.Enqueue(command);

                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
