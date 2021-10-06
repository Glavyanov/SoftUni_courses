using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenTime = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> input = new Queue<string>();
            int counterPass = 0;
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                input.Enqueue(command);

            }
            Queue<string> cars = new Queue<string>();
            while (input.Count != 0)
            {
                string current = input.Peek();
                if (current == "green")
                {
                    input.Dequeue();
                    int currentFreeWindow = freeWindow;
                    int currentGreenTime = greenTime;
                    bool IsUsefreeWindow = false;
                    while (cars.Count != 0)
                    {
                        string currentCar = cars.Dequeue();
                        if (IsUsefreeWindow && currentCar.Length > currentFreeWindow)
                        {
                            cars.Enqueue(currentCar);
                            break;
                        }
                        for (int i = 0; i < currentCar.Length; i++)
                        {
                            char currentCh = currentCar[i];
                            currentGreenTime--;
                            if (IsUsefreeWindow)
                            {
                                currentFreeWindow--;
                            }
                            if (currentGreenTime == 0)
                            {
                                currentGreenTime += currentFreeWindow;
                                IsUsefreeWindow = true;
                            }
                            
                            if (currentGreenTime < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}{currentCar} was hit at {currentCh}.");
                                return;
                            }

                        }
                        if (currentGreenTime >= 0)
                        {
                            counterPass++;
                        }

                    }

                }
                else
                {
                    cars.Enqueue(input.Dequeue());
                }

            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counterPass} total cars passed the crossroads.");

        }
    }
}
