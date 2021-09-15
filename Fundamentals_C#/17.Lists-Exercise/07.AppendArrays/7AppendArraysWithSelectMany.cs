using System;
using System.Collections.Generic;
using System.Linq;

namespace _07AppendArrays
{
    class AppendArrays
    {

        static void Main(string[] args)
        {
            
             Console.WriteLine(string.Join(" ", Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().SelectMany(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList())));
            
        }
        
    }
}
