class ChristmasDinner {
    #budget;
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }
    get budget() {
        return this.#budget;
    }
    set budget(value) {
        if (value < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        this.#budget = value;
    }
    shopping(product) {
        let [type, price] = product;
        if (price > this.budget) {
            throw new Error("Not enough money to buy this product");
        }
        this.products.push(type);
        this.budget -= price;
        return `You have successfully bought ${type}!`;
    }
    recipes(recipe) {
        let { recipeName, productsList } = recipe;

        for (const product of productsList) {
            if (!this.products.some(x => x === product)) {
                throw new Error("We do not have this product");
            }
        }
        this.dishes.push({ recipeName, productsList })
        return `${recipeName} has been successfully cooked!`;
    }
    inviteGuests(name, dish) {
        const dishAvailable = this.dishes.find(x => x.recipeName === dish);
        if (!dishAvailable) {
            throw new Error("We do not have this dish");
        }
        if (this.guests.hasOwnProperty(name)) {
            throw new Error("This guest has already been invited");
        }
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`
    }
    showAttendance() {
        const result = [];
        for (const key in this.guests) {
            const dishAvailable = this.dishes.find(x => x.recipeName === this.guests[key]);
            result.push(`${key} will eat ${this.guests[key]}, which consists of ${dishAvailable.productsList.join(', ')}`);
        }
        return result.join('\n');
    }
}
let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());