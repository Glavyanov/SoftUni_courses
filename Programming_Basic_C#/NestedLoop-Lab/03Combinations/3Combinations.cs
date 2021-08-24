using System;

namespace _03Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int counter = 0;
            for (int numOne = 0; numOne <= num; numOne++)
            {
                for (int numtwo = 0; numtwo <= num; numtwo++)
                {
                    for (int numThree = 0; numThree <= num; numThree++)
                    {
                        double result = numOne + numtwo + numThree;
                        if (result == num)
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
