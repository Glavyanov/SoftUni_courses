using System;

namespace _003GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyToSpend = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double remaining = moneyToSpend;
            while (command != "Game Time")
            {
                
                bool buy = false;
                bool expensive = false;
                if (command == "OutFall 4") 
                {
                    if (remaining >= 39.99)
                    {
                        remaining -= 39.99;
                        buy = true;
                    }
                    else
                    {
                        expensive = true;
                    }
                    
                }
                else if (command == "CS: OG" )
                {
                    if (remaining >= 15.99)
                    {
                        remaining -= 15.99;
                        buy = true;
                    }
                    else
                    {
                        expensive = true;
                    }
                }
                else if (command == "Zplinter Zell" )
                {
                    if (remaining >= 19.99)
                    {
                        remaining -= 19.99;
                        buy = true;
                    }
                    else
                    {
                        expensive = true;
                    }
                    
                }
                else if (command == "Honored 2" )
                {
                    if (remaining >= 59.99)
                    {
                        remaining -= 59.99;
                        buy = true;
                    }
                    else
                    {
                        expensive = true;
                    }
                    
                }
                else if (command == "RoverWatch" )
                {
                    if (remaining >= 29.99)
                    {
                        remaining -= 29.99;
                        buy = true;
                    }
                    else
                    {
                        expensive = true;
                    }
                    
                }
                else if (command == "RoverWatch Origins Edition" )
                {
                    if (remaining >= 39.99)
                    {
                        remaining -= 39.99;
                        buy = true;
                    }
                    else
                    {
                        expensive = true;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (buy)
                {
                    Console.WriteLine($"Bought {command}");
                }
                if (expensive)
                {
                    Console.WriteLine("Too Expensive");
                }

                command = Console.ReadLine();
                if (remaining == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }
            Console.WriteLine($"Total spent: ${moneyToSpend - remaining:F2}. Remaining: ${remaining:f2}");
        }
    }
}
