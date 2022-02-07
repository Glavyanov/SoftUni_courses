const mathEnforcer = require('../04mathEnforcer.js');
const assert = require('chai').assert;

describe('Add Five Method', () => {
    it('Should is a function', () => {
        assert.isFunction(mathEnforcer.addFive);
    });
    it('Should return number when passing correct param', () => {
        assert.isNumber(mathEnforcer.addFive(10));
    });
    it('Should return correct result when passing correct param', () => {
        assert.equal(mathEnforcer.addFive(10), 15);
    });
    it('Should return correct result when passing negative num', () => {
        assert.equal(mathEnforcer.addFive(-10), -5);
    });
    it('Should return correct result when passing negative zero', () => {
        assert.equal(mathEnforcer.addFive(-0), 5);
    });
    it('Should return correct result when passing floating-point num', () => {
        assert.closeTo(mathEnforcer.addFive(10.12222), 15.12,0.01);
    });
    it('Should return undefined when passing not number', () => {
        assert.equal(mathEnforcer.addFive([]), undefined);
    });
});
describe('Subtract Ten Method', ()=> {
    it('Should is a function', () => {
        assert.isFunction(mathEnforcer.subtractTen);
    });
    it('Should return number when passing correct param', () => {
        assert.isNumber(mathEnforcer.subtractTen(10));
    });
    it('Should return correct result when passing correct param', () => {
        assert.equal(mathEnforcer.subtractTen(20), 10);
    });
    it('Should return correct result when passing negative num', () => {
        assert.equal(mathEnforcer.subtractTen(-20), -30);
    });
    it('Should return correct result when passing negative zero', () => {
        assert.equal(mathEnforcer.subtractTen(-0), -10);
    });
    it('Should return correct result when passing floating-point num', () => {
        assert.closeTo(mathEnforcer.subtractTen(10.12222), 0.12,0.01);
    });
    it('Should return undefined when passing not number', () => {
        assert.equal(mathEnforcer.subtractTen(undefined), undefined);
    });
});
describe('Sum Method',() => {
    it('Should is a function', () => {
        assert.isFunction(mathEnforcer.sum);
    });
    it('Should return number when passing correct param', () => {
        assert.isNumber(mathEnforcer.sum(10,10));
    });
    it('Should return correct result when passing correct param', () => {
        assert.equal(mathEnforcer.sum(20,20), 40);
    });
    it('Should return correct result when passing negative num to first param', () => {
        assert.equal(mathEnforcer.sum(-20,20), 0);
    });
    it('Should return correct result when passing negative nums', () => {
        assert.equal(mathEnforcer.sum(-20,-20), -40);
    });
    it('Should return correct result when passing negative zero', () => {
        assert.equal(mathEnforcer.sum(-0,-0), 0);
    });
    it('Should return correct result when passing floating-point num', () => {
        assert.closeTo(mathEnforcer.sum(10.12222, 20.12222), 30.24,0.01);
    });
    it('Should return undefined when passing not number to first param', () => {
        assert.equal(mathEnforcer.sum(undefined, 10), undefined);
    });
    it('Should return undefined when passing not number to second param', () => {
        assert.equal(mathEnforcer.sum(10,'0'), undefined);
    });
});