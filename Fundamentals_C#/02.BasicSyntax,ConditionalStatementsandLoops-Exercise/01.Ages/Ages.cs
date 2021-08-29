using System;

namespace _01Ages
{
class Ages
{
static void Main(string[] args)
{
    int ages = int.Parse(Console.ReadLine());
    string kind = "";
    if (ages >= 66)
    {
        kind = "elder";
    }
    else if (ages > 19)
    {
        kind = "adult";
    }
    else if (ages > 13)
    {
        kind = "teenager";
    }
    else if (ages > 2)
    {
        kind = "child";
    }
    else if (ages >= 0)
    {
        kind = "baby";
    }
    Console.WriteLine(kind);
}
}
}
