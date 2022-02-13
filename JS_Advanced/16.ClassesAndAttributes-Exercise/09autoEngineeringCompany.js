function autoEngineering(arr) {
    const map = new Map();
    arr.forEach(x => {
        let [brand, model, count] = x.split(' | ');
        count = Number(count);
        if (map.has(brand)) {
            if(map.get(brand).has(model)){
                map.get(brand).set(model, map.get(brand).get(model) + count);
            } else {
                map.get(brand).set(model,count);
            }
        } else {
            map.set(brand, new Map());
            map.get(brand).set(model,count);
        }
    });
    let result = '';
    for (const [brand, models] of map.entries()) {
        result +=`${brand}\n`;
        for (const [model,count] of models.entries()) {
            result += `###${model} -> ${count}\n`;
        }
    }
    return result.trimEnd();
}

console.log(autoEngineering(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
));