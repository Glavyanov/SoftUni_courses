function solve(input) {
    let products = [];
    for (const element of input) {
        let [town, product, price] = element.split(' | ');
        price = Number(price);
        let wanted = products.find(x => Object.keys(x)[0] === product);
        wanted ?  wanted[product][town] = price : products.push({ [product]: { [town]: price, }, });
        
    }

    for (const product of products) {
        for (const key in product) {
            let [town, price] = Object.entries(product[key]).sort((a, b) => a[1] - b[1])[0];
            console.log(`${key} -> ${price} (${town})`);
        }
    }
}