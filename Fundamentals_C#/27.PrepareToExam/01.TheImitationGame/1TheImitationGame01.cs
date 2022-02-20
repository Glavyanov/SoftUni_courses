using System;
using System.Text;

namespace _01.TheImitationGame
{
    class TheImitationGame
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Decode")
            {
                string[] cmdArgs = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "ChangeAll")
                {
                    string oldText = cmdArgs[1];
                    string acceptText = cmdArgs[2];
                    input = input.Replace(oldText, acceptText);

                }
                else if (action == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string text = cmdArgs[2];
                    input = input.Insert(index, text);

                }
                else if (action == "Move")
                {
                    int count = int.Parse(cmdArgs[1]);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < count; i++)
                    {
                        sb.Append(input[i]);
                    }
                    input = input.Remove(0, count);
                    input = input.Insert(input.Length, sb.ToString());

                }

                command = Console.ReadLine();
            }
            Console.WriteLine("The decrypted message is: {0}", input);
        }
    }
}
