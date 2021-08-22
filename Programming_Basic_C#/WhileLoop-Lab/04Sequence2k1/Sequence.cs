using System;

namespace _04Sequence2k1
{
    class Sequence
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
                i = i * 2;
            }
        }
    }
}
