using System;
using System.Text;

namespace _07RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());
            string newText = RepeatText(someText, repeat);
            Console.WriteLine(newText);
        }

        private static string RepeatText(string someText, int repeat)
        {
            StringBuilder textAdd = new StringBuilder();
           
            for (int i = 0; i < repeat; i++)
            {
                textAdd.Append(someText);
            }
            string newText = textAdd.ToString();
            return newText;
        }
    }
}
