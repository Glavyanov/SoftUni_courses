using System;

namespace _04RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            for (int startNumber = 2; startNumber <= endNumber; startNumber++)
            {
                bool prime = true;
                for (int divider = 2; divider < startNumber; divider++)
                {
                    if (startNumber % divider == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Console.WriteLine("{0} -> true", startNumber);
                }
                else
                {
                    Console.WriteLine("{0} -> false", startNumber);
                }
                
            }

        }
    }
}
