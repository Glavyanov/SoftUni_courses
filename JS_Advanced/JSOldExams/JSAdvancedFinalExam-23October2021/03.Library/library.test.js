const library = require('../library.js');
const assert = require('chai').assert;
describe("Tests library object", function () {
    describe("Method calcPriceOfBook ", function () {

        it("Should throw error when first param is not a string", function () {
            assert.throws(() => library.calcPriceOfBook({}, 10), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook([], 10), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook(10, 10), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook(true, 10), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook(false), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook(String, 1991), Error, "Invalid input");
        });
        it("Should throw error when second  param is not a invalid number", function () {
            assert.throws(() => library.calcPriceOfBook('Book', 10.10), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook('Book', -10.10), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook('Book', false), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook('Book', {}), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook('Book', '2Pass'), Error, "Invalid input");
            assert.throws(() => library.calcPriceOfBook('Book', NaN), Error, "Invalid input");
        });

        it("Should work correct when year is over 1980", function () {
            assert.equal(library.calcPriceOfBook('Book', 1981), 'Price of Book is 20.00');
            assert.equal(library.calcPriceOfBook('Book', 1991), 'Price of Book is 20.00');
            assert.equal(library.calcPriceOfBook('Book', 1991 + 2020), 'Price of Book is 20.00');
        });
        it("Should work correct when year is less or equal 1980", function () {
            assert.equal(library.calcPriceOfBook('Book', 1980), 'Price of Book is 10.00');
            assert.equal(library.calcPriceOfBook('Book', 1979), 'Price of Book is 10.00');
            assert.equal(library.calcPriceOfBook('Book', 1900), 'Price of Book is 10.00');
            assert.equal(library.calcPriceOfBook('Book', -1), 'Price of Book is 10.00');
        });
    });
    describe("Method findBook ", function () {

        it("Should throw error when array length is zero", function () {
            assert.throws(() => library.findBook([], 10), Error, "No books currently available");
            assert.throws(() => library.findBook('', 'Book'), Error, "No books currently available");
        });
        it("Should work correct", function () {
            let obj = {};
            assert.equal(library.findBook(['Book'], 'Book'), 'We found the book you want.');
            assert.equal(library.findBook(['Book', 'NextBook', 'NextBook'], 'NextBook'), 'We found the book you want.');
            assert.equal(library.findBook(['Book', 'NextBook', 'OtherBook'], 'OtherBook'), 'We found the book you want.');
            assert.equal(library.findBook(['Book', 'NextBook', obj], obj), 'We found the book you want.');
        });
        it("Should return when not found a book", function () {
            assert.equal(library.findBook(['Book'], 'book'), 'The book you are looking for is not here!');
            assert.equal(library.findBook(['Book', {}], {}), 'The book you are looking for is not here!');
            assert.equal(library.findBook(['Book', 'NewBook', 'Next', 'Other'], '{}'), 'The book you are looking for is not here!');

        });
    });
    describe("Method arrangeTheBooks ", function () {

        it("Should throw error param is not integer", function () {
            assert.throws(() => library.arrangeTheBooks(-10.10), Error, "Invalid input");
            assert.throws(() => library.arrangeTheBooks(0.555), Error, "Invalid input");
            assert.throws(() => library.arrangeTheBooks({}), Error, "Invalid input");
            assert.throws(() => library.arrangeTheBooks(String), Error, "Invalid input");
        });
        it("Should throw error param is nnegative num", function () {
            assert.throws(() => library.arrangeTheBooks(-10), Error, "Invalid input");
            assert.throws(() => library.arrangeTheBooks(-1), Error, "Invalid input");
            assert.throws(() => library.arrangeTheBooks(-100), Error, "Invalid input");
        });
        it("Should work correct when param is less available space", function () {
            assert.equal(library.arrangeTheBooks(40), "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(39), "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(0), "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(15), "Great job, the books are arranged.");
        });
        it("Should work correct when param is greater available space", function () {
            assert.equal(library.arrangeTheBooks(41), "Insufficient space, more shelves need to be purchased.");
            assert.equal(library.arrangeTheBooks(100), "Insufficient space, more shelves need to be purchased.");
            assert.equal(library.arrangeTheBooks(42), "Insufficient space, more shelves need to be purchased.");
        });
    });

});
