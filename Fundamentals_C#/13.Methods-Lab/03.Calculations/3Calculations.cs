using System;

namespace _03Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            switch (command)
            {
                case "add":
                    AddM(a, b);
                    break;
                case "multiply":
                    MultiplyM(a, b);
                    break;  
                case "subtract":
                    SubtractM(a, b);
                    break;
                case "divide":
                    DivideM(a, b);
                    break;
                default:
                    break;
            }
        }
        static void AddM(int first, int sec)
        {
            int result = first + sec;
            Console.WriteLine(result);

        }
        static void MultiplyM(int first, int sec)
        {
            int result = first * sec;
            Console.WriteLine(result);

        }
        static void SubtractM(int first, int sec)
        {
            int result = first - sec;
            Console.WriteLine(result);

        }
        static void DivideM(int first, int sec)
        {
            int result = first / sec;
            Console.WriteLine(result);

        }

    }
}
