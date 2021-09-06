using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] nums = Console.ReadLine()
                .Split()
                .Select(double.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                double number = nums[i];
                double roundedNumber = Math.Round(number, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{Convert.ToDecimal(number)} => {Convert.ToDecimal(roundedNumber)}");
            }
        }

    }
}