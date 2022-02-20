using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            var collected = new Dictionary<string, uint>();
            string currentInput = string.Empty;
            string input = string.Empty;
            for (int i = 1; i > 0 && input != "stop"; i++)
            {
                input = Console.ReadLine();
                if (i % 2 != 0)
                {
                    currentInput = input;
                    if (!collected.ContainsKey(currentInput) && input != "stop")
                    {
                        collected.Add(currentInput, 0);
                    }
                }
                else if (i % 2 == 0)
                {
                    uint quantity = uint.Parse(input);
                    collected[currentInput] += quantity;
                }
            }
            foreach (var (key, value) in collected)
            {
                Console.WriteLine("{0} -> {1}", key, value);

            }
        }
    }
}
