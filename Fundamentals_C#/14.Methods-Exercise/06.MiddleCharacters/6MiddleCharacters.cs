using System;

namespace _06MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            if (input.Length % 2 == 0)
            {
                MiddleCharsFromTextEven(input);
            }                                  
            else                               
            {                                  
                MiddleCharsFromTextOdd(input); 
            }
        }

        private static void MiddleCharsFromTextOdd(string text)
        {
            int index = text.Length / 2;
            string result = text.Substring(index, 1);
            Console.WriteLine(result);
            
        }

        private static void MiddleCharsFromTextEven(string text)
        {
            int index = text.Length / 2;
            string result = text.Substring(index-1, 2);
            Console.WriteLine(result);
        }

      
    }
}
