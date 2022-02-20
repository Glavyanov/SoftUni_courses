using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Article
    {
        public Article()
        {

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
    class Articles2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] receiveArt = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = receiveArt[0];
                string content = receiveArt[1];
                string author = receiveArt[2];
                Article article = new Article()
                {
                    Author = author,
                    Content = content,
                    Title = title
                };
                articles.Add(article);

            }
            string command = Console.ReadLine();
            PrintSortedBy(articles, command);
        }
        public static void PrintSortedBy(List<Article> articles, string command)
        {
            if (command == "title")
            {
                foreach (var item in articles.OrderBy(x=> x.Title))
                {
                    Console.WriteLine(item);
                }

            }
            else if (command == "content")
            {
                foreach (var item in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine(item);
                }
            }
            else if (command == "author")
            {
                foreach (var item in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
