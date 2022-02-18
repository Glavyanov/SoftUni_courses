    const companyAdministration = require('./companyAdministration');
    const { assert } = require('chai');
    describe("Tests companyAdministration", function () {
        describe("Method hiringEmployee", function () {
            it("Should is a function", function () {
                assert.isFunction(companyAdministration.hiringEmployee);
            });
            it("Should return string", function () {
                let actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', 4);
                assert.isString(actual);
                actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', 2);
                assert.isString(actual);
            });
            it("Should return string with success", function () {
                let actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', 4);
                assert.equal(actual, 'Ivo was successfully hired for the position Programmer.')
                actual = companyAdministration.hiringEmployee('Emo', 'Programmer', 2.99999999999999999);
                assert.equal(actual, 'Emo was successfully hired for the position Programmer.')
                actual = companyAdministration.hiringEmployee('Iva', 'Programmer', 3);
                assert.equal(actual, 'Iva was successfully hired for the position Programmer.')
                actual = companyAdministration.hiringEmployee(false, ['Programmer'], 100);
                assert.equal(actual, 'false was successfully hired for the position Programmer.')
            });
            it("Should return string with not approved", function () {
                let actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', '2');
                assert.equal(actual, 'Ivo is not approved for this position.');
                actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', 2.999);
                assert.equal(actual, 'Ivo is not approved for this position.');
                actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', NaN);
                assert.equal(actual, 'Ivo is not approved for this position.');
                actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', '-0');
                assert.equal(actual, 'Ivo is not approved for this position.');
                actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', []);
                assert.equal(actual, 'Ivo is not approved for this position.');
                actual = companyAdministration.hiringEmployee('Ivo', 'Programmer', -4);
                assert.equal(actual, 'Ivo is not approved for this position.');
                actual = companyAdministration.hiringEmployee(false, 'Programmer', 2);
                assert.equal(actual, 'false is not approved for this position.');
                assert.equal(companyAdministration.hiringEmployee('Ivo', 'Programmer', 1), 'Ivo is not approved for this position.');
                assert.equal(companyAdministration.hiringEmployee('Ivo', 'Programmer', 0), 'Ivo is not approved for this position.');
                assert.equal(companyAdministration.hiringEmployee('Ivo', 'Programmer', false), 'Ivo is not approved for this position.');
                assert.equal(companyAdministration.hiringEmployee('Ivo', 'Programmer', true), 'Ivo is not approved for this position.');
            });
            it("Should throw error", function () {
                assert.throws(() => companyAdministration.hiringEmployee('Ivo', 'Programm', '22'), Error, `We are not looking for workers for this position.`);
                assert.throws(() => companyAdministration.hiringEmployee('Ivo', 'Programm er', 10), Error, `We are not looking for workers for this position.`);
                assert.throws(() => companyAdministration.hiringEmployee('programmer', 10), Error, `We are not looking for workers for this position.`);
                assert.throws(() => companyAdministration.hiringEmployee('Ivo', '', 5), Error, `We are not looking for workers for this position.`);
                assert.throws(() => companyAdministration.hiringEmployee('Ivo', ' ', 5), Error, `We are not looking for workers for this position.`);
                assert.throws(() => companyAdministration.hiringEmployee('Ivo', ['Programmer '], 5), Error, `We are not looking for workers for this position.`);
                assert.throws(() => companyAdministration.hiringEmployee(), Error, `We are not looking for workers for this position.`);
            });
        });
        describe("Method calculateSalary", function () {
            it("Should is a function", function () {
                assert.isFunction(companyAdministration.calculateSalary);
            });
            it("Should return number", function () {
                let actual = companyAdministration.calculateSalary(40);
                assert.isNumber(actual);

            });
            it("Should work correct number", function () {
                assert.equal(companyAdministration.calculateSalary(1), 15);
                assert.equal(companyAdministration.calculateSalary(161), 3415);
                assert.equal(companyAdministration.calculateSalary(160), 2400);
                assert.equal(companyAdministration.calculateSalary(160.5), 3407.5);
                assert.equal(companyAdministration.calculateSalary(0), 0);
                assert.equal(companyAdministration.calculateSalary(0.88), 13.2);
                assert.equal(companyAdministration.calculateSalary(-[]), 0);
                assert.equal(companyAdministration.calculateSalary(-0), 0);
                
            });
            it("Should give a bonus", function () {
                assert.equal(companyAdministration.calculateSalary(161), 3415);
                assert.equal(companyAdministration.calculateSalary(160.5), 3407.5);
                assert.equal(companyAdministration.calculateSalary(400), 7000);
                assert.equal(companyAdministration.calculateSalary(800), 13000);
                
            });
            it("Should throw error when passing not a number", function () {
                let test = new Map();
                test.set(15);
                assert.throws(() => companyAdministration.calculateSalary('161'), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary('-[]'), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary('JS'), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(test), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary([20]), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary([]), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(true), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary({}), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(), Error, "Invalid hours");

            });
            it("Should throw error when passing negative number", function () {
                assert.throws(() => companyAdministration.calculateSalary(-0.9999), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(-42.42), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(-2000000000000000000000), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(-1), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(-5), Error, "Invalid hours");
                assert.throws(() => companyAdministration.calculateSalary(-20), Error, "Invalid hours");
            });
        });
        describe("Method firedEmployee", function () {
            it("Should is a function", function () {
                assert.isFunction(companyAdministration.firedEmployee);
            });
            it("Should return string", function () {
                let actual = companyAdministration.firedEmployee(['Ivo'], 0);
                assert.isString(actual);
                actual = companyAdministration.firedEmployee(['Ivo', 'Emo'], 1);
                assert.isString(actual);
            });
            it("Should return correct string", function () {
                let actual = companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], 1);
                assert.equal(actual, 'Ivo, Anna');
                actual = companyAdministration.firedEmployee(['Ivo', 33, 'Anna'], 2);
                assert.equal(actual, 'Ivo, 33');
                actual = companyAdministration.firedEmployee(['Ivo', 33, 'Ema'], 0);
                assert.equal(actual, '33, Ema');
                actual = companyAdministration.firedEmployee(['Ivo'], 0);
                assert.equal(actual, '');
            });
            it("Should throw error when passing not array to first parameter", function () {
                assert.throws(() => companyAdministration.firedEmployee({}, 1), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(NaN, 1), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(-42, 1), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(-1, 0), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(-3, 0), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(3), Error, "Invalid input");
            });
            it("Should throw error when passing not a integer number to second parameter", function () {
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], 1.2), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], -2.22), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], -1), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(), Error, "Invalid input");

            });
            it("Should throw error when passing not a number to second parameter", function () {
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], true), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], NaN), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], 'test'), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna']), Error, "Invalid input");
            });
            it("Should throw error when passing negative number to second parameter", function () {
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], -22), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], -0.999), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], -2), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(), Error, "Invalid input");

            });
            it("Should throw error when passing invalid number to second parameter", function () {
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], 3), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], 100), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna'], 4.4), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee('Ivo', 0), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(), Error, "Invalid input");

            });
            it("Should throw error when passing invalid parameters", function () {
                assert.throws(() => companyAdministration.firedEmployee(3), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(['Ivo', 'Emo', 'Anna']), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(false, 1), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee('Ivo', true), Error, "Invalid input");
                assert.throws(() => companyAdministration.firedEmployee(), Error, "Invalid input");
            });
        });

    });