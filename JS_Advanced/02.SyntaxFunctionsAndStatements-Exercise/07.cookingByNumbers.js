function solve(num, firstOp, secondOp, thirdOp, fourOp, fiveOp){
    let number = Number(num);
    number = (numOperation(number, firstOp));
    number = (numOperation(number, secondOp));
    number = (numOperation(number, thirdOp));
    number = (numOperation(number, fourOp));
    number = (numOperation(number, fiveOp));

    function numOperation(num, operation){
        switch (operation) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num++;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num *= 0.80;
                break;
        
            default:
                break;
        }
        console.log(num);
        return num;
        
    }
}
