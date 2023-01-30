using System;

namespace _05.CombinationsWithoutRepetition
{
    internal class CombinationsWithoutRepetition
    {
        private static string[] elements;

        private static string[] result;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int k = int.Parse(Console.ReadLine());
            result = new string[k];

            CombinationsWORepeat(0, 0);
        }

        private static void CombinationsWORepeat(int index, int start)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                result[index] = elements[i];
                CombinationsWORepeat(index + 1, i + 1);
            }
        }
    }
}
