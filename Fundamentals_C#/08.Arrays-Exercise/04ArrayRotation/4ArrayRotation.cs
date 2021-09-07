using System;
using System.Linq;

namespace _04ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            string[] arrInput = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i<n ;i++ )
            {
                string firtsNum = "";
                firtsNum= arrInput[0];
                for (int j = 0; j < arrInput.Length-1; j++)
                {
                    arrInput[j] = arrInput[j + 1];
                }
                arrInput[arrInput.Length - 1] = firtsNum;
            }
            Console.WriteLine(string.Join(" ",arrInput));
        }

    }
}
