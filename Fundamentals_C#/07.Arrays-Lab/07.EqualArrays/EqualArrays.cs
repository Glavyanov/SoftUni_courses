using System;
using System.Linq;

namespace _07EqualArrays
{
    class EqualArrays
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] arr2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sum = 0;
            bool flag = false;
            for (int i = 0; i < arr1.Length; i++)
            {
                int num1 = arr1[i];
                sum += num1;
                int num2 = arr2[i];
                if (num1 != num2)
                {
                    flag = true;
                    sum = i;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Arrays are not identical. Found difference at {0} index", sum);
            }
            else
            {
                Console.WriteLine("Arrays are identical. Sum: {0}", sum);
            }
        }
    }
}
