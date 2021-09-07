using System;
using System.Linq;

namespace _02CommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] arrOne = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] arrTwo = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0 ;i <arrTwo.Length ; i++ )
            {
                string currentOfArrTwo = arrTwo[i];
                for (int j = 0; j < arrOne.Length; j++)
                {
                    string currentOfArrOne = arrOne[j];
                    if (currentOfArrTwo == currentOfArrOne)
                    {
                        Console.Write("{0} ",currentOfArrTwo);
                        break;
                    }
                }
            }
        }
    }
}
