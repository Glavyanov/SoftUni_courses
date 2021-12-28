function solve(num) {
    let isSame = true;
    let sum = 0;
    numString = String(num);
    for (let index = numString.length - 1; index > 0; index--) {
        if (numString[index] != numString[index - 1]) {
            isSame = false;
        }
        sum += Number(numString[index]);
    }
    sum += Number(numString[0]);
    console.log(isSame);
    console.log(sum);
}