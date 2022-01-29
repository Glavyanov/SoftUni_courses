function solution(number){
    return (function add(a,b){
        return a + b;
    }).bind(null, number);
}
// function solution(num){
//     let result = '';
//     return function (num2){
//         result = `${num + num2}`;
//         return result; // with Closure
//     }
// }
// function solution(num){
//     return function (num2){
//         return num + num2;
//     }
// }
let add5 = solution(5);
console.log(add5(2)); // 7
console.log(add5(3)); // 8
console.log(add5(4)); // 9

