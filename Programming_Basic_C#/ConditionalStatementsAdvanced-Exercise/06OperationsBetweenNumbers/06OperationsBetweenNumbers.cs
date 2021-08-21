using System;

namespace _06OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double nOne = int.Parse(Console.ReadLine());
            double nTwo = int.Parse(Console.ReadLine());
            string operate = Console.ReadLine();
            double result = 0.0;
            if (operate == "/")
            {
                if (nTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {nOne} by zero");
                }
                else
                {
                    result = nOne / nTwo;
                    Console.WriteLine($"{nOne} / {nTwo} = {result:f2}");
                }
                
            }
            else if (operate == "%")
            {
                if (nTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {nOne} by zero");
                }
                else
                {
                    result = nOne % nTwo;
                    Console.WriteLine($"{nOne} % {nTwo} = {result}");
                }
            }
            else if (operate == "+")
            {
                result = nOne + nTwo;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{nOne} + {nTwo} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{nOne} + {nTwo} = {result} - odd");
                }
            }
            else if (operate == "-")
            {
                result = nOne - nTwo;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{nOne} - {nTwo} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{nOne} - {nTwo} = {result} - odd");
                }
            }
            else if (operate == "*")
            {
                result = nOne * nTwo;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{nOne} * {nTwo} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{nOne} * {nTwo} = {result} - odd");
                }
            }

        }
    }
}
