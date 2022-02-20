using System;
using System.Linq;
using System.Text;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string mail = Console.ReadLine();
            string command = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (command != "Complete")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Make")
                {
                    string @case = cmdArgs[1];
                    if (@case == "Upper")
                    {
                        mail = mail.ToUpper();
                    }
                    else if (@case == "Lower")
                    {
                        mail = mail.ToLower();
                    }
                    Console.WriteLine(mail);

                }
                else if (action == "GetDomain")
                {
                    sb = new StringBuilder();
                    int count = int.Parse(cmdArgs[1]);
                    for (int i = mail.Length - count; i < mail.Length; i++)
                    {
                        sb.Append(mail[i]);
                    }
                    Console.WriteLine(sb);
                }
                else if (action == "GetUsername")
                {
                    if (!mail.Contains('@'))
                    {
                        Console.WriteLine($"The email {mail} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        sb = new StringBuilder();
                        for (int i = 0; i < mail.Length; i++)
                        {
                            if (mail[i] == '@')
                            {
                                break;
                            }
                            sb.Append(mail[i]);
                        }
                        Console.WriteLine(sb);
                    }
                }
                else if (action == "Replace")
                {
                    char replace = char.Parse(cmdArgs[1]);
                    mail = mail.Replace(replace, '-');
                    Console.WriteLine(mail);
                }
                else if (action == "Encrypt")
                {
                    int[] numbers = new int[mail.Length];
                    for (int i = 0; i < mail.Length; i++)
                    {
                        numbers[i] = (int)mail[i];
                    }
                    Console.WriteLine(string.Join(" ",numbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
