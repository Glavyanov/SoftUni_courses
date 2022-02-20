using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Race
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> racers;
            try
            {
                 racers = Console.ReadLine()
                                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(x => x)
                                 .ToDictionary(x => x.ToString(), x => int.Parse(x = 0.ToString()));
            }
            catch (Exception)
            {

                Console.WriteLine("Error");
                return;
            }
            
            string letters = "[A-Za-z]";
            string digits = @"[0-9]{1}";
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                string name = string.Join("",Regex.Matches(input, letters).Select(x => x.Value));
                
                if (racers.ContainsKey(name))
                {
                    int[] nums = Regex.Matches(input, digits).Select(x => int.Parse(x.Value)).ToArray();
                    int sum = 0;
                    foreach (var item in nums)
                    {
                        sum += item;

                    }
                    racers[name] += sum;
                }

                input = Console.ReadLine();
            }
            int count = 0;
            foreach (var item in racers.OrderByDescending(x=> x.Value))
            {
                if (count == 3)
                {
                    break;
                }
                else if (count < 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                    count++;
                }
                else if(count < 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                    count++;

                }
                else if (count < 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                    count++;
                }
                
            }
            
        }
    }
}
