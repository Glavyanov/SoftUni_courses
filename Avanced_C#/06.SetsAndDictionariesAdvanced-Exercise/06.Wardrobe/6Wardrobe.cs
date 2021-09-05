using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] assign = Console.ReadLine()
                                         .Split(new string[] { " -> ", "," }, StringSplitOptions.None);
                string color = assign[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < assign.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(assign[j]))
                    {
                        wardrobe[color].Add(assign[j], 0);
                    }
                    wardrobe[color][assign[j]]++;
                }

            }
            string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorInfo = commandInfo[0];
            string clothInfo = commandInfo[1];
            foreach (var item in wardrobe)
            {
                if (item.Key == colorInfo)
                {
                    Console.WriteLine($"{colorInfo} clothes:");
                    foreach (var element in item.Value)
                    {
                        if (element.Key == clothInfo)
                        {
                            Console.WriteLine($"* {clothInfo} - {element.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {element.Key} - {element.Value}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{item.Key} clothes:");
                    foreach (var element in item.Value)
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value}");

                    }

                }
            }
        }
    }
}
