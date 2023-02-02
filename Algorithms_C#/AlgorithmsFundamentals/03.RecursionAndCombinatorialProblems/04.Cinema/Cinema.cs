using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Cinema
{
    public class Cinema
    {
        private static List<string> persons;

        private static bool[] occupated;

        private static string[] result;

        static void Main(string[] args)
        {
            persons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            occupated = new bool[persons.Count];
            result = new string[persons.Count];

            string command;
            while ((command = Console.ReadLine()) != "generate")
            {
                string[] info = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string personName = info[0];
                int location = int.Parse(info[1]) - 1;

                result[location] = personName;
                occupated[location] = true;

                persons.Remove(personName);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= persons.Count)
            {
                PrintResult();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < persons.Count; i++)
            {

                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintResult()
        {
            int index = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (!occupated[i])
                {
                    result[i] = persons[index++];
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }

        private static void Swap(int index, int i)
        {
            (persons[index], persons[i]) = (persons[i], persons[index]);
        }
    }
}
