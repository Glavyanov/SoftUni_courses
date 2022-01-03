function solve(input){
    let findedNum = input[0][0];
    input.forEach(searchRow);
    function searchRow(row){
        row.forEach(searchNum);
        function searchNum(num){
            if (num > findedNum) {
                findedNum =  num;
            }
        }
    }
    return findedNum;
}
