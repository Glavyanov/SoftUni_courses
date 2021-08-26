using System;

namespace _04GiftsfromSanta
{
    class GiftsfromSanta
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            for (int i = m; i >= n; i--)
            {
                if (i == s && s % 2 == 0 && s %3 == 0)
                {
                    break;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
