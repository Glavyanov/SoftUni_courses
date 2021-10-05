using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Composer
    {
        public string Name { get; set; }
        public string Key { get; set; }
    }
    class ThePianist
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Composer> pieces = new Dictionary<string, Composer>();
            for (int i = 0; i < n; i++)
            {
                string[] pieceRecord = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = pieceRecord[0];
                if (!pieces.ContainsKey(piece))
                {
                    string author = pieceRecord[1];
                    string key = pieceRecord[2];
                    Composer composer = new Composer()
                    {
                        Name = author,
                        Key = key
                    };
                    pieces.Add(piece, composer);
                }

            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] cmdArgs = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Add")
                {
                    string piece = cmdArgs[1];
                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        string author = cmdArgs[2];
                        string key = cmdArgs[3];
                        Composer composer = new Composer()
                        {
                            Name = author,
                            Key = key
                        };
                        pieces.Add(piece, composer);
                        Console.WriteLine($"{piece} by {author} in {key} added to the collection!");

                    }

                }
                else if (action == "Remove")
                {
                    string piece = cmdArgs[1];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string piece = cmdArgs[1];
                    string replaceKey = cmdArgs[2];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = replaceKey;
                        Console.WriteLine($"Changed the key of {piece} to {replaceKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }

                command = Console.ReadLine();
            }
            foreach (var item in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.Name}, Key: {item.Value.Key}");
            }
        }
    }
}
