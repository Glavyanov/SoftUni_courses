function solve(input) {
    return input.reduce((acc, el, i) => {
        if (i % 2 !== 1) {
            acc[input[i]] = Number(input[i + 1]);
        }
        return acc;
    }, {})
}