class Bank {
    #bankName;
    constructor(bankName) {
        this.#bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer(customer) {
        if (this.allCustomers.some(x => x.firstName == customer.firstName && x.lastName === customer.lastName)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        customer.totalMoney = 0;
        customer.transactions = new Map();
        customer.transactionsCount = 0;
        this.allCustomers.push(customer);
        Object.defineProperties(customer, {
            totalMoney: {
                value: 0,
                enumerable: false,
            },
            transactions: {
                value: new Map(),
                enumerable: false,
            },
            transactionsCount: {
                value: 0,
                enumerable: false,
            },
        });
        return customer;
    }
    depositMoney(personalId, amount) {
        if (!this.allCustomers.some(x => x.personalId === personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        const customer = this.allCustomers.find(x => x.personalId === personalId);
        if (customer) {
            customer.totalMoney += amount;
            customer.transactions.set(++customer.transactionsCount, `${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`)
        }
        return `${customer.totalMoney}$`;
    }
    withdrawMoney(personalId, amount) {
        if (!this.allCustomers.some(x => x.personalId === personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        const customer = this.allCustomers.find(x => x.personalId === personalId);
        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }
        if (customer) {
            customer.totalMoney -= amount;
            customer.transactions.set(++customer.transactionsCount, `${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);
        }
        return `${customer.totalMoney}$`;
    }
    customerInfo(personalId) {
        if (!this.allCustomers.some(x => x.personalId === personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        const info = [];
        const customer = this.allCustomers.find(x => x.personalId === personalId);
        info.push(`Bank name: ${this.#bankName}`);
        info.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        info.push(`Customer ID: ${customer.personalId}`);
        info.push(`Total Money: ${customer.totalMoney}$`);
        info.push(`Transactions:`);
        for (const transact of [...customer.transactions.entries()].sort((a, b) => Number(b[0]) - Number(a[0]))) {
            info.push(`${transact[0]}. ${transact[1]}`);
        }
        return info.join('\n');
    }

}
let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

