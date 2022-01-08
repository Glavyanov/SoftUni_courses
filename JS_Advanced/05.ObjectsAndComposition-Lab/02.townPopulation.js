function solve(input) {
    let cities = input.reduce((acc, curr) => {
        let [name, population] = curr.split(' <-> ').map(x => x.trim()).map((x, i) => i % 2 !== 0 ? Number(x) : x);
        if (!acc[name]) {
            acc[name] = 0;
        }
        acc[name] += population;
        return acc;
    }, {});
    for (let city in cities) {
        console.log(`${city} : ${cities[city]}`);
    }
    console.log(cities);
}