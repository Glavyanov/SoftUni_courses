function spiralMatrix(inputRow, inputCol) {
    let result = [];
    let border = inputRow * inputCol;
    let initial = 1;
    for (let i = 0; i < inputRow; i++) {
        result[i] = [];
        for (let j = 0; j < inputCol; j++) {
            result[i][j] = 0;
        }
    }

    while (initial <= border) {
        initial = right(result, inputRow, inputCol, initial);
        initial = down(result, inputRow, inputCol, initial);
        initial = left(result, inputRow, inputCol, initial);
        initial = up(result, inputRow, inputCol, initial);
        inputRow--;
        inputCol--;

    }

    function right(matrix, row, col, init) {
        let currentRow = Math.abs(row - matrix.length);
        for (let j = 0; j < col; j++) {
            if (!matrix[currentRow][j]) {
                matrix[currentRow][j] = init++;
            }
        }
        return init;
    }
    function down(matrix, row, col, init) {
        let currentRow = Math.abs(row - matrix.length) + 1;
        for (let i = currentRow; i < col; i++) {
            if (!matrix[i][col - 1]) {
                matrix[i][col - 1] = init++;
            }
        }
        return init;
    }
    function left(matrix, row, col, init) {
        for (let j = col - 2; j >= 0; j--) {
            if (!matrix[row - 1][j]) {
                matrix[row - 1][j] = init++;
            }
        }
        return init;
    }
    function up(matrix, row, col, init) {
        col = Math.abs(col - matrix.length)
        for (let j = row - 2; j >= 0; j--) {
            if (!matrix[j][col]) {
                matrix[j][col] = init++;
            }
        }
        return init;
    }
    result.forEach(x => console.log(x.join(' ')));
}
spiralMatrix(5, 5);