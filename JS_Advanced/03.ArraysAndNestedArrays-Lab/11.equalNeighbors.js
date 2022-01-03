function solve(input) {
    let equalPairs = 0;
    for (let i = 0; i < input.length; i++) {
        for (let j = 0; j < input[i].length - 1; j++) {
            if (input[i][j] === input[i][j + 1]) {
                equalPairs++;
            }
            if (i <= input.length - 2) {
                if (input[i][j] === input[i + 1][j]) {
                    equalPairs++;
                }
                if (j == input[i].length - 2) {
                    if (input[i][j + 1] === input[i + 1][j + 1]) {
                        equalPairs++;
                    }
                }
            }
        }
    }
    return equalPairs;
}