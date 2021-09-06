using System;
using System.Linq;

namespace Lab02
{
    class Lab002
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0 ;i <arr.Length ;i++ )
            {
                int num = int.Parse(Console.ReadLine());
                arr[i] = num;
            }
            Console.WriteLine(string.Join(" ", arr.Reverse().ToArray()));
            
        }
    }
}
