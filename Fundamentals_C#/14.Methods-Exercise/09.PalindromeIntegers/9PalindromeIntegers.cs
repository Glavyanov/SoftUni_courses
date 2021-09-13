using System;
using System.Linq;

namespace _09PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            PalindromeString(input);

        }

        private static void PalindromeString(string word)
        {
            while (word != "END")
            {
                bool flag = true;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] != word[word.Length - 1 - i])
                    {
                        flag = false;
                        break;
                    }

                }
                if (flag)
                {
                    Console.WriteLine(flag);
                }
                else
                {
                    Console.WriteLine(flag);
                }
                word = Console.ReadLine();
            }
        }   
        
    }
}
