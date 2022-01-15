function solve(input){
    input.sort((a,b)=> a- b);
    let result = [];
    while (input.length) {
        result.push(input.shift());
        if (input.length) {
            result.push(input.pop());
        }
    }
    return result;
}