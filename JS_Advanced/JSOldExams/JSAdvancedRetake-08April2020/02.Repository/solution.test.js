let { Repository } = require("../solution.js");
const assert = require('chai').assert;

describe("Tests for Repository",  () => {
    describe("Constructor should work correct",  () =>{
        it('Should function',()=>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            assert.isFunction(Repository);
        });
        it("Should return object ",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.isObject(repository);
        });
        it("Should return instance ",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.instanceOf(repository , Repository);
        });
        it("Should initialize props correct",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.deepEqual(properties, repository.props);
        });
        it("Should return props correct",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.isObject(repository.props);
        });
        it("Should initialize property data correct",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.instanceOf(repository.data, Map);
        });
        it("Should initialize property data correct size",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.equal(repository.data.size, 0);
        });
        it("Should initialize function nextId correct",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.isFunction(repository.nextId);
        });
        it("Should function nextId working correct",  () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.equal(repository.nextId(), 0);
        });
    });
    describe('Get count should work correct', () => {
        it('Should return zero when init',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repository = new Repository(properties);
            assert.equal(repository.count, 0);
        });
        it('Should return correct count when adding valid entity',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entitys = {
                name: "Peshos",
                age: 222,
                birthday: new Date(1994, 0, 7)
            };
            let repository = new Repository(properties);
            repository.add(entity);
            repository.add(entitys);
            assert.equal(repository.count, 2);
        });
    });
    describe('Method Add should work correct',()=>{
        it('Should is function',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.isFunction(repository.add);
        });
        it('Should return correct id',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.equal(repository.add(entity),0);
        });
        it('Should return correct entity',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entitys = {
                name: "Peshoo",
                age: 23,
                birthday: new Date(1994, 0, 7)
            };
            repository.add(entity);
            repository.add(entitys);
            assert.deepEqual(repository.data.get(1),entitys);
        });
    });
    describe('Method Add should throw erors',()=>{
        it('when adding entity with missing property',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.throws(()=> repository.add(entity),Error,'Property name is missing from the entity!');
        });
        it('when adding entity with invalid type for name',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: undefined,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.throws(()=> repository.add(entity),Error,'Property name is not of correct type!');
        });
    });
    describe('Method getId should work correct',()=>{
        it('should is function ',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            assert.isFunction(repository.getId);
        });
        it('should return object ',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            assert.isObject(repository.getId(0));
        });
        it('should return correct object',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            assert.deepEqual(repository.getId(0),entity);
        });
    });
    describe('Method getId should throw erors',()=>{
        it('when trying get entity with missing id',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            assert.throws(()=> repository.getId(33),Error,'Entity with id: 33 does not exist!');
           
        });
        
    });
    describe('Method update should work correct',()=>{
        it('should is function ',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            assert.isFunction(repository.update);
        });
        it('when trying get entity with missing id',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            entity = {
                name: "Peshof",
                age: 224,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            let entitys = {
                name: "Peshoff",
                age: 33,
                birthday: new Date(1997, 0, 7)
            };
            repository.update(1,entitys)
            assert.deepEqual(repository.getId(1), entitys);
           
        });
    });
    describe('Method update should throws error',()=>{
        it('when trying update entity with invalid new entity',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            let entitys = {
                name: "Peshof",
                age: 224,
                
            };
            assert.throws(()=>repository.update(0,entitys),Error,'Property birthday is missing from the entity!');
        });
        it('when trying update entity with invalid property type of new entity',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7),
            };
            repository.add(entity);
            let entitys = {
                name: "Peshof",
                age: 224,
                birthday: true,
            };
            assert.throws(()=>repository.update(0,entitys),Error,'Property birthday is not of correct type!');
        });
        it('when trying update entity with missing id',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            
            let entitys = {
                name: "Peshoff",
                age: 33,
                birthday: new Date(1997, 0, 7)
            };
            assert.throws(()=>repository.update(22,entitys),Error,'Entity with id: 22 does not exist!');
        });
    });
    describe('Method del should work correct',()=>{
        it('should is function ',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            assert.isFunction(repository.del);
        });
        it('when trying delete entity with correct id',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            
            repository.add(entity);
            let entitys = {
                name: "Peshoff",
                age: 33,
                birthday: new Date(1997, 0, 7)
            };
            repository.add(entitys);
            repository.del(1);
            assert.equal(repository.count, 1);
           
        });
    });
    describe('Method del should throw error',()=>{
        it('when trying delete entity with incorrect id',() =>{
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
           
            let repository = new Repository(properties);
            
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            
            repository.add(entity);
            let entitys = {
                name: "Peshoff",
                age: 33,
                birthday: new Date(1997, 0, 7)
            };
            repository.add(entitys);
            
            assert.throws(()=> repository.del(10),Error,'Entity with id: 10 does not exist!');
           
        });
    });
});
