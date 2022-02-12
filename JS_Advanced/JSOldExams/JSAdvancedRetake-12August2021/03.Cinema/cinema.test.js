const cinema = require('./cinema.js');
const assert = require('chai').assert;
describe("Tests for cinema", () => {
    describe("showMovies function", () => {
        it("Should work correct when cinema is object", () => {
            assert.isObject(cinema);
        });
        it("Should is a function", () => {
            assert.isFunction(cinema.showMovies);
        });
        it("Should work correct", () => {
            const movies = ['King Kong', 'The Tomorow War', 'Joker'];
            const expect = movies.join(', ');
            assert.equal(cinema.showMovies(movies), expect);
        });
        it("Should throw error when passing empty array", () => {

            assert.equal(cinema.showMovies([]), 'There are currently no movies to show.');
        });
    });
    describe("ticketPrice function", () => {
        it("Should is a function", () => {
            assert.isFunction(cinema.ticketPrice);
        });
        it("Should work correct type Premiere", () => {
            assert.equal(cinema.ticketPrice('Premiere'), 12.00);
        });
        it("Should work correct type Normal", () => {
            assert.equal(cinema.ticketPrice('Normal'), 7.50);
        });
        it("Should work correct type Discount", () => {
            assert.equal(cinema.ticketPrice('Discount'), 5.50);
        });
        it("Should throw error when passing wrong string type", () => {
            assert.throws(() => cinema.ticketPrice('Unnormal'), Error, 'Invalid projection type.');
            assert.throws(() => cinema.ticketPrice(''), Error, 'Invalid projection type.');
            assert.throws(() => cinema.ticketPrice('     '), Error, 'Invalid projection type.');
        });
        it("Should throw error when passing number for type", () => {
            assert.throws(() => cinema.ticketPrice(10), Error, 'Invalid projection type.');
            assert.throws(() => cinema.ticketPrice(NaN), Error, 'Invalid projection type.');
            assert.throws(() => cinema.ticketPrice(0), Error, 'Invalid projection type.');
            assert.throws(() => cinema.ticketPrice(-10), Error, 'Invalid projection type.');
        });
    });
    describe("swapSeatsInHall function", () => {
        it("Should is a function", () => {
            assert.isFunction(cinema.swapSeatsInHall);
        });
        it("Should work correct", () => {
            assert.equal(cinema.swapSeatsInHall(1, 2), 'Successful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(1, 20), 'Successful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(20, 19), 'Successful change of seats in the hall.');

        });
        it("Should throw error when passing wrong first param", () => {
            assert.equal(cinema.swapSeatsInHall(1.2, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(-0.0001, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(-0, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(0, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(21, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(NaN, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(true, 1), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall([1, 2], 1), 'Unsuccessful change of seats in the hall.');
        });
        it("Should throw error when passing wrong second param", () => {
            assert.equal(cinema.swapSeatsInHall(10, 1.3333), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(10, -0.01), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(10, -0), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(11, 0), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(1, 21), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(2, NaN), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(2, [20, 2]), 'Unsuccessful change of seats in the hall.');
            assert.equal(cinema.swapSeatsInHall(2, false), 'Unsuccessful change of seats in the hall.');
        });

    });
});
