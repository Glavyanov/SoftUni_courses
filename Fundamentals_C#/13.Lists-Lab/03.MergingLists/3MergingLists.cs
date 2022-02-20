using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MergingLists
{
    class MergingLists
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> numbers2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            MergingList(numbers1, numbers2);

        }

        private static void MergingList(List<int> numbers1, List<int> numbers2)
        {
            List<int> result = new List<int>();
            if (numbers1.Count > numbers2.Count)
            {

                for (int i = 0; i < numbers1.Count; i++)
                {
                    if (i > numbers2.Count - 1)
                    {
                        result.Add(numbers1[i]);
                    }
                    else
                    {
                        result.Add(numbers1[i]);
                        result.Add(numbers2[i]);

                    }

                }
            }
            else
            {
                for (int i = 0; i < numbers2.Count; i++)
                {
                    if (i > numbers1.Count - 1)
                    {
                        result.Add(numbers2[i]);
                    }
                    else
                    {
                        result.Add(numbers1[i]);
                        result.Add(numbers2[i]);

                    }

                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
