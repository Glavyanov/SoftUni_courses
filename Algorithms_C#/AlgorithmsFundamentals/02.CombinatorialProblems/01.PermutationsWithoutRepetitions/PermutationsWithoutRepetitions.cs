using System;
using System.Linq;

namespace _01.PermutationsWithoutRepetitions
{
    public class PermutationsWithoutRepetitions
    {

        private static string[] items;

        static void Main(string[] args)
        {
            items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Permute(0);

        }

        private static void Permute(int index)
        {
            if (index >= items.Length)
            {
                Console.WriteLine(string.Join(' ', items));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < items.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index, int i)
        {
            (items[index], items[i]) = (items[i], items[index]);
        }

        //private static string[] items;

        //private static string[] result;

        //private static bool[] reserved;

        //static void Main(string[] args)
        //{
        //    items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
        //    result = new string[items.Length];
        //    reserved = new bool[items.Length];

        //    Permute(0);
        //}

        //private static void Permute(int index)
        //{
        //    if (index >= result.Length)
        //    {
        //        Console.WriteLine(string.Join(' ', result));
        //        return;
        //    }

        //    for (int i = 0; i < result.Length; i++)
        //    {
        //        if (!reserved[i])
        //        {
        //            reserved[i] = true;
        //            result[index] = items[i];
        //            Permute(index + 1);

        //            reserved[i] = false;
        //        }
        //    }
        //}

    }
}
