const testNumbers = require('./testNumbers');
const assert = require('chai').assert;
describe("Tests testNumbers object", function () {
   describe("sumNumbers should work correct …", function () {
      it("should return string …", function () {
         let actual = testNumbers.sumNumbers(10, 20);
         assert.isString(actual);
      });

      it("when passing two numbers …", function () {
         let actual = testNumbers.sumNumbers(10, 20);
         assert.equal(actual, '30.00');
         actual = testNumbers.sumNumbers(-10.01, 20);
         assert.equal(actual, '9.99');
         actual = testNumbers.sumNumbers(-10.01, -10.01);
         assert.equal(actual, '-20.02');
         actual = testNumbers.sumNumbers(-0, 0.000);
         assert.equal(actual, '0.00');
      });

      it("when passing without numbers …", function () {
         let actual = testNumbers.sumNumbers();
         assert.equal(actual, undefined);
      });

      it("when passing invalid first parameter", function () {
         let actual = testNumbers.sumNumbers({}, 20);
         assert.equal(actual, undefined);
         actual = testNumbers.sumNumbers([], 20);
         assert.equal(actual, undefined);
         actual = testNumbers.sumNumbers('NaN', 20);
         assert.equal(actual, undefined);
      });

      it("when passing invalid second parameter", function () {
         let actual = testNumbers.sumNumbers(20, false);
         assert.equal(actual, undefined);
         actual = testNumbers.sumNumbers(20, new Map());
         assert.equal(actual, undefined);
         actual = testNumbers.sumNumbers(20);
         assert.equal(actual, undefined);
      });
   });
   describe("numberChecker should work correct …", function () {

      it("should return string …", function () {
         let actual = testNumbers.numberChecker(11);
         assert.isString(actual);

      });

      it("when passing odd number", function () {
         let actual = testNumbers.numberChecker(11);
         assert.equal(actual, 'The number is odd!');
         actual = testNumbers.numberChecker(13);
         assert.equal(actual, 'The number is odd!');
         actual = testNumbers.numberChecker(-13);
         assert.equal(actual, 'The number is odd!');
         actual = testNumbers.numberChecker(-10.01);
         assert.equal(actual, 'The number is odd!');
         actual = testNumbers.numberChecker(true);
         assert.equal(actual, 'The number is odd!');
      });

      it("when passing even number", function () {
         let actual = testNumbers.numberChecker(10);
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker(20);
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker(0);
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker(-10);
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker(-0);
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker([]);
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker(' ');
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker(false);
         assert.equal(actual, 'The number is even!');
      });

      it("when passing number as string", function () {
         let actual = testNumbers.numberChecker('11');
         assert.equal(actual, 'The number is odd!');
         actual = testNumbers.numberChecker('120000');
         assert.equal(actual, 'The number is even!');
         actual = testNumbers.numberChecker('-13');
         assert.equal(actual, 'The number is odd!');
         actual = testNumbers.numberChecker('-10.01');
         assert.equal(actual, 'The number is odd!');
      });
      
      it("should throw error when passing not a number", function () {
         assert.throws(() => testNumbers.numberChecker(), Error, 'The input is not a number!');
         assert.throws(() => testNumbers.numberChecker({}), Error, 'The input is not a number!');
         assert.throws(() => testNumbers.numberChecker('[]'), Error, 'The input is not a number!');
         assert.throws(() => testNumbers.numberChecker(NaN), Error, 'The input is not a number!');
         assert.throws(() => testNumbers.numberChecker('sauce'), Error, 'The input is not a number!');
         assert.throws(() => testNumbers.numberChecker(undefined), Error, 'The input is not a number!');
      });

   });
   describe("averageSumArray should work correct …", function () {
      it("should return a number …", function () {
         let actual = testNumbers.averageSumArray([1, 1]);
         assert.isNumber(actual);
      });
      it("should return a correct value", function () {
         let actual = testNumbers.averageSumArray([1, 1]);
         assert.equal(actual, 1);
         actual = testNumbers.averageSumArray([1.1, -1.23, 33]);
         assert.equal(actual, 10.956666666666665);
         actual = testNumbers.averageSumArray([0, -0, 0, 0, 0]);
         assert.equal(actual,-0);
         actual = testNumbers.averageSumArray([]);
         assert.isNaN(actual);
      });
   });


});
