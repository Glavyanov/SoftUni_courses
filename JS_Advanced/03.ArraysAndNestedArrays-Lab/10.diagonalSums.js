function solve(input){
    let leftDiagonal = 0;
    let rightDiagonal = 0;
    for (let i = 0; i < input.length; i++) {
        leftDiagonal += input[i][i];
    }
    for (let i = 0; i < input.length; i++) {
        for(let j = input.length - 1; j>=0; j--){
            rightDiagonal += input[i][j];
            i++;
        }
    }
    console.log(`${leftDiagonal} ${rightDiagonal}`);
}
