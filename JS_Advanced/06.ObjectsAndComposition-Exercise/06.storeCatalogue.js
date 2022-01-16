function solve(arr) {
    let catalogue = {};
    arr.forEach(x => {
        let [product, price] = x.split(' : ').map((x, i) => i % 2 != 0 ? Number(x) : x);
        let initial = product[0];
        catalogue.hasOwnProperty(initial) ? catalogue[initial][product] = price : catalogue[initial] = {[product]: price};
    });
    let sortedCapitals = Object.keys(catalogue).sort((a,b) => a.localeCompare(b));
    let result = [];
    for (let i = 0; i < sortedCapitals.length; i++) {
        if (catalogue.hasOwnProperty(sortedCapitals[i])) {
            result.push(sortedCapitals[i]);
            let products = catalogue[sortedCapitals[i]];
            products  = Object.entries(products).sort((a,b) => a[0].localeCompare(b[0])).forEach(x => {
                result.push(`  ${x[0]}: ${x[1]}`);
            });
           
        }
    }
    return result.join('\n');
}
