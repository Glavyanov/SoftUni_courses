﻿using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            FirstSolution();
            // AnotherSolution();
            
        }

        private static void FirstSolution()
        {
            Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Where(word => char.IsUpper(word[0]))
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));

        }

        private static void AnotherSolution()
        {
            Predicate<string> IsFirstLetterCapital = str => str[0] == str.ToUpper()[0];
            Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Where(x => IsFirstLetterCapital(x))
                   .ToList()
                   .ForEach(x => Console.WriteLine(x));
        }
    }
}
