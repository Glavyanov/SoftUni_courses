function solve(input){
    return input.length > 1 ? Number(input[0]) + Number(input[input.length - 1]): Number(input[0]);
}