using System;
using System.Linq;

namespace _004ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pass = string.Join("", input.Reverse());
            Console.WriteLine(pass);
            //string input = Console.ReadLine();
            //string output = string.Empty;
            //for (int i = input.Length-1; i >= 0; i--)
            //{
            //    output += input[i];
            //}
            //Console.WriteLine(output);
        }
    }
}
