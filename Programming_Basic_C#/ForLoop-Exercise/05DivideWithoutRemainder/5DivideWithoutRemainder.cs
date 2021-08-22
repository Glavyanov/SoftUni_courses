using System;

namespace _05DivideWithoutRemainder
{
class DivideWithoutRemainder
{
static void Main(string[] args)
{
    int n = int.Parse(Console.ReadLine());
    int pTwoo = 0;
    int pThree = 0;
    int pFour = 0;
    for (int i = 0; i < n; i++)
    {
        int num = int.Parse(Console.ReadLine());
        if (num % 2 == 0)
        {
            pTwoo++;
        }
        if (num % 3 == 0)
        {
            pThree++;
        }
        if (num % 4 == 0)
        {
            pFour++;
        }
    }
    double perTwoo = pTwoo;
    Console.WriteLine($"{(perTwoo / n * 100):f2}%");
    double perThree = pThree;
    Console.WriteLine($"{(perThree / n * 100):f2}%");
    double perFour = pFour;
    Console.WriteLine($"{(perFour / n * 100):f2}%");
}
}
}
