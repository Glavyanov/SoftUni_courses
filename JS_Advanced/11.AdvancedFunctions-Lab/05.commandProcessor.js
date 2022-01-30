function solution(){
    let result ='';
    return{
        append(text){
            result += text;
        },
        removeStart(num){
            result = result.slice(num);
        },
        removeEnd(num){
            result = result.slice(0,-num);
        },
        print(){
            console.log(result);
        },
    }
}
let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print(); // 34

