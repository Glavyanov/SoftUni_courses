function solve(input) {
    let matrix = [];
    for (let i = 0; i < input.length; i++) {
        let temparr = input[i].split(' ').map(x => Number(x));
        matrix[i] = temparr;
    }
    let sumLeftDiagonal = 0;
    let sumRightDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        sumLeftDiagonal += matrix[i][i];
    }
    for (let i = 0; i < matrix.length; i++) {
        for (let j = matrix.length - 1; j >= 0; j--) {
            sumRightDiagonal += matrix[i++][j];
        }
    }
    let clonedMatrix = [];
    for (let i = 0; i < matrix.length; i++) {
        clonedMatrix[i] = [...matrix[i]];
    }
    if (sumLeftDiagonal === sumRightDiagonal) {
        for (let i = 0; i < clonedMatrix.length; i++) {
            clonedMatrix[i].fill(sumLeftDiagonal, 0);
        }
        for (let i = 0; i < matrix.length; i++) {
            clonedMatrix[i][i] = matrix[i][i];
        }
        for (let i = 0; i < matrix.length; i++) {
            for (let j = matrix.length - 1; j >= 0; j--) {
                clonedMatrix[i][j] = matrix[i][j];
                i++;
            }
        }
    }
    for (const item of clonedMatrix) {
        console.log(item.join(' '));
    }
}