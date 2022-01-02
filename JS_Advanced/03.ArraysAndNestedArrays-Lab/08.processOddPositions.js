function solve(input) {
    console.log(input.filter((a, i) => i % 2 !== 0)
        .map(x => x * 2)
        .reverse()
        .join(' '));
}
solve([3, 0, 10, 4, 7, 3]);
// let resultArr = input.filter(function(num,index){
    //     if (index % 2 !== 0) {
    //         return num;// това не връща нулата защото е Falsy и няма да решим зачата!
    //     }
    // }).reverse();
    // console.log(resultArr.join(' ')); 
    //.map(x=> String(x))
    //.map(x=> Number(x) * 2) // трябва да се добавят тези за да се избегне Falsy нулата и да работи с return
    //ако се използва функцията без return както по-долу нулата минава през проверката за true;