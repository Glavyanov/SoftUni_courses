using System;

namespace Clock
{
    class Clock
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 24; i ++)
            {
                for(int j = 0; j < 60; j ++)
                {
                    //Console.WriteLine("{0:00}" + ":" + "{1:00}", i , j);
                    Console.WriteLine($"{i}:{j}");
                }
            }
        }
    }
}
