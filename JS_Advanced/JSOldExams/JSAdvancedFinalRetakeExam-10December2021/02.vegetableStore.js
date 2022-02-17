class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }
    loadingVegetables(vegetables) {
        let products = new Set();
        for (const vegetable of vegetables) {
            let [type, quantity, price] = vegetable.split(' ');
            price = Number(price);
            quantity = Number(quantity);
            products.add(type);
            let availableVegetable = this.availableProducts.find(x => x.type == type);
            if (availableVegetable) {
                availableVegetable.quantity += quantity;
                availableVegetable.price < price ? availableVegetable.price = price : availableVegetable.price;
            } else {
                this.availableProducts.push({
                    type,
                    quantity,
                    price,
                })
            }
        }
        return `Successfully added ${Array.from(products).join(', ')}`;

    }
    buyingVegetables(selectedProducts) {
        let totalPrice = 0;
        for (const product of selectedProducts) {
            let [type, quantity] = product.split(' ');
            quantity = Number(quantity);
            const currentProduct = this.availableProducts.find(x => x.type == type);
            if (!currentProduct) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }
            if (currentProduct.quantity < quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }
            totalPrice += currentProduct.price * quantity;
            currentProduct.quantity -= quantity;

        }
        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }
    rottingVegetable(type, quantity) {
        const currentProduct = this.availableProducts.find(x => x.type == type);
        if (!currentProduct) {
            throw new Error(`${type} is not available in the store.`);
        }
        if (currentProduct.quantity <= quantity) {
            currentProduct.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }
        currentProduct.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;

    }
    revision() {
        let revision = ['Available vegetables:'];
        for (const product of this.availableProducts.sort((a, b) => a.price - b.price)) {
            revision.push(`${product.type}-${product.quantity}-$${product.price}`);
        }
        revision.push(`The owner of the store is ${this.owner}, and the location is ${this.location}.`)
        return revision.join('\n');
    }
}
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());



