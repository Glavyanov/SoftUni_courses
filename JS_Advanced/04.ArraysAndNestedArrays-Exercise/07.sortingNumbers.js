function solve(input){
    input.sort((a,b)=> a- b);
    let result = [];
    while (input.length > 0) {
        result.push(input.shift());
        if (input.length > 0) {
            result.push(input.pop());
        }
    }
    return result;
}