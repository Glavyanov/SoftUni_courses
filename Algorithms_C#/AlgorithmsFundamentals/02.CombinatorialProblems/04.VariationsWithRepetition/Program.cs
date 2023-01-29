using System;

namespace _04.VariationsWithRepetition
{
    public class Program
    {
        private static string[] input;

        private static string[] output;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            output = new string[int.Parse(Console.ReadLine())];

            VariationWithRepetition(0);
        }
        private static void VariationWithRepetition(int index)
        {
            if (index >= output.Length)
            {
                Console.WriteLine(string.Join(' ', output));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                output[index] = input[i];
                VariationWithRepetition(index + 1);
            }
        }
    }
}
