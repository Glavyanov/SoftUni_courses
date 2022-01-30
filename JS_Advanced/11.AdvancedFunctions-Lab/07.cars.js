function cars(arr) {
    const store = [];
    const factory = {
        create(model) {
            return {
                [model]: {},
            }
        },
        createInherit: (model) => (parentModel) => {
            return {
                [model]: {},
                parent: store.find(x => x[parentModel]),
            }
        },
        set(model, key, value) {
            let obj = store.find(x => x[model]);
            obj[model][key] = value;
        },
        print(model) {
            let printArr = [];

            Object.entries(store.find(x => x[model])).forEach(x => {
                if (x[0] !== 'parent') {
                    for (const key in x[1]) {
                        printArr.push(`${key}:${x[1][key]}`);
                    }
                } else {
                    for (const key in x[1]) {
                        if (key !== 'parent') {
                            let obj = Object.values(store.find(y => y[key])).shift();

                            for (const key in obj) {
                                printArr.push(`${key}:${obj[key]}`);
                            }
                        }else{
                            let final = Object.values(x[1][key]);
                            for (const key1 in final[0]) {
                                printArr.push(`${key1}:${final[0][key1]}`);
                            }
                        }
                    }
                }
            });
            console.log(printArr.join(','));
        }
    }
    arr.forEach(x => {
        let elements = x.split(' ');
        if (elements.length == 2) {
            elements[0] == 'create' ? store.push(factory.create(elements[1])) : factory.print(elements[1]);
        } else if (elements.length == 4) {
            elements[0] == 'create' ? store.push(factory.createInherit(elements[1])(elements[3]))
                : factory.set(...elements.slice(1));
        }
    });

}
cars(['create pesho','create gosho inherit pesho','create stamat inherit gosho','set pesho rank number1','set gosho nick goshko','print stamat']
); // nick:goshko,rank:number1
