using System;

namespace _005Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string output = string.Empty;
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input[0] == '2')
                {
                    if (input == "2")
                    {
                        output += 'a';
                    }
                    else if (input == "22")
                    {
                        output += 'b';
                    }
                    else if(input == "222")
                    {
                        output += 'c';
                    }

                }
                else if (input[0] == '3')
                {
                    if (input == "3")
                    {
                        output += 'd';
                    }
                    else if (input == "33")
                    {
                        output += 'e';
                    }
                    else if (input == "333")
                    {
                        output += 'f';
                    }
                }
                else if (input[0] == '4')
                {
                    if (input == "4")
                    {
                        output += 'g';
                    }
                    else if (input == "44")
                    {
                        output += 'h';
                    }
                    else if (input == "444")
                    {
                        output += 'i';
                    }
                }
                else if (input[0] == '5')
                {
                    if (input == "5")
                    {
                        output += 'j';
                    }
                    else if (input == "55")
                    {
                        output += 'k';
                    }
                    else if (input == "555")
                    {
                        output += 'l';
                    }
                }
                else if (input[0] == '6')
                {
                    if (input == "6")
                    {
                        output += 'm';
                    }
                    else if (input == "66")
                    {
                        output += 'n';
                    }
                    else if (input == "666")
                    {
                        output += 'o';
                    }
                }
                else if (input[0] == '7')
                {
                    if (input == "7")
                    {
                        output += 'p';
                    }
                    else if (input == "77")
                    {
                        output += 'q';
                    }
                    else if (input == "777")
                    {
                        output += 'r';
                    }
                    else if (input == "7777")
                    {
                        output += 's';
                    }
                }
                else if (input[0] == '8')
                {
                    if (input == "8")
                    {
                        output += 't';
                    }
                    else if (input == "88")
                    {
                        output += 'u';
                    }
                    else if (input == "888")
                    {
                        output += 'v';
                    }
                }
                else if (input[0] == '9')
                {
                    if (input == "9")
                    {
                        output += 'w';
                    }
                    else if (input == "99")
                    {
                        output += 'x';
                    }
                    else if (input == "999")
                    {
                        output += 'y';
                    }
                    else if (input == "9999")
                    {
                        output += 'z';
                    }
                }
                else if(input[0] == '0')
                {
                    if (input == "0")
                    {
                        output += ' ';
                    }
                    else if (input == "00")
                    {
                        output += "  ";
                    }
                    else if (input == "000")
                    {
                        output += "   ";
                    }
                }

            }
            Console.WriteLine(output);
        }
    }
}
