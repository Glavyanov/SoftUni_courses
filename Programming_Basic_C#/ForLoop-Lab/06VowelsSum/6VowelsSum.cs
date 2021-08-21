using System;

namespace _06VowelsSum
{
    class VowelsSum
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num5 = 0;
            int num4 = 0;
            for (int i = 0; i <= text.Length - 1; i++)
            {
                if (text[i] == 'a')
                {
                    num1 += 1;
                }
                else if (text[i] == 'e')
                {
                    num2 += 2;
                }
                else if (text[i] == 'i')
                {
                    num3 += 3;
                }
                else if (text[i] == 'o')
                {
                    num4 += 4;
                }
                else if (text[i] == 'u')
                {
                    num5 += 5;
                }
            }
            Console.WriteLine(num1 + num2 + num3 + num4 + num5);
        }
    }
}
