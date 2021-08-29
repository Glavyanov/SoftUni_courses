using System;

namespace _06StrongNumber
{
class StrongNumber
{
static void Main(string[] args)
{
    int num = int.Parse(Console.ReadLine());
    int convertGo = 0;
    int sum = 0;
    int number = num;
    while (number != 0)
    {
        int digit = number % 10;
        convertGo = digit;
        for (int go = digit - 1; go >= 1; go--)
        {

            convertGo *= go;
        }
        if (convertGo == 0)
        {
            convertGo = 1;
        }

        sum += convertGo;
        convertGo = 0;

        number /= 10;
    }
    if (sum == num)
    {
        Console.WriteLine("yes");
    }
    else
    {
        Console.WriteLine("no");
    }
}
}
}
