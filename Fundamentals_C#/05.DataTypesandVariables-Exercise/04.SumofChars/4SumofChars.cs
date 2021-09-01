using System;

namespace _04SumOfChars
{
    class SumOfchars
    {
        static void Main(string[] args)
        {
            byte num = byte.Parse(Console.ReadLine());
            ushort sum = 0;
            for (byte i = 0; i < num; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                byte convertedSymbol = (byte)symbol;
                sum += convertedSymbol;
            }
            Console.WriteLine("The sum equals: {0}", sum);
        }
    }
}
