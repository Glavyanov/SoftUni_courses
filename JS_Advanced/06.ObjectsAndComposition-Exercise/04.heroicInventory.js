function solve(input){
    let result = [];
    for (const element of input) {
        let [name, level, items] = element.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];
        result.push({name, level, items});
    }
    const totalResult = JSON.stringify(result);
    console.log(totalResult);

}