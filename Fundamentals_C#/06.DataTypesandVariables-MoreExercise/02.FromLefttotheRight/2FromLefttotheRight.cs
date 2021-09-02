using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace _02FromLefttotheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string numbers = Console.ReadLine();
                string leftSum = string.Empty;
                string rightSum = string.Empty;
                int startRightSum = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == ' ')
                    {
                        startRightSum = j + 1 ;
                        break;
                    }
                    leftSum += numbers[j];

                }

                for (int k = startRightSum; k < numbers.Length; k++)
                {
                    rightSum += numbers[k];

                }
                long leftNumber = long.Parse(leftSum);
                long rightNumber = long.Parse(rightSum);
                long maxNumber = Math.Max(leftNumber, rightNumber);
                long sum = 0;
                while (Math.Abs(maxNumber) > 0)
                {
                    sum += maxNumber % 10;
                    maxNumber /= 10;
                }
                Console.WriteLine(Math.Abs(sum));


            }
            

            
        }
    }
}
