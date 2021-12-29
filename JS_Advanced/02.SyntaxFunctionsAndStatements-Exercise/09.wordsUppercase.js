function solve(input){
    console.log(String(input).split(/\W+/).filter(x => x !== '').map(x=> x.toUpperCase()).join(', '));
}
