using System;

namespace _03.VariationsWithoutRepetitions
{
    public class VariationsWithoutRepetitions
    {
        private static string[] input;

        private static string[] output;

        private static int num;

        private static bool[] used;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            num = int.Parse(Console.ReadLine());

            output = new string[num];

            used = new bool[input.Length];

            VariationWORepetition(0);
        }

        private static void VariationWORepetition(int index)
        {
            if (index >= num)
            {
                Console.WriteLine(string.Join(' ', output));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    output[index] = input[i];
                    VariationWORepetition(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
