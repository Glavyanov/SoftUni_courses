using System;
using System.IO;

namespace _03.ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //input = Path.GetFileNameWithoutExtension(input);
            //string extension = Path.GetExtension(input).Substring(1);            // Решение с System.IO

            int indexFileName = input.LastIndexOf('\\');
            string fileName = input.Substring(indexFileName + 1, input.Length - 1 - indexFileName);
            int indexExtension = fileName.LastIndexOf('.');
            string extension = fileName.Substring(indexExtension + 1);
            string fileNameWithoutExtension = fileName.Substring(0, indexExtension);
            Console.WriteLine($"File name: {fileNameWithoutExtension}");
            //Console.WriteLine($"File name: {input}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
