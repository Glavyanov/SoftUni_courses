using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            List<int> numbersRemoved = new List<int>();
            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    int removedOnFirstIndex = numbers[0];
                    numbersRemoved.Add(removedOnFirstIndex);
                    numbers[0] = numbers[numbers.Count - 1];
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int currentNum = numbers[i];
                        if (currentNum <= removedOnFirstIndex)
                        {
                            numbers[i] += removedOnFirstIndex;
                        }
                        else
                        {
                            numbers[i] -= removedOnFirstIndex;
                        }
                    }
                    continue;
                }
                else if (index >= numbers.Count)
                {
                    int removedOnLastIndex = numbers[numbers.Count - 1];
                    numbersRemoved.Add(removedOnLastIndex);
                    numbers[numbers.Count - 1] = numbers[0];
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int currentNum = numbers[i];
                        if (currentNum <= removedOnLastIndex)
                        {
                            numbers[i] += removedOnLastIndex;
                        }
                        else
                        {
                            numbers[i] -= removedOnLastIndex;
                        }
                    }
                    continue;
                }
                int removed = numbers[index];
                numbers.RemoveAt(index);
                numbersRemoved.Add(removed);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int currentNum = numbers[i];
                    if (currentNum <= removed)
                    {
                        numbers[i] += removed;
                    }
                    else
                    {
                        numbers[i] -= removed;
                    }
                }
            }
            Console.WriteLine(numbersRemoved.Sum());
        }
    }
}
