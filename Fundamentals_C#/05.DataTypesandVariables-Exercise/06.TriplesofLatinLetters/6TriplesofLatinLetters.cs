using System;

namespace _06TriplesofLatinLetters
{
    class TriplesofLatinLetters
    {
        static void Main(string[] args)
        {
            byte num = byte.Parse(Console.ReadLine());
            for (byte i = 97; i < 97 + num; i++)
            {
                for (byte j = 97; j < 97 + num; j++)
                {
                    for (byte k = 97; k < 97 + num; k++)
                    {
                        Console.WriteLine("{0}{1}{2}", (char)i, (char)j, (char)k);
                    }
                }
            }
        }
    }
}
