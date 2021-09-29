using System;
using System.Text;

namespace _05.DigitsLettersandOther
{
    class DigitsLettersandOther
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder words = new StringBuilder();
            StringBuilder other = new StringBuilder();
            StringBuilder digit = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digit.Append(text[i]);
                }
                else if (char.IsLetter(text[i]))
                {
                  words.Append(text[i]);
                }
                else
                {
                    other.Append(text[i]);
                }
                
            }
            Console.WriteLine(digit);
            Console.WriteLine(words);
            Console.WriteLine(other);
        }
    }
}
