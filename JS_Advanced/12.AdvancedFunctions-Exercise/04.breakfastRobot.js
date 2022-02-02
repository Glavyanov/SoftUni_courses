function solution() {
    let protein = 0;
    let carbohydrate = 0;
    let fat = 0;
    let flavour = 0;

    return function (input) {
        let [cmd, meal, qnty] = [...input.split(' ')];
        let obj = {
            restock(meal, qnty) {
                switch (meal) {
                    case 'protein':
                        protein += Number(qnty);
                        break;
                    case 'carbohydrate':
                        carbohydrate += Number(qnty);
                        break;
                    case 'fat':
                        fat += Number(qnty);
                        break;
                    case 'flavour':
                        flavour += Number(qnty);
                        break;
                    default:
                        break;
                }
                return 'Success';
            },
            prepare(meal, qnty) {
                let currentQnty = Number(qnty);
                let currentCarbohydrate = carbohydrate;
                let currentFlavour = flavour;
                let currentFat = fat;
                let currentProtein = protein;
                let flag = true;
                let message;
                switch (meal) {
                    case 'apple':
                        while (currentQnty) {
                            if (carbohydrate >= 1 && flavour >= 2) {
                                carbohydrate -= 1;
                                flavour -= 2;
                            } else {
                                flag = false;
                                message = `Error: not enough ${carbohydrate >= 1 ? 'flavour' : 'carbohydrate'} in stock`;
                                break;
                            }
                            currentQnty--;
                        }
                        if (flag) {
                            return 'Success';

                        } else {
                            carbohydrate = currentCarbohydrate;
                            flavour = currentFlavour;
                            return message;
                        }
                    case 'lemonade':
                        while (currentQnty) {
                            if (carbohydrate >= 10 && flavour >= 20) {
                                carbohydrate -= 10;
                                flavour -= 20;

                            } else {
                                flag = false;
                                message = `Error: not enough ${carbohydrate >= 10 ? 'flavour' : 'carbohydrate'} in stock`;
                                break;
                            }
                            currentQnty--;
                        }
                        if (flag) {
                            return 'Success';

                        } else {
                            carbohydrate = currentCarbohydrate;
                            flavour = currentFlavour;
                            return message;
                        }

                    case 'burger':
                        while (currentQnty) {
                            if (carbohydrate >= 5 && flavour >= 3 && fat >= 7) {
                                carbohydrate -= 5;
                                flavour -= 3;
                                fat -= 7;

                            } else {
                                flag = false;
                                message = `Error: not enough ${carbohydrate < 5 ? 'carbohydrate' : fat < 7 ? 'fat' : 'flavour'} in stock`;
                                break;
                            }
                            currentQnty--;
                        }
                        if (flag) {
                            return 'Success';

                        } else {
                            carbohydrate = currentCarbohydrate;
                            flavour = currentFlavour;
                            fat = currentFat;
                            return message;
                        }

                    case 'eggs':
                        while (currentQnty) {
                            if (protein >= 5 && flavour >= 1 && fat >= 1) {
                                protein -= 5;
                                flavour -= 1;
                                fat -= 1;

                            } else {
                                flag = false;
                                message = `Error: not enough ${protein < 5 ? 'protein' : flavour < 1 ? 'flavour' : 'fat'} in stock`;
                                break;
                            }

                            currentQnty--;
                        }
                        if (flag) {
                            return 'Success';

                        } else {
                            protein = currentProtein;
                            flavour = currentFlavour;
                            fat = currentFat;
                            return message;
                        }

                    case 'turkey':
                        while (currentQnty) {
                            if (protein >= 10 && carbohydrate >= 10 && fat >= 10 && flavour >= 10) {
                                protein -= 10;
                                flavour -= 10;
                                fat -= 10;
                                carbohydrate -= 10;

                            } else {
                                flag = false;
                                message = `Error: not enough ${protein < 10 ? 'protein' : carbohydrate < 10 ? 'carbohydrate'
                                    : fat < 10 ? 'fat' : 'flavour'} in stock`;
                                break;
                            }

                            currentQnty--
                        }
                        if (flag) {
                            return 'Success';

                        } else {
                            carbohydrate = currentCarbohydrate;
                            protein = currentProtein;
                            flavour = currentFlavour;
                            fat = currentFat;
                            return message;
                        }

                    default:
                        break;
                }

            },
            report() {
                return `protein=${protein} carbohydrate=${carbohydrate} fat=${fat} flavour=${flavour}`
            },
        };
        return obj[cmd](meal, qnty);
    }

}

let manager = solution();

console.log(manager("prepare turkey 1")); // Error: not enough protein in stock
console.log(manager("restock protein 10"));  // Success
console.log(manager("prepare turkey 1"));  // Error: not enough carbohydrate in stock 
console.log(manager("restock carbohydrate 10"));  // Success 
console.log(manager("prepare turkey 1"));  // Error: not enough fat in stock 
console.log(manager("restock fat 10"));  // Success 
console.log(manager("prepare turkey 1"));  // Error: not enough flavour in stock 
console.log(manager("restock flavour 10"));  // Success 
console.log(manager("prepare turkey 1"));  // Success
console.log(manager("report"));  // protein=0 carbohydrate=0 fat=0 flavour=0

