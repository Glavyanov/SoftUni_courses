function solve(numArray){
    let resultArray = [];
    for (const num of numArray) {
        if (num < 0) {
            resultArray.unshift(num);
        }else{
            resultArray.push(num);
        }
        
    }
    for (const num of resultArray) {
        console.log(num);
    }
}