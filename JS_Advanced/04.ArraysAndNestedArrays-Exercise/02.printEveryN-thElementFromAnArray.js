function solve(arr, step){
    let resultArr = [];
    for(let i = 0; i < arr.length; i+=step){
        resultArr.push(arr[i]);
    }
    return resultArr;
}