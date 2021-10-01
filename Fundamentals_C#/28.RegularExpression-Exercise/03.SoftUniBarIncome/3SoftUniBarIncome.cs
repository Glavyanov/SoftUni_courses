using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^%(?<name>[A-Z][a-z]+)%(.*[^$%|.]+)?<(?<product>\w+)>(.*[^$%|.]+)?\|(?<quan>[0-9]+)\|(.*[^$%|.0123456789]+)?(?<price>[0-9]+.?[0-9]+)\$$";
            decimal income = 0M;
            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string name = match.Groups["name"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["quan"].Value);
                decimal price = decimal.Parse(match.Groups["price"].Value);
                decimal total = (quantity * 1.0M) * price;
                income += total;
                Console.WriteLine($"{name}: {product} - {total:F2}");

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
