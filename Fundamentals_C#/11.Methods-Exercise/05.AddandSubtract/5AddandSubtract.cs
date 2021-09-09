using System;

namespace _05AddandSubtract
{
    class AddandSubtract
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            SumInteger(num1, num2, num3);
        }
        static void SumInteger(int one, int two, int three)
        {
            int sumResult =one + two ;
            Console.WriteLine(Subtract(sumResult, three)); 
        }
        static int Subtract(int sum, int num3)
        {
            int result = sum - num3;
            return result;

        }
    }
}
