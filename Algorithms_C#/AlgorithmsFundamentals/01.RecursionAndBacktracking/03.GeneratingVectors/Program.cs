using System;

namespace _03.GeneratingVectors
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Gen01(new int[n]);
        }

        private static void Gen01(int[] ints, int index = 0)
        {
            if (index >= ints.Length)
            {
                Console.WriteLine(string.Join(string.Empty, ints));
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                ints[index] = i;
                Gen01(ints, index + 1);
            }

        }
    }
}
