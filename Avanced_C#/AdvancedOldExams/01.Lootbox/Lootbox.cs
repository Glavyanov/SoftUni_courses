using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Lootbox
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> items = new List<int>();
            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int numFirst = firstBox.Peek();
                int numSecond = secondBox.Pop();
                if ((numFirst + numSecond) % 2 == 0)
                {
                    firstBox.Dequeue();
                    items.Add(numFirst + numSecond);
                }
                else
                {
                    firstBox.Enqueue(numSecond);
                }

            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine(items.Sum() < 100 ? $"First lootbox is empty{Environment.NewLine}Your loot was poor... Value: {items.Sum()}" : $"First lootbox is empty{Environment.NewLine}Your loot was epic! Value: {items.Sum()}");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine(items.Sum() < 100 ? $"Second lootbox is empty{Environment.NewLine}Your loot was poor... Value: {items.Sum()}" : $"Second lootbox is empty{Environment.NewLine}Your loot was epic! Value: {items.Sum()}");
            }
        }
    }
}
