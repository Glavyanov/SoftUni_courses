function calculator() {
    let num1;
    let num2;
    let result;
    return {
        init(field1, field2, resultField) {
            num1 = document.querySelector(field1);
            num2 = document.querySelector(field2);
            result = document.querySelector(resultField);
        },
        add() {
            result.value = Number(num1.value) + Number(num2.value);
        },
        subtract() {
            result.value = Number(num1.value) - Number(num2.value);
        },
    }

}
const calculate = calculator();
calculate.init('#num1', '#num2', '#result');




