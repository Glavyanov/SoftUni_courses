using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.ValidUserNames
{
    class ValidUserNames
    {
        static void Main(string[] args)
        {
            List<string> wordsToValidate = Console.ReadLine()
                                                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                  .ToList();
            List<string> validWords = new List<string>();
            foreach (var item in wordsToValidate)
            {
                if (item.Length >= 3 && item.Length <= 16)
                {
                    bool isValid = true;
                    foreach (var element in item)
                    {
                        if (!char.IsLetterOrDigit(element) && element != '-' && element != '_')
                        {
                            isValid = false;
                        }

                    }
                    if (isValid)
                    {
                        validWords.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join("\r\n", validWords));
        }
    }
}
