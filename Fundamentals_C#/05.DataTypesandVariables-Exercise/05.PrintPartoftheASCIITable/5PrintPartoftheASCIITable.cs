using System;

namespace _05PrintPartOfASCIITable
{
    class PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            byte start = byte.Parse(Console.ReadLine());
            byte end = byte.Parse(Console.ReadLine());
            for (byte i = start; i <= end; i++)
            {
                char acter = (char)i;
                Console.Write("{0} ", acter);
            }
        }
    }
}
