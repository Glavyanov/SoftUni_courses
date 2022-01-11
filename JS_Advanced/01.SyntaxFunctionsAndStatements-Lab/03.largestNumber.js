function solve(a,b,c){
    let maxNum;
    if(a > b && a > c){
        maxNum = a;    
    }else if(b> a && b > c){
          maxNum = b;
    }else if(c>b&& c> a){
        maxNum = c;
    }else{
        maxNum = a;
    }
    console.log(`The largest number is ${maxNum}.`);
}
solve(10,20,30);