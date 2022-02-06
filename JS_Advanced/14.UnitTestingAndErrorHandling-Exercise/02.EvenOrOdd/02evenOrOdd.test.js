const isOddOrEven = require('../02evenOrOdd.js');
const assert = require('chai').assert;

it('Should return string when passed correct param', () => {
    assert.isString(isOddOrEven('even'));
});
it('Should return even when passed string with even length', () => {
    assert.equal(isOddOrEven('test'), 'even');
});
it('Should return odd when passed string with odd length', () => {
    assert.equal(isOddOrEven('foo'), 'odd');
});
it('Should return undefined when passed number to param', () => {
    assert.equal(isOddOrEven(5), undefined);
});
it('Should return undefined when passed interface to param', () => {
    assert.equal(isOddOrEven(String), undefined);
});