using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            string pattern = @"^>>(?<name>[a-zA-Z]+)<<(?<price>[0-9]+\.?[0-9]+)!(?<quan>[0-9]+)";
            while (input != "Purchase")
            {
                
                Match validItem = Regex.Match(input, pattern);
                if (validItem.Success)
                {
                    sb.Append(input);
                    sb.Append(" ");
                    
                }

                input = Console.ReadLine();
            }
            MatchCollection items = Regex.Matches(sb.ToString(), @">>(?<name>[a-zA-Z]+)<<(?<price>[0-9]+\.?[0-9]+)!(?<quan>[0-9]+)");
            decimal money = 0M;
            Console.WriteLine("Bought furniture:");
            foreach (Match item in items)
            {
                Console.WriteLine(item.Groups["name"].Value);
                decimal price = decimal.Parse(item.Groups["price"].Value);
                int quan = int.Parse(item.Groups["quan"].Value);
                money += (price * quan);
            }

            Console.WriteLine($"Total money spend: {money:F2}");
        }
    }
}
