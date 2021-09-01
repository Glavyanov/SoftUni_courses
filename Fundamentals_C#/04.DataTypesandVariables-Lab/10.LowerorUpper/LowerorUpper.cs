using System;

namespace _10LowerorUpper
{
    class LowerorUpper
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            if ((int)symbol < 97 )
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
