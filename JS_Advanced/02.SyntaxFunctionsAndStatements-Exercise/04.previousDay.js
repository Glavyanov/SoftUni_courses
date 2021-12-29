function solve(year, month,day){
    let date = new Date(Number(year),Number(month - 1),Number(day));
    date.setDate(date.getDate()-1);
    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}