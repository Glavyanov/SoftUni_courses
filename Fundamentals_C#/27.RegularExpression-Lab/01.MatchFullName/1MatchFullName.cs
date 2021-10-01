using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection many = Regex.Matches(input, regex);

            foreach (Match item in many)
            {
                Console.Write($"{item.Value} ");
            }
        }
    }
}
