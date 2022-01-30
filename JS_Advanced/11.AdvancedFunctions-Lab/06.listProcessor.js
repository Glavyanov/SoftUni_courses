function listProcessor(input) {

    let result = [];
    let obj = {
        add(text) {
            result.push(text);
        },
        remove(text) {
            result = result.filter(x => x !== text);
        },
        print() {
            console.log(result.join(','));
        },
    };
    input.for(x => {
        let [cmd, text] = x.split(' ');
        obj[cmd](text);
    });

}

listProcessor(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);