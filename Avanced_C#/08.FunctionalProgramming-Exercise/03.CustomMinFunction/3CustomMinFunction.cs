using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            Func<List<int>, int> func = f => 
            {
                int res;
                f.Sort();
                res = f.FirstOrDefault();
                return res;
            };
            Console.WriteLine(func(numbers));
        }
        
    }
    
}
