const flowerShop = require('./demo');
const assert = require('chai').assert;

describe("Tests flowerShop…", function() {
    describe("Method calcPriceOfFlowers …", function() {
        it("Should throw error when pass invalid type for flower …", function() {
            assert.throws(()=> flowerShop.calcPriceOfFlowers(10, 10, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers(-0, 10, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers({}, 10, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers(false, 10, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers(['flower'], 10, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers(undefined, 10, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers(null, 10, 10),Error,'Invalid input!');
        });
        it("Should throw error when pass invalid type for price …", function() {
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',1.01, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',2.55, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',22.99, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',-0.12, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',-1.12, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',NaN, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',[], 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',{}, 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower','flowers', 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower','', 10),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',undefined, 10),Error,'Invalid input!');
            
        });
        it("Should throw error when pass invalid type for quantity …", function() {
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, 1.99),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, 30.01),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, -1.999),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, 'flowers'),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, ''),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, undefined),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, NaN),Error,'Invalid input!');
            assert.throws(()=> flowerShop.calcPriceOfFlowers('flower',10, {}),Error,'Invalid input!');
        });
        it("Should work correct …", function() {
            assert.equal(flowerShop.calcPriceOfFlowers('foo',10,10),`You need $100.00 to buy foo!`);
            assert.equal(flowerShop.calcPriceOfFlowers('foo',1,200),`You need $200.00 to buy foo!`);
            assert.equal(flowerShop.calcPriceOfFlowers('foo',17,2003),`You need $34051.00 to buy foo!`);
            assert.equal(flowerShop.calcPriceOfFlowers('foo',-2017,2003),`You need $-4040051.00 to buy foo!`);
            assert.equal(flowerShop.calcPriceOfFlowers('foo',10,-1000),`You need $-10000.00 to buy foo!`);
            assert.equal(flowerShop.calcPriceOfFlowers('rose',0,1),`You need $0.00 to buy rose!`);
            assert.equal(flowerShop.calcPriceOfFlowers('rose',10,0),`You need $0.00 to buy rose!`);
        });
     });

     describe("Method checkFlowersAvailable …", function() {
        it("Should return flower are available …", function() {
            let arr = ['foo1','foo2','foo3','foo4','foo5'];
            let actual = flowerShop.checkFlowersAvailable('foo1',arr);
            assert.equal(actual,`The foo1 are available!`);
            actual = flowerShop.checkFlowersAvailable('foo1',arr);
            assert.equal(actual,`The foo1 are available!`);
            actual = flowerShop.checkFlowersAvailable('foo5',arr);
            assert.equal(actual,`The foo5 are available!`);
            actual = flowerShop.checkFlowersAvailable('foo3',arr);
            assert.equal(actual,`The foo3 are available!`);

            arr = ['foo'];
            actual = flowerShop.checkFlowersAvailable('foo',arr);
            assert.equal(actual,`The foo are available!`);

            arr = [-1,2,3,4];
            actual = flowerShop.checkFlowersAvailable(-1,arr);
            assert.equal(actual,`The -1 are available!`);

            let obj = {};
            arr = [obj,12,new Map(),[]];
            actual = flowerShop.checkFlowersAvailable(obj,arr);
            assert.equal(actual,`The ${obj} are available!`);

            arr = [-1,undefined];
            actual = flowerShop.checkFlowersAvailable(undefined,arr);
            assert.equal(actual,`The undefined are available!`);
            actual = flowerShop.checkFlowersAvailable(-1,arr);
            assert.equal(actual,`The -1 are available!`);
        });
        it("Should return flower are sold …", function() {
            let obj ={};
            let arr = ['foo1','foo2','foo3','foo4','foo5'];
            let actual = flowerShop.checkFlowersAvailable('foo12',arr);
            assert.equal(actual,`The foo12 are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable('foo',[]);
            assert.equal(actual,`The foo are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable({},arr);
            assert.equal(actual,`The ${obj} are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable('foo',['fo0']);
            assert.equal(actual,`The foo are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable(null,['fo0','null']);
            assert.equal(actual,`The null are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable(undefined,['fo0']);
            assert.equal(actual,`The undefined are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable(30,['fo0',80,'30']);
            assert.equal(actual,`The 30 are sold! You need to purchase more!`);
            actual = flowerShop.checkFlowersAvailable(-1,['fo0']);
            assert.equal(actual,`The -1 are sold! You need to purchase more!`);
        });
        
     });
     describe("Method sellFlowers …", function() {
        it("Should throw error when firts param is invalid …", function() {
            assert.throws(()=>flowerShop.sellFlowers('', 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(' ', 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers('symbol', 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(undefined, 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(0, 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(-1, 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(true, 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers({}, 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(new Set(), 2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(NaN, 2),Error,'Invalid input!');
        });
        it("Should throw error when second param is invalid …", function() {

            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], null),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], true),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], undefined),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], NaN),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], []),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], [0]),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], 0.5),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], 1.99),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], -0.98),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], '1'),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], '012'),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30']),Error,'Invalid input!');

        });
        it("Should throw error when second param is less of the bounds …", function() {

            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], -1),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30'], -2),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0'], -10),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0'], -1),Error,'Invalid input!');
        });

        it("Should throw error when second param is greater of the bounds …", function() {

            assert.throws(()=>flowerShop.sellFlowers(['fo0'], 1),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers([], 0),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30','foo1','foo2','foo23'], 6),Error,'Invalid input!');
            assert.throws(()=>flowerShop.sellFlowers(['fo0',80,'30','foo1','foo2','foo23','foo13'], 13),Error,'Invalid input!');
            
        });
        it("Should work correct …", function() {
            let arr = ['fo0',80,'30','foo1'];
            let actual = flowerShop.sellFlowers(arr, 1);
            assert.equal(actual, 'fo0 / 30 / foo1');
            actual = flowerShop.sellFlowers(arr, 3);
            assert.equal(actual, 'fo0 / 80 / 30');
            actual = flowerShop.sellFlowers(arr, 0);
            assert.equal(actual, '80 / 30 / foo1');
            actual = flowerShop.sellFlowers(arr, 2);
            assert.equal(actual, 'fo0 / 80 / foo1');

        });
        it("Should return empty string…", function() {
            let actual = flowerShop.sellFlowers(['foo'], 0);
            assert.equal(actual, '');
        });
        it("Should return only one flower…", function() {
            let actual = flowerShop.sellFlowers(['foo',false], 1);
            assert.equal(actual, 'foo');
        });
        it("Should return only two flower…", function() {
            let actual = flowerShop.sellFlowers(['foo',false,'test'], 1);
            assert.equal(actual, 'foo / test');
        });
     });
     
});