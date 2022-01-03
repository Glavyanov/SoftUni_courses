function solve(input) {
    console.log(input.filter((a, i) => i % 2 !== 0)
        .map(x => x * 2)
        .reverse()
        .join(' '));
}
