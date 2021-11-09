using System;
using System.Linq;


namespace _02.Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Skip(1)
                                      .ToArray();

            ListyIterator<string> iterator = new ListyIterator<string>(input);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        iterator.Print();

                    }
                    catch (InvalidOperationException excptn)
                    {
                        Console.WriteLine(excptn.Message);
                    }

                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (command == "PrintAll")
                {
                    try
                    {
                        iterator.PrintAll();

                    }
                    catch (InvalidOperationException excptn)
                    {
                        Console.WriteLine(excptn.Message);
                    }
                }

            }
        }
    }
}


