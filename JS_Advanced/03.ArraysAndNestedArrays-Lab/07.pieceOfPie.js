function solve(pies, firstPie, secondPie) {
    if (pies.includes(firstPie)) {
        let start = pies.indexOf(firstPie);
        let end = pies.indexOf(secondPie);
        return pies.slice(start, end + 1);
    }
}
