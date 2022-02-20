using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Memorygame
{
    class Memorygame
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .ToList();

            string command = Console.ReadLine();
            int countMoves = 0;
            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int index1 = int.Parse(cmdArgs[0]);
                int index2 = int.Parse(cmdArgs[1]);
                countMoves++;
                if (index1 == index2)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string addingElements = "-" + countMoves.ToString() + "a";
                    int indexAdd = elements.Count / 2;
                    elements.Insert(indexAdd, addingElements);
                    elements.Insert(indexAdd, addingElements);

                }
                else if ((index1 < 0 || index1 > elements.Count -1) || (index2 < 0 || index2 > elements.Count - 1))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string addingElements = "-" + countMoves.ToString() + "a";
                    int indexAdd = elements.Count / 2;
                    elements.Insert(indexAdd, addingElements);
                    elements.Insert(indexAdd, addingElements);
                    
                }
                else if (elements[index1] == elements[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[index1]}!");
                    if (index1 > index2)
                    {
                        int temp = index1;
                        index1 = index2;
                        index2 = temp;

                    }
                    elements.RemoveAt(index1);
                    elements.RemoveAt(index2-1);

                }
                else if(elements[index1] != elements[index2])
                {
                    Console.WriteLine("Try again!");

                }
                if (elements.Count == 0)
                {
                    break;

                }

                command = Console.ReadLine();

            }
            if (elements.Count == 0)
            {
                Console.WriteLine($"You have won in {countMoves} turns!");

            }
            else if (elements.Count > 0)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));

            }
        }
    }
}
