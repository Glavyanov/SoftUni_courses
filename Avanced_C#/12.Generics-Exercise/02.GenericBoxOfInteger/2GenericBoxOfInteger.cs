using System;
using System.Collections.Generic;

namespace _02.GenericBoxOfInteger
{
    public class GenericBoxOfInteger
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxs = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                boxs.Add(box);

            }

            foreach (var box in boxs)
            {
                Console.WriteLine(box);
            }
        }
    }
}
