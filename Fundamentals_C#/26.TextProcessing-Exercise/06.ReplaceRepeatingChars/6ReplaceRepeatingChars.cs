using System;

namespace _06.ReplaceRepeatingChars
{
    class ReplaceRepeatingChars
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i-1] == text[i])
                {
                   text = text.Remove(i, 1);
                    i--;
                }

            }
            Console.WriteLine(text);
        }
    }
}
