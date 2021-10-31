using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public  class Library : IEnumerable<Book>
    {
        
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        private readonly List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;

            private int currenIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = books.ToList();
            }

            public Book Current => this.books[this.currenIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++this.currenIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currenIndex = -1;
            }
        }
    }
}
