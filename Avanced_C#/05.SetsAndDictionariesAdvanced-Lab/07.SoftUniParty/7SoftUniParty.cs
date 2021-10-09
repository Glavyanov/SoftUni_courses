using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07.SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            string guest = Console.ReadLine();
            HashSet<string> loggerVip = new HashSet<string>();
            HashSet<string> loggerRegular = new HashSet<string>();
            Regex regexVip = new Regex(@"^[0-9]{1}.{7}$");
            Regex regexRegular = new Regex(@"^.{8}$");
            while (guest != "PARTY")
            {
                Match matchVip = regexVip.Match(guest);
                Match match = regexRegular.Match(guest);
                if (matchVip.Success)
                {
                    loggerVip.Add(guest);
                }
                else if (match.Success)
                {
                    loggerRegular.Add(guest);
                }
                guest = Console.ReadLine();
            }
            string arrival = Console.ReadLine();
            while (arrival != "END")
            {
                if (loggerVip.Contains(arrival))
                {
                    loggerVip.Remove(arrival);
                }
                else if (loggerRegular.Contains(arrival))
                {
                    loggerRegular.Remove(arrival);
                }
                arrival = Console.ReadLine();
            }
            Console.WriteLine(loggerVip.Count + loggerRegular.Count);
            if (loggerVip.Count > 0)
            {
                foreach (var item in loggerVip)
                {
                    Console.WriteLine(item);
                }
            }
            if (loggerRegular.Count > 0)
            {
                foreach (var item in loggerRegular)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
