const isSymmetric = require('./05checkForSymmetry.js');
const assert = require('chai').assert;
describe('Testing isSymetric', () => {
    it('Should return false when passing number for parameter', () => {
        assert.equal(isSymmetric(-0), false);
    });
    it('Should return false when passing empty object for parameter', () => {
        assert.equal(isSymmetric({}), false);
    });
    it('Should return false when passing undefined for parameter', () => {
        assert.equal(isSymmetric(undefined), false);
    });
    it('Should return false when passing non symmetric array for parameter', () => {
        assert.equal(isSymmetric([0, 1, 2]), false);
        assert.equal(isSymmetric(['0', '1', '2']), false);
    });
    it('Should return true when passing empty array for parameter', () => {
        assert.equal(isSymmetric([]), true);
    });
    it('Should return true when passing symmetric array for parameter', () => {
        assert.equal(isSymmetric(['A', 's', 'A']), true);
        assert.equal(isSymmetric([0 / 0, NaN, 0 / 0]), true);
        assert.equal(isSymmetric([2, 1, 2, 1, 2]), true);
    });

});