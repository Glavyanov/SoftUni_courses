using System;

namespace _02.Articles
{

    class Program
    {

        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] entrance = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string entAuthor = entrance[2];
            string entContent = entrance[1];
            string entTitle = entrance[0];
            Article article = new Article() // Само с new() без Article() хвърля compile time error в Judge
            {
                Author = entAuthor,
                Content = entContent,
                Title = entTitle
            };
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string content = command[1];
                if (action == "Edit")
                {
                    article.Edit(content);
                }
                else if (action == "ChangeAuthor")
                {
                    article.Change(content);
                }
                else if (action == "Rename")
                {
                    article.Rename(content);
                }

            }

            Console.WriteLine(article);

        }
    }
    class Article
    {
        public Article()
        {

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void Edit(string content)
        {
            Content = content;

        }
        public void Change(string content)
        {
            Author = content;

        }
        public void Rename(string content)
        {
            Title = content;

        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}