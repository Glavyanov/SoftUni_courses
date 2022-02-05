function argumentInfo(...allArguments) {
    //let allArguments = Array.from(arguments); //using arguments in function
    let obj = {};
    allArguments.forEach(x => {
        console.log(`${typeof x}: ${x}`);
        if (!obj[typeof x]) {
            obj[typeof x] = 0;
        }
        obj[typeof x]++;

    });
    for (const element of Object.entries(obj).sort((a, b) => b[1] - a[1])) {
        console.log(`${element[0]} = ${element[1]}`);
    }
}
argumentInfo('cat', 42, 43, function () { console.log('Hello world!'); }, 'catt');