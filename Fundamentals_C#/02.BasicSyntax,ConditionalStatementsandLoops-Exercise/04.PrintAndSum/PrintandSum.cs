using System;

namespace _04PrintAndSum
{
class PrintandSum
{
static void Main(string[] args)
{
    int start = int.Parse(Console.ReadLine());
    int end = int.Parse(Console.ReadLine());
    int sum = 0;
    for (int go = start; go <= end; go++)
    {
        Console.Write("{0} ", go);
        sum += go;
    }
    Console.WriteLine();
    Console.WriteLine("Sum: {0}", sum);
}
}
}
