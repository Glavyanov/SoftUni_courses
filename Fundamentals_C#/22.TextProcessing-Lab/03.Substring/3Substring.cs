using System;

namespace _03.Substring
{
    class Substring
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(word))
            {
                int index = text.IndexOf(word);
                text = text.Remove(index, word.Length);

            }
            Console.WriteLine(text);
        }
    }
}
