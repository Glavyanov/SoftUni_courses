using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Winnie the Pooh", 1967, "A. A. Milne", "Andersen");
            Book bookTwo = new Book("Vinnie the Pooh", 1968, "A. A. Milne", "Andersen");
            Library library = new Library();
            library = new Library(bookOne);
            Library library1 = new Library();
        }
    }
}
