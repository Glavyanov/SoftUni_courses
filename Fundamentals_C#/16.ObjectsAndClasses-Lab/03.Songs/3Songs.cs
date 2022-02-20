using System;
using System.Linq;
using System.Collections.Generic;

namespace _03Songs
{
    class Songs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> sonic = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                List<string> data = Console.ReadLine()
                                           .Split("_", StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();
                Song current = new Song(data[0], data[1], data[2]);
                sonic.Add(current);
                
            }
            string dataType = Console.ReadLine();
            if (sonic.Any(x=> x.List == dataType))
            {
                Console.WriteLine(string.Join(Environment.NewLine,sonic.Where(x => x.List == dataType).Select(x=> x.Name)));
            }
            else if (dataType == "all")
            {
                Console.WriteLine(string.Join(Environment.NewLine, sonic.Select(x=> x.Name)));
            }
        }
    }
    class Song
    {
        public Song(string list, string name, string time)
        {
            List = list;
            Name = name;
            Time = time;
        }
        public string List { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }


    }
}
