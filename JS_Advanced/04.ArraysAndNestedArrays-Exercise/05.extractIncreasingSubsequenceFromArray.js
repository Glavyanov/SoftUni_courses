function solve(input){
    let max = input[0] - 1;
    let result = input.reduce((acc,el) => {
        if (el >= max) {
            max = el;
            acc.push(el);
        }
        return acc;
    },[]);
    return result;
}