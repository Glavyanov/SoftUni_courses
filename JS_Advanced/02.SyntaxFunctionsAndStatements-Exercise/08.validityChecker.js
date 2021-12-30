function solve(x1, y1, x2, y2) {
    
    let num1 = Math.sqrt((Math.pow((0 - x1),2)) + (Math.pow((0 - y1),2)));
    let num2 = Math.sqrt((Math.pow((0 - x2),2)) + (Math.pow((0 - y2),2)));
    let num3 = Math.sqrt((Math.pow((x2 - x1),2)) + (Math.pow((y2 - y1),2)));
    let num1Validate = Number.isInteger(num1) ? 'valid': 'invalid';
    let num2Validate = Number.isInteger(num2) ? 'valid': 'invalid';
    let num3Validate = Number.isInteger(num3) ? 'valid': 'invalid';
    print(x1,y1, 0, 0, num1Validate);
    print(x2,y2, 0, 0, num2Validate);
    print(x1,y1, x2, y2, num3Validate);
    function print(x1,y1,x2,y2, validate){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${validate}`);
    }
}
