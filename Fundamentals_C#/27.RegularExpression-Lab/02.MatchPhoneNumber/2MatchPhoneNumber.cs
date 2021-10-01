using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MatchCollection validPhones = Regex.Matches(input, @"\+359([ ,-])[2](\1)([0-9]{3}(\1)[0-9]{4})\b");
            var phoneValid = validPhones.Cast<Match>().Select(a => a.Value.Trim()).ToArray();                    
            Console.WriteLine(string.Join(", ", phoneValid));    

        }
    }
}
