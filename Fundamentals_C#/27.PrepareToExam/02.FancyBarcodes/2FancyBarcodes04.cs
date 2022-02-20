using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class FancyBarcodes
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^@#+(?<name>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+$");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string accepted = match.Groups["name"].Value;
                    string pattern = @"[0-9]";
                    MatchCollection digits = Regex.Matches(accepted, pattern);
                    StringBuilder number = new StringBuilder();
                    foreach (Match item in digits)
                    {
                        number.Append(item.Value);
                    }
                    if (digits.Count == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {number}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }

            }
        }
    }
}
