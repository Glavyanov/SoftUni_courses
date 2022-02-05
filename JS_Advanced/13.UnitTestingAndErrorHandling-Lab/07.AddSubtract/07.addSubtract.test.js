const createCalculator = require('./07addSubtract.js');
const { assert } = require('chai');

describe('Test for 07addAndSubtract', () => {
    it('Should return Object when creating Claculator', () => {
        const calc = createCalculator();
        assert.isObject(calc);
    });
    it('Should return function when declaring prop add from Claculator', () => {
        const calc = createCalculator();
        const addProp = calc.add;
        assert.isFunction(addProp);
    });
    it('Should return function when declaring prop subtract from Claculator', () => {
        const calc = createCalculator();
        const subtractProp = calc.subtract;
        assert.isFunction(subtractProp);
    });
    it('Should return function when declaring prop get from Claculator', () => {
        const calc = createCalculator();
        const getProp = calc.get;
        assert.isFunction(getProp);
    });
    it('Should return number when using add prop', () => {
        const calc = createCalculator();
        calc.add(0);
        assert.isNumber(calc.get());
    });
    it('Should return zero when using get prop', () => {
        const calc = createCalculator();
        assert.equal(calc.get(), 0);
    });
    it('Should return correct value when using add prop', () => {
        const calc = createCalculator();
        calc.add(5);
        assert.equal(calc.get(), 5);
    });
    it('Should return number when using subtract prop', () => {
        const calc = createCalculator();
        calc.subtract(10.2);
        assert.isNumber(calc.get());
    });
    it('Should return correct value when using subtract prop', () => {
        const calc = createCalculator();
        calc.add(10);
        calc.subtract(5);
        assert.equal(calc.get(), 5);
    });
    it('Should return NaN when passing string in subtract and add prop', () => {
        const calc = createCalculator();
        calc.add('add');
        assert.isNaN(calc.get());
        calc.subtract('subtract');
        assert.isNaN(calc.get());
    });

});