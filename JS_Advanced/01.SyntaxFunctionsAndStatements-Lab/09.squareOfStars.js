function solve(num = 5){
    let row ='';
    for (let index = 0; index < num; index++) {
        row += '* ';
    }
    row = row.substring(0,row.length - 1);
    for (let index = 0; index < num; index++) {
        console.log(row);
    }
}