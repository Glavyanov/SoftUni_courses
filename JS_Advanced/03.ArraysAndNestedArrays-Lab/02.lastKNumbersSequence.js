function solve(lenghtSqnce, count){
    let array = [];
    if (lenghtSqnce > 0) {
        array = [1];
    }
    let sum = 0;
    for (let i = 0; i < lenghtSqnce - 1; i++) {
        let index = i;
        for (let j = 0; j < count; j++) {
              let curr = array[index - (count - 1)];
              index++;
                if (curr) {
                    sum += curr;
                }else{
                    sum = 0;
                }
        }
        array.push(sum);
        sum = 0;
    }
    return array;
}