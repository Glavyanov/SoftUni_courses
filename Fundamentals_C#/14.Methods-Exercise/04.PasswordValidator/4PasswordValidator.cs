using System;

namespace _04PasswordValidator
{
    class PasswordValidator
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool passValid = PasswordLenght(input) &&            
                             LetterOrDigits(input)&&             
                             ConsistTwoDigits(input);            

            if (passValid)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!PasswordLenght(input))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!LetterOrDigits(input))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!ConsistTwoDigits(input))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }

        }

        private static bool ConsistTwoDigits(string input)
        {
            int count = 0;
            foreach (char i in input)
            {
                if (char.IsDigit(i))
                {
                    count++;
                }
                if (count ==2)
                {
                    return true;
                }
            }
            

            return false;
        }

        private static bool LetterOrDigits(string input)
        {

            foreach (char i in input)
            {
                if (!char.IsLetterOrDigit(i))
                {
                    return false;
                }

            }

            return true;
        }

        private static bool PasswordLenght(string input)
        {
            if (input.Length >=6 && input.Length <=10)
            {
                return true;
            }
            return false;
        }
    }
}
