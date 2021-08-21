using System;

namespace _03Numbers1NwithStep3
{
    class Numbers1NwithStep3
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++  )
            {
                Console.WriteLine(i);
                i = i + 2;
            }
        }
    }
}
