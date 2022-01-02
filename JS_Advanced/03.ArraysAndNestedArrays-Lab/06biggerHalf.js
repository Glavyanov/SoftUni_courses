function solve(numArr){
    numArr.sort((a,b)=> a-b);
    let resultArr = numArr.slice(-1 * Math.ceil(numArr.length/2))
    return resultArr;
}