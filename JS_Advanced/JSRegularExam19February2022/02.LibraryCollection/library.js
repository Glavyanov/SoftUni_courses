class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }
    addBook(bookName, bookAuthor) {
        if (this.capacity == this.books.length) {
            throw new Error('Not enough space in the collection.');
        }

        this.books.push({
            bookName,
            bookAuthor,
            payed: false,
        })
        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }
    payBook(bookName) {
        let searchedBook = this.books.find(x => x.bookName == bookName);
        if (!searchedBook) {
            throw new Error(`${bookName} is not in the collection.`);
        }
        if (searchedBook.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }
        searchedBook.payed = true;
        return `${bookName} has been successfully paid.`;
    }
    removeBook(bookName) {
        let searchedBook = this.books.find(x => x.bookName == bookName);
        if (!searchedBook) {
            throw new Error(`The book, you're looking for, is not found.`);
        }
        if (!searchedBook.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }
        const indexToRemove = this.books.indexOf(searchedBook);
        this.books.splice(indexToRemove,1);
        return `${bookName} remove from the collection.`;
    }
    getStatistics(bookAuthor){
        let args = arguments;
        if (!args.length) {
            let result = [`The book collection has ${this.capacity - this.books.length} empty spots left.`];
            for (const book of this.books.sort((a,b) => a.bookName.localeCompare(b.bookName))) {
                result.push(`${book.bookName} == ${book.bookAuthor} - ${book.payed ? 'Has Paid' : 'Not Paid'}.`);
            }
            return result.join('\n');
        }
        let searchedAuthor = this.books.find(x => x.bookAuthor == bookAuthor);
        if (!searchedAuthor) {
            throw new Error(`${bookAuthor} is not in the collection.`);
        }
        return `${searchedAuthor.bookName} == ${searchedAuthor.bookAuthor} - ${searchedAuthor.payed ? 'Has Paid' : 'Not Paid'}.`;

    }
}
const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics('Marcel Proust'));




