using System;

namespace _05Login
{
    class Logon
    {
        static void Main(string[] args)
        {
            
            string userName = Console.ReadLine();
            string nameUser = "";
            for (int i = userName.Length - 1; i >= 0; i--)
            {
                char reverse = userName[i];
                string reverseText = Convert.ToString(reverse);
                nameUser += reverseText;
            }

            for (int i = 1; i <= 4; i++)
            {
                string currentPass = Console.ReadLine();
                if (nameUser == currentPass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                if (i == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    break;
                }
                if (nameUser != currentPass)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

            }
        }
    }
}
