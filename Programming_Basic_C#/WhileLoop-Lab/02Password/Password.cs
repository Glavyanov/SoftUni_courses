using System;

namespace _02Password
{
class Password
{
static void Main(string[] args)
{
    string name = Console.ReadLine();
    string pass = Console.ReadLine();
    string currentPass = "";
    while (pass != currentPass)
    {
        currentPass = Console.ReadLine();
    }
    Console.WriteLine("Welcome " + name + "!");
}
}
}
