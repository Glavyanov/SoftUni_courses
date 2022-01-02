function solve(inputArr){
    inputArr.sort((a,b)=> a-b);
    console.log(`${inputArr[0]} ${inputArr[1]}`);
}
solve([3, 0, 10, 4, 7, 3]);