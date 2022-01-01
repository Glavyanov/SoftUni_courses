function solve(input){
    let result = '';
    for (let index = 0; index < input.length; index+=2) {
        result += input[index] + ' ';
    }
    console.log(result);
}