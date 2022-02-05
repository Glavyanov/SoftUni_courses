function solve(numbers, start, end) {
    if (!Array.isArray(numbers)) {
        return NaN;
    }

    let startIndex = Math.max(start,0);
    let endIndex = Math.min(end, numbers.length - 1);

    let subNumbers = numbers.slice(startIndex, endIndex + 1);

    let sum = subNumbers.reduce((a,b) => a + Number(b), 0);

    return sum;
}