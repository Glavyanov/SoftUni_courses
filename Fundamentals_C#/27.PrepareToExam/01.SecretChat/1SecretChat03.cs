using System;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class SecretChat
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();
            StringBuilder inputSB = new StringBuilder(input);
            while (command != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);
                    inputSB.Insert(index, ' ');
                    Console.WriteLine(inputSB);
                }
                else if (action == "Reverse")
                {
                    string replace = cmdArgs[1];
                    if (inputSB.ToString().Contains(replace))
                    {
                        int index = inputSB.ToString().IndexOf(replace, 0);
                        inputSB.Remove(index, replace.Length);
                        inputSB.Append(string.Join("", replace.Reverse()));
                        Console.WriteLine(inputSB);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (action == "ChangeAll")
                {
                    string replace = cmdArgs[1];
                    string replaced = cmdArgs[2];
                    while (inputSB.ToString().Contains(replace))
                    {
                        int index = inputSB.ToString().IndexOf(replace, 0);
                        inputSB.Remove(index, replace.Length);
                        inputSB.Insert(index, replaced);

                    }
                    Console.WriteLine(inputSB);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {inputSB}");
        }
    }
}
