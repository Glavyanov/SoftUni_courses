using System;

namespace _06BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOpen = 0;
            int countClosed = 0;
            int count = 0;
            bool flag = true;
            string compare = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                if (text == "(")
                {
                    countOpen++;
                    if (countOpen == 2 && countClosed == 0)
                    {
                        flag = false;
                    }
                    else if (countOpen - countClosed >= 2)
                    {
                        flag = false;
                    }
                }
                else if (text == ")" && countOpen == 0)
                {
                    flag = false;
                }
                else if (text == ")")
                {
                    countClosed++;
                    if (countClosed == 2 && countOpen == 1)
                    {
                        flag = false;
                    }
                    else if (countClosed - countOpen >= 2)
                    {
                        flag = false;
                    }
                    else if (countClosed > countOpen)
                    {
                        flag = false;
                    }
                }
                if (countOpen - countClosed >= 2)
                {
                    flag = false;
                }

            }
            if (flag)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
