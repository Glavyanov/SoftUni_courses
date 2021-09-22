using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            var itemLegendary = new Dictionary<string, int>()
            {
                { "fragments", 0 },
                { "motes", 0 },
                { "shards", 0 }

            };
            var junk = new Dictionary<string, int>();
            bool obtained = true;
            while (obtained)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < input.Length; i += 2)
                {

                    string currentName = input[i].ToLower();
                    int quantity = int.Parse(input[i - 1]);
                    if (currentName == "shards" || currentName == "motes" || currentName == "fragments")
                    {
                        itemLegendary[currentName] += quantity;
                        if (itemLegendary.Any(x => x.Value >= 250))
                        {
                            string curr = string.Join("", itemLegendary.Where(x => x.Value >= 250).Select(x => x.Key));
                            //string vs = curr[0].ToString().ToUpper();
                            //curr = vs + curr.Substring(1, curr.Length - 1);
                            //Console.WriteLine("{0} obtained!", curr);// Ако се търсеше модификация по на item.Key, ато се търси ако Key-a е x да се напише y.
                            string obtainedName = string.Empty;
                            if (curr == "fragments")
                            {
                                obtainedName = "Valanyr";
                            }
                            else if (curr == "shards")
                            {
                                obtainedName = "Shadowmourne";
                            }
                            else
                            {
                                obtainedName = "Dragonwrath";
                            }
                            itemLegendary[curr] -= 250;
                            Console.WriteLine($"{obtainedName} obtained!");
                            obtained = false;
                            break;

                        }

                    }
                    else
                    {
                        if (!junk.ContainsKey(currentName))
                        {
                            junk.Add(currentName, 0);
                        }
                        junk[currentName] += quantity;

                    }
                }
            }
            foreach (var (key, value) in itemLegendary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{key}: {value}");
            }
            foreach (var (key, value) in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{key}: {value}");
            }

        }
    }
}
