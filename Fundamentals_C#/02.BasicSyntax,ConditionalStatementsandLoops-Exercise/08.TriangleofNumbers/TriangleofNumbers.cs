using System;

namespace _08TriangleofNumbers
{
    class TriangleofNumbers
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            for (byte rows = 1; rows <= n; rows++)
            {
                for (byte cols = 1; cols <= rows; cols++)
                {
                    byte num = rows;
                    Console.Write("{0} ",num);
                }
                Console.WriteLine();

            }
        }
    }
}
