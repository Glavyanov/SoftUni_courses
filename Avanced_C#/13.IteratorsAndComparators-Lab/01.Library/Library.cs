using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public  class Library
    {
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        private readonly List<Book> books;
    }
}
