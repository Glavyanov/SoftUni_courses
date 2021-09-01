using System;

namespace _002EnglishNameoftheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            string result = string.Empty;
            if (num[num.Length-1] == '1')
            {
                result = "one";
            }
            else if (num[num.Length - 1] == '2')
            {
                result = "two";
            }
            else if (num[num.Length - 1] == '3')
            {
                result = "three";
            }
            else if (num[num.Length - 1] == '4')
            {
                result = "four";
            }
            else if (num[num.Length - 1] == '5')
            {
                result = "five";
            }
            else if (num[num.Length - 1] == '6')
            {
                result = "six";
            }
            else if (num[num.Length - 1] == '7')
            {
                result = "seven";
            }
            else if (num[num.Length - 1] == '8')
            {
                result = "eight";
            }
            else if (num[num.Length - 1] == '9')
            {
                result = "nine";
            }
            else if (num[num.Length - 1] == '0')
            {
                result = "zero";
            }
            Console.WriteLine(result);

        }
    }
}
