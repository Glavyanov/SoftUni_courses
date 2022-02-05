const sum = require('./04sumOfNumbers');
const {assert}  = require('chai');
const { it } = require('mocha');
describe('04sumOfNumbers', () => {
    it('Should return correct sum', ()=> {
        let arr = [1,2,3,4];
        let expected = 10;
        
        assert.equal(expected,sum(arr));
    });
    it('Should return number when array of string is passed',() => {
        let arr = ['1','2','3','4'];
        let expected = 10;
        
        assert.equal(expected,sum(arr));
    });
    it('Should return zero when empty array is passed', () => {
        let arr = [];
        assert.equal(0,sum(arr));
    });
});
