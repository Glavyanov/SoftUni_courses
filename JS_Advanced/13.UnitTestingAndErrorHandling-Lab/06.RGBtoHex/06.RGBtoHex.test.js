const rgbToHexColor = require('./06RGBtoHex');
const { assert } = require('chai');
// 87 / 100
describe('Tests for rgbToHexColor', () => {
    it('Should return #FE00C8 when passed correct parameters', () => {
        assert.strictEqual(rgbToHexColor(254, 0, 200), '#FE00C8');
    });
    it('Should return correct length when #FE00C8 passed', () => {
        assert.lengthOf(rgbToHexColor(254, 0, 200), 7);
    });
    it('Should return string when passed correct parameters', () => {
        assert.typeOf(rgbToHexColor(254, 0, 200), 'string');
    });
    it('Should return correct color when passed zero for Red Green Blue', () => {
        assert.equal(rgbToHexColor(0, 0, 0), '#000000');
    });
    describe('Red value is invalid', () => {
        it('Should return  undefined when red value is not a number', () => {
            assert.strictEqual(rgbToHexColor('20', 100, 50), undefined);
        });
        it('Should return  undefined when red value is a floating point number', () => {
            assert.strictEqual(rgbToHexColor(12.3, 100, 50), undefined);
        });
        it('Should return  undefined when red value is less than zero', () => {
            assert.strictEqual(rgbToHexColor(-1, 100, 50), undefined);
        });
        it('Should return  undefined when red value is greater than 255', () => {
            assert.strictEqual(rgbToHexColor(256, 100, 50), undefined);
        });
    });
    describe('Green value is invalid', () => {
        it('Should return  undefined when green value is not a number', () => {
            assert.strictEqual(rgbToHexColor(100, 'green', 50), undefined);
        });
        it('Should return  undefined when green value is a floating point number', () => {
            assert.strictEqual(rgbToHexColor(100, 254.9, 50), undefined);
        });
        it('Should return  undefined when green value is less than zero', () => {
            assert.strictEqual(rgbToHexColor(100, -100, 50), undefined);
        });
        it('Should return  undefined when green value is greater than 255', () => {
            assert.strictEqual(rgbToHexColor(100, 1000000, 50), undefined);
        });
    });
    describe('Blue value is invalid', () => {
        it('Should return  undefined when blue value is not a number', () => {
            assert.strictEqual(rgbToHexColor(100, 50, undefined), undefined);
        });
        it('Should return  undefined when blue value is a floating point number', () => {
            assert.strictEqual(rgbToHexColor(100, 50, 0.001), undefined);
        });
        it('Should return  undefined when blue value is less than zero', () => {
            assert.strictEqual(rgbToHexColor(100, 50, -100), undefined);
        });
        it('Should return  undefined when blue value is greater than 255', () => {
            assert.strictEqual(rgbToHexColor(100, 50, 301), undefined);
        });
    });
    describe('Red value is valid', () => {
        it('Should return  #FE when passed number 254 to red value ', () => {
            assert.strictEqual(rgbToHexColor(254, 100, 50).slice(0, 3), '#FE');
        });

    });
    describe('Green value is valid', () => {
        it('Should return 0 when passed number 0 to green value ', () => {
            assert.strictEqual(rgbToHexColor(254, 0, 50).slice(3, 4), '0');
        });

    });
    describe('Blue value is valid', () => {
        it('Should return C8 when passed number 200 to blue value ', () => {
            assert.strictEqual(rgbToHexColor(254, 0, 200).slice(5), 'C8');
        });

    });
    

});
