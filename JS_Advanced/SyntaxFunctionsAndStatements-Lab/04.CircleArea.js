function solve(a){
    if (typeof(a) !== 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof a}.`);
    }else{
        console.log((Math.PI * a * a).toFixed(2));
    }
}