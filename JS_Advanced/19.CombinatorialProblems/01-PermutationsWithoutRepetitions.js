const permutations = function (input) {

    b = [];

    function Permute(idx, innerInput) {
        if (idx >= innerInput.length) {
            b.push([...innerInput]);
            return;
        }

        Permute(idx + 1, innerInput);

        for (let i = idx + 1; i < innerInput.length; i++) {
            Swap(idx, i, innerInput);
            Permute(idx + 1, innerInput);
            Swap(idx, i, innerInput);
        }
    }

    function Swap(idx, ic, swapInput) {
        temp = swapInput[idx];
        swapInput[idx] = swapInput[ic];
        swapInput[ic] = temp;
    }

    Permute(0, input);
    return b;
}

permutations(["A","B","C"]).forEach(element => {
    console.log(element.join(' '));
});
    /*A B C
      A C B
      B A C
      B C A
      C B A
      C A B*/ 
