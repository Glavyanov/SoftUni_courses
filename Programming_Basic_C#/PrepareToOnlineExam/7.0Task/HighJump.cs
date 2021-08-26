using System;

namespace ExtraTask
{
    class HighJumpSuperMess
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int countAll = 0;
            int countFail = 0;
            int wonFailResult = 0;
            int result = 0;
            for (int i = target; i <= target; i++)
            {
                for (int j = target - 30; j <= target + 5;)
                {
                    result = int.Parse(Console.ReadLine());
                    countAll++;
                    if (result > j)
                    {
                        if (j >= target)
                        {
                            wonFailResult = j;
                            break;
                        }
                        j += 5;
                        countFail = 0;
                    }
                    else
                    {
                        countFail++;
                        if (countFail == 3)
                        {
                            wonFailResult = j;
                            break;
                        }
                    }
                }
            }
            if (result > target)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {wonFailResult}cm after {countAll} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir failed at {wonFailResult}cm after {countAll} jumps.");
            }
        }
    }
}
