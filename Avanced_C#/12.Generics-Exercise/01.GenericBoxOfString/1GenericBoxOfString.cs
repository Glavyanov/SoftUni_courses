using System;
using System.Collections.Generic;

namespace _01.GenericBoxOfString
{
    class GenericBoxOfString
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxs = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> single = new Box<string>(input);
                boxs.Add(single);
            }

            foreach (var box in boxs)
            {
                Console.WriteLine(box);
            }
        }

    }
}
