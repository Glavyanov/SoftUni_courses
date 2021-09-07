using System;
using System.Linq;

namespace _10LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int sizeField = int.Parse(Console.ReadLine());
            int[] field = new int[sizeField];
            int[] initial = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            for (int i = 0; i < initial.Length; i++)
            {
                int current = initial[i];
                for (int j = 0; j < field.Length; j++)
                {
                    if (j == current)
                    {
                        field[j] = 1;
                        break;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int startIndex = int.Parse(commandArr[0]);
                if (startIndex >= 0 && startIndex <= field.Length - 1)
                {
                    if (field[startIndex] == 1 && commandArr[1] == "right")
                    {
                        int flyLenght = int.Parse(commandArr[2]);
                        field[startIndex] = 0;

                        for (int i = startIndex + flyLenght; i < field.Length; i += flyLenght)
                        {
                            if (i < 0)
                            {
                                break;
                            }
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                            if (i > field.Length - 1)
                            {
                                break;
                            }

                        }

                    }
                    else if (field[startIndex] == 1 && commandArr[1] == "left")
                    {
                        int flyLenght = int.Parse(commandArr[2]);
                        field[startIndex] = 0;

                        for (int i = startIndex - flyLenght; i >= 0; i -= flyLenght)
                        {
                            if (i < 0)
                            {
                                break;
                            }
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;

                            }
                            if (i > field.Length - 1)
                            {
                                break;
                            }

                        }
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));

        }
    }
}
