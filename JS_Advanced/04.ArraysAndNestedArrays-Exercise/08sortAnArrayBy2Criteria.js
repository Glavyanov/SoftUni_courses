function solve(input) {
    console.log(input.sort((a, b) => a.length - b.length || a.localeCompare(b)).join('\n'));
}
