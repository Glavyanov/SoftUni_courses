function add(num) {
    let sum = 0;

    function inner(num1) {
        sum += num1;
        return inner;
    }
    inner.toString = () => sum;
    return inner(num);
}
console.log(add(1)(6)(-3)(13)(-10).toString());