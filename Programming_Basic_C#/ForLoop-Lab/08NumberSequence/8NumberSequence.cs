using System;

namespace _08NumberSequence
{
    class NumberSequence
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int num = 0;
           
            int minNumber = int.MaxValue; 
            int MaxNumber = int.MinValue;
            for (int i = 0; i < count ; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num > MaxNumber)
                {
                    MaxNumber = num; 
                }
                if(num < minNumber)
                {
                    minNumber = num;
                }
            }
            Console.WriteLine("Max number: "+ MaxNumber);
            Console.WriteLine("Min number: "+ minNumber);
        }
    }
}
