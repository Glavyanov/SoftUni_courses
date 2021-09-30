using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace _08.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            string name = "A12b";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 1000001; i++)
            {
                builder.Append(name);
                builder.Append(" ");
            }
            ;
            string[] letterNumber = builder.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<decimal> allresults = new List<decimal>();
            watch.Start();
            for (int i = 0; i < letterNumber.Length; i++)
            {
                StringBuilder textToNumber = new StringBuilder();
                decimal result = 0M;
                string current = letterNumber[i];
                char first = current[0];
                char last = current[current.Length - 1];
                for (int j = 1; j < current.Length - 1; j++)
                {
                    textToNumber.Append(current[j]);
                }
                ulong number = ulong.Parse(textToNumber.ToString());
                if (first > 64 && first < 91)
                {
                    int firstNumber = (int)first - 64;   //UpperCaseFirst
                    result += (number* 1.0M / firstNumber);

                }
                else if (first > 96 && first < 123)
                {
                    int firstNumber = (int)first - 96;   //LowerCaseFirst
                    result += (number * (ulong)firstNumber);

                }
                if (last > 64 && last < 91)
                {
                    int lastNumber = (int)last - 64;   //UpperCaselast
                    result -= lastNumber;

                }
                else if (last > 96 && last < 123)
                {
                    int lastNumber = (int)last - 96;   //LowerCaselast
                    result += lastNumber;

                }
                allresults.Add(result);

            }
            decimal total = allresults.Sum();
            watch.Stop();
            Console.WriteLine($"{total:F2}");
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
