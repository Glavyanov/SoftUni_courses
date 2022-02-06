const lookupChar = require('../03charLookup.js');
const assert = require('chai').assert;

it('Should return undefined when first param is incorrect', () => {
    assert.equal(lookupChar({}, 0), undefined);
});
it('Should return undefined when second param is incorrect', () => {
    assert.equal(lookupChar('{}', {}), undefined);
});
it('Should return undefined when both param is incorrect', () => {
    assert.equal(lookupChar([], NaN), undefined);
});
it('Should return undefined when second param is floating point number', () => {
    assert.equal(lookupChar('float', 44.44), undefined);
});
it('Should return Incorrect index when index is less than zero', () => {
    assert.equal(lookupChar('float', -1), 'Incorrect index');
});
it('Should return Incorrect index when index is greater than string.length', () => {
    assert.equal(lookupChar('float', 100), 'Incorrect index');
    assert.equal(lookupChar('', 0), 'Incorrect index');
});
it('Should return char', () => {
    assert.equal(lookupChar('float', 0).length, 1);
    assert.isString(lookupChar('float', 0));
});
it('Should return correct char on given index from string', () => {
    assert.equal(lookupChar('float', 0), 'f');
});
it('Should return correct char on given last index from string', () => {
    const actual = 'point';
    assert.equal(lookupChar(actual, actual.length - 1), 't');
});