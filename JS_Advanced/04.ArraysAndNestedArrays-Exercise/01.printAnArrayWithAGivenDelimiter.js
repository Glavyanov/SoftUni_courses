function solve(arr, del){
    let result = '';
    for (const item of arr) {
        result += item + del;
    }
    return result.substring(0,result.length - 1);
}