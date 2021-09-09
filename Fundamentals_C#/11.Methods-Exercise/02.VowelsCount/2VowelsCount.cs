using System;

namespace _02VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            VowelsCounting(input);
        }

        private static void VowelsCounting(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                switch (current)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                        count++;
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(count);
        }
    }
}
