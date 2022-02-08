class Stringer{
    constructor(text,number){
        this.innerString = text;
        this.innerLength = number;
    }
    increase(len){
        this.innerLength += len;
    }
    decrease(len){
        this.innerLength - len < 0 ? this.innerLength = 0 : this.innerLength -= len;
    }
    toString(){
        let result;
        if (!this.innerLength) {
            result =  '...';
        }else if(this.innerLength >= this.innerString.length){
            result = this.innerString;
        }else{
            result = this.innerString.slice(0,this.innerLength - this.innerString.length) + '...';
        }
        return result;
    }
}
let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(4);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
