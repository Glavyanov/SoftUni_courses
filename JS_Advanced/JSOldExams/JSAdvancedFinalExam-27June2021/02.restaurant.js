class Restaurant {
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }
    loadProducts(products) {
        products.forEach(p => {
            let [name, qnty, price] = p.split(' ');
            qnty = Number(qnty);
            price = Number(price);
            if (price > this.budgetMoney) {
                this.history.push(`There was not enough money to load ${qnty} ${name}`)

            } else {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = 0;
                }
                this.stockProducts[name] += qnty;
                this.budgetMoney -= price;
                this.history.push(`Successfully loaded ${qnty} ${name}`);
            }
        });
        return this.history.join('\n');
    }
    addToMenu(meal, neededProducts, price) {
        if (this.menu[meal]) {
            return `The ${meal} is already in the our menu, try something different.`;
        }
        neededProducts = neededProducts.map(p => {
            if (p.split(' ').length > 2) {
                let pLength = p.split(' ').length;
                let result = '';
                p = p.split(' ').reduce((acc, curr, i) => {
                    if (i !== pLength - 1) {
                        result += curr + ' ';
                    } else {
                        acc.push(result.trimEnd());
                        acc.push(curr);
                    }
                    return acc;
                }, []).map((x, i) => i % 2 == 0 ? x : Number(x));
            } else {
                p = p.split(' ').map((x, i) => i % 2 == 0 ? x : Number(x));
            }
            return p;
        })
        this.menu[meal] = {
            products: neededProducts,
            price,
        }
        const meals = Object.keys(this.menu);
        if (meals.length > 1) {
            return `Great idea! Now with the ${meal} we have ${meals.length} meals in the menu, other ideas?`;
        }

        return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;

    }
    showTheMenu() {
        const message = []
        if (!Object.keys(this.menu).length) {
            return 'Our menu is not ready yet, please come later...';
        }
        for (const meal in this.menu) {
            message.push(`${meal} - $ ${this.menu[meal].price}`)
        }
        return message.join('\n');
    }
    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        for (const product of this.menu[meal].products) {
            if (!this.stockProducts[product[0]] || this.stockProducts[product[0]] < product[1]) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }
        this.menu[meal].products.forEach(p => {

        });
        this.menu[meal].products.forEach(p => {
            this.stockProducts[p[0]] -= p[1];
        });
        this.budgetMoney += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`
    }
}
let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.showTheMenu());
console.log(kitchen.makeTheOrder('Pizza'));

