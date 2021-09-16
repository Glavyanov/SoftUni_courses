using System;
using System.Linq;
using System.Collections.Generic;

namespace _222CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            double leftSum = 0;
            for (int i = 0; i < nums.Count/2; i++)
            {
                if (nums[i] == 0)
                {
                    leftSum *= 0.80;
                    continue;
                }
                leftSum += nums[i];

            }
            double rightSum = 0;
            for (int j = nums.Count-1 ; j > nums.Count / 2; j--)
            {
                if (nums[j] == 0)
                {
                    rightSum *= 0.80;
                    continue;
                }
                rightSum += nums[j];
                    
            }
            if (leftSum < rightSum)
            {
                Console.WriteLine("The winner is left with total time: {0:0.##}",leftSum);
            }
            else if (rightSum < leftSum)
            {
                Console.WriteLine("The winner is right with total time: {0:0.##}", rightSum);
            }

        }
    }
}
