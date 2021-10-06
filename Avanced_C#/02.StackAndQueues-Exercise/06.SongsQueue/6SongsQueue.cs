using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class SongsQueue
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            while (songs.Any())
            {
                List<string> command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (command[0] == "Add")
                {
                    command.RemoveAt(0);
                    string song = string.Join(" ", command);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }

                }
                else if (command[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
