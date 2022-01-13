function solve(input){
    let products = [];
    for (const element of input) {
        let [town, product, price] = element.split(' | ');
        price = Number(price);
        if (products.some(x => Object.keys(x)[0] === product)) {
            products.map(x => {
                if(Object.keys(x)[0] === product){
                    x[product][town] = price;
                }
            })
        }else{
            let obj = Object.assign({[product]: Object.assign({ [town]: price,}), });
            products.push(Object.assign({},obj));
        }
    }

    for (const product of products) {
        for (const key in product) {
            let [town, price] = Object.entries(product[key]).sort((a,b)=> a[1] - b[1])[0];
             console.log(`${key} -> ${price} (${town})`);
        }
    }
}