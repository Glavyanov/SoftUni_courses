using System;
using System.Linq;

namespace _07MaxSequenceofEqualElements
{
    class MaxSequenceofEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int counter = 0;
            int counterMax = 0;
            int valueMax = 0;
            bool flag = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (i == 0)
                {
                    valueMax = arr[0];
                }
                int current = arr[i];
                for (int k = i + 1; k < arr.Length; k++)
                {
                    int current1 = arr[k];
                    if (!(current == current1))
                    {
                        counter = 0;
                        flag = false;
                        i = k - 1;
                        break;
                    }
                    else
                    {
                        counter++;
                        if (counter > counterMax)
                        {
                            counterMax = counter;
                            valueMax = current;
                        }
                    }
                    if (k == arr.Length - 1)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            for (int i = 0; i <= counterMax; i++)
            {
                Console.Write("{0} ", valueMax);
            }
        }
    }
}
