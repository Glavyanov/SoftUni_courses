using System;
using System.Linq;
using System.Text;

namespace _01.PasswordReset
{
    class PasswordReset
    {
        static void Main(string[] args)
        {
            string originPassword = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "TakeOdd")
                {
                    string destilated = TakeOdd(originPassword);
                    originPassword = destilated;
                    Console.WriteLine(originPassword);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);
                    string destilated = Cut(originPassword, index, length);
                    originPassword = destilated;
                    Console.WriteLine(originPassword);


                }
                else if(action == "Substitute")
                {
                    string find = cmdArgs[1];
                    string replace = cmdArgs[2];
                    if (originPassword.Contains(find))
                    {
                        string destilated = originPassword.Replace(find, replace);
                        originPassword = destilated;
                        Console.WriteLine(originPassword);

                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");

                    }
                }

                command = Console.ReadLine();

            }
            Console.WriteLine("Your password is: {0}", originPassword);

        }

        private static string Cut(string originPassword, int index , int count)
        {
            return originPassword.Remove(index, count);

        }

        private static string TakeOdd(string originPassword)
        {
            StringBuilder passNew = new StringBuilder();
            for (int i = 0; i < originPassword.Length; i++)
            {
                if (i % 2 != 0)
                {
                    passNew.Append(originPassword[i]);
                }
            }
            return passNew.ToString();
        }
    }
}
