using System;

namespace _01IntegerOperations
{
    class IntegerOperations
    {
        static void Main(string[] args)
        {
           int firstNum = int.Parse(Console.ReadLine());
           int secondNum = int.Parse(Console.ReadLine());
           int thirdNum = int.Parse(Console.ReadLine());
           int fourthNum = int.Parse(Console.ReadLine());
           Console.WriteLine(((firstNum + secondNum) / thirdNum) * fourthNum);
           
        }
    }
}
