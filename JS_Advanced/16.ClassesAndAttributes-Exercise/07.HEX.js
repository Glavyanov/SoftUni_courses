class Hex {
    constructor(num){
        this.number = num;
    }
    toString(){
        return `0x${this.number.toString(16).toUpperCase()}`;
    }
    valueOf(){
        return this.number;
    }
    plus(obj){

        return new Hex(this.number + obj.valueOf());
    }
    minus(obj){
        return new Hex(this.number - obj.valueOf());
    }
    static parse(str){

        return parseInt(str, 16);
    }
}
let FF = new Hex(255);
console.log(FF.toString()); //0xFF
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString()); //0xF
console.log(a.plus(b).toString()==='0xF'); //true
console.log(Hex.parse('AAA')); // 2730

