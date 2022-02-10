function juiceFlavours(arr) {
    let resultmap = new Map();
    let currentmap = new Map();
    arr.forEach(x => {
        let [product, quant] = x.split(' => ');
        quant = Number(quant);
        if (currentmap.has(product)) {
            quant += currentmap.get(product);
            currentmap.delete(product);
        }
        if (quant >= 1000) {

            let reminder = Math.round(((quant / 1000) % 1) * 1000);
            if (resultmap.has(product)) {
                resultmap.set(product, resultmap.get(product) + Math.trunc(quant / 1000));
            } else {
                resultmap.set(product, Math.trunc(quant / 1000));
            }
            if (reminder) {
                if (currentmap.has(product)) {
                    currentmap.set(product, currentmap.get(product) + reminder);
                } else {
                    currentmap.set(product, reminder);
                }
            }

        } else {
            if (currentmap.has(product)) {
                currentmap.set(product, currentmap.get(product) + quant);
            } else {
                currentmap.set(product, quant);
            }
        }

    })
    let result = '';
    for (const [key, value] of resultmap) {
        result += `${key} => ${value}\n`;
    }
    return result.trimEnd();
}

console.log(juiceFlavours(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',      //    Pear => 8
    'Kiwi => 4567',            //    Watermelon => 10
    'Pear => 5678',            //    Kiwi => 4
    'Watermelon => 6789']
));
console.log(juiceFlavours(
    ['Orange => 2000',
        'Peach => 1432',          // Orange => 2
        'Banana => 450',          // Peach => 2
        'Peach => 600',
        'Strawberry => 549']
)); 