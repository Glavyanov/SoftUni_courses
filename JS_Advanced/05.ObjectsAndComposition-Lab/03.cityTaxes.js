function cityTaxes(name, population, treasury) {
    let result = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth(percentage) {
            this.population += Math.floor((percentage * this.population) / 100);
        },
        applyRecession(percentage) {
            this.treasury -= Math.ceil((percentage * this.treasury) / 100);
        },
    };
    return result;
}


