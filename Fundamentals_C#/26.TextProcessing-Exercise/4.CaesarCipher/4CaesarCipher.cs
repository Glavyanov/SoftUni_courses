using System;

namespace _4.CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write((char)(input[i]+3));

            }
        }
    }
}
