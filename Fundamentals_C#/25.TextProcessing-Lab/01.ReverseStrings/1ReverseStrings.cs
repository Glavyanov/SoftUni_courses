using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                Console.WriteLine($"{command} = {string.Join("",command.Reverse())}");
            }
        }
    }
}
