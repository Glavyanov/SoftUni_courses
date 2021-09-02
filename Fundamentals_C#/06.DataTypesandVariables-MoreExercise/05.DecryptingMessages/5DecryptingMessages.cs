using System;

namespace _05DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int countLines = int.Parse(Console.ReadLine());
            string decryptMessage = string.Empty;
            for (int i = 0; i < countLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int currentLetter = letter + key;
                decryptMessage += (char)currentLetter;

            }
            Console.WriteLine(decryptMessage);
        }
    }
}
