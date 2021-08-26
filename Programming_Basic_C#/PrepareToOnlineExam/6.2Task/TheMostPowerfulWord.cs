using System;

namespace SixxxTask
{
    class TheMostPowerfulWord
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int currentsum = 0;
            bool flag = false;
            int max = 0;
            string wonWord = "";
            while (word != "End of words")
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char j = word[i];
                    int num = (int)j;
                    if (i == 0 && (j == 'a' || j == 'e' || j == 'i' || j == 'o' || j == 'u' || j == 'y' || j == 'A'
                        || j == 'E' || j == 'I' || j == 'O' || j == 'U' || j == 'Y'))
                    {
                        flag = true;
                    }
                    currentsum += num;
                }
                if (flag)
                {
                    currentsum *= word.Length;
                }
                else
                {
                    currentsum = currentsum / word.Length;
                }
                if (max < currentsum)
                {
                    max = currentsum;
                    wonWord = word;
                }
                currentsum = 0;
                flag = false;
                word = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {wonWord} - {max}");
        }
    }
}
