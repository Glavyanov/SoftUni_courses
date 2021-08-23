using System;

namespace _01OldBooks
{
class OldBooks
{
static void Main(string[] args)
{
    string favoriteBook = Console.ReadLine();
    string searchBook = Console.ReadLine();
    int countSearched = 0;
    while (searchBook != favoriteBook)
    {
        if (searchBook == "No More Books")
        {
            break;
        }
        countSearched++;
        searchBook = Console.ReadLine();
    }
    if (searchBook == favoriteBook)
    {
        Console.WriteLine("You checked {0} books and found it.", countSearched);
    }
    else
    {
        Console.WriteLine("The book you search is not here!");
        Console.WriteLine("You checked {0} books.", countSearched);
    }
}
}
}
