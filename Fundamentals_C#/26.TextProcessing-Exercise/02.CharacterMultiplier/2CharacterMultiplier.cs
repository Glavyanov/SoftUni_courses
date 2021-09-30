using System;
using System.Linq;
using System.Numerics;

namespace _02.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string str1 = input[0];
            string str2 = input[1];
            CharMultiplier(str1, str2);
        }

        private static void CharMultiplier(string str1, string str2)
        {
            ulong sum = 0UL;
            if (str1.Length > str2.Length)
            {
                int count = 0;
                for (int i = 0; i < str2.Length; i++)
                {
                    sum += (ulong)(str1[i] * str2[i]);
                    count++;
                }
                for (int j = count; j < str1.Length; j++)
                {
                    sum += str1[j];
                }


            }
            else if (str1.Length < str2.Length)
            {
                int count = 0;
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += (ulong)(str1[i] * str2[i]);
                    count++;
                }
                for (int j = count; j < str2.Length; j++)
                {
                    sum += str2[j];
                }

            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += (ulong)(str1[i] * str2[i]);

                }

            }
            Console.WriteLine(sum);

        }
    }
}
