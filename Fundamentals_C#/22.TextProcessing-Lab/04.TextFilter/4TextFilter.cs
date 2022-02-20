using System;

namespace _04.TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] wordToBan = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var item in wordToBan)
            {
                while (text.Contains(item))
                {
                    string ban = new string('*', item.Length);
                    text = text.Replace(item, ban);

                }
            }
            Console.WriteLine(text);
        }
    }
}
