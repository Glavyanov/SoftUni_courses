using System;
using System.Linq;

namespace _06EqualSum
{
    class EqualSum
    {
        static void Main(string[] args)
        {
            int[] myArr = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            bool flag = true;
            for (int i = 0; i < myArr.Length; i++)
            {
                int rightSum = 0;
                for (int j = i+1; j < myArr.Length; j++)
                {
                    rightSum += myArr[j];
                }
                int leftSum = 0;
                for (int k = i; k > 0 ; k--)
                {
                    leftSum += myArr[k-1];
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine("{0}", i);
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("no");
            }
        }                        
    }
}
