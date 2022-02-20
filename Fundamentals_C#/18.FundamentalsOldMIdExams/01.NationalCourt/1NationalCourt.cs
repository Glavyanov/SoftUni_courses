using System;

namespace _01.NationalCourt
{
    class NationalCourt
    {
        static void Main(string[] args)
        {
            int firstWorker = int.Parse(Console.ReadLine());
            int secondWorker = int.Parse(Console.ReadLine());
            int thirdWorker = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            int count = 0;
            int countOver = 0;

            while (people > 0)
            {
                if (count == 3)
                {
                    count = 0;
                    countOver++;
                    continue;
                }
                people -= firstWorker + secondWorker + thirdWorker;
                count++;
                countOver++;

            }
            Console.WriteLine("Time needed: {0}h.", countOver);

        }
    }
}
