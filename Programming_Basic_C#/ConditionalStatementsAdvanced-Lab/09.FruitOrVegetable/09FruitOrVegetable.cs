using System;

namespace _09FruitOrVegetable
{
class Program
{
static void Main(string[] args)
{
    string product = Console.ReadLine();
    switch (product)
    {
        case "banana":
        case "apple":
        case "kiwi":
        case "lemon":
        case "grapes":
        case "cherry":
            Console.WriteLine("fruit");
            break;
        case "tomato":
        case "cucumber":
        case "pepper":
        case "carrot":
            Console.WriteLine("vegetable");
            break;

        default:
            Console.WriteLine("unknown");
            break;
    }
}
}
}
