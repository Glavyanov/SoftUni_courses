function solve(input) {
    let result = [];
    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'add') {
            result.push(i + 1);
        } else if (input[i] === 'remove' && result.length > 0) {
            result.pop();
        }
    }
    result.length > 0 ? result.forEach(x => console.log(x)) : console.log('Empty');
}