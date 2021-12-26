function solve(num1,num2){
    let firstNum = Number(num1);
    let secondNum = Number(num2);
    let sum = 0;
    for (let index = firstNum; index <= secondNum; index++){
        sum += index;
    }
    return sum;
}