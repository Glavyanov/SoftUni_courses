using System;

namespace _03CharactersInRange
{
    class CharactersInRange
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            CharactersBetween(first, second);
        }

        private static void CharactersBetween(char one, char two)
        {
            int start = 0;
            int end = 0;
            if (one < two)
            {
                start = one;
                end = two;
            }
            else
            {
                start = two;
                end = one;
            }
            for (int i = start+1; i < end; i++)
            {
                char current = (char)i;
                Console.Write("{0} ", current);
            }
        }
    }
}
