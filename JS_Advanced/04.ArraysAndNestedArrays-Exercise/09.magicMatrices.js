function solve(input){
    if (!input.length) {
        return false;
    }
    let sum = sumRow(input[0]);
    if (checkElements(input)) {
        input = input.map((row,i,arr) => arr.map(x => x[i]));
        if (!checkElements(input)) {
            return false;
        }
    }else{
        return false;
    }
    
    function sumRow(input){
        return input.reduce((acc,x) => acc + x,0);
    }
    function checkElements(input){
        for (let i = 1; i < input.length; i++) {
            let currentSum = sumRow(input[i]);
            if (sum !== currentSum) {
                return false;
            }
        }
        return true;
    }

    return true;
}