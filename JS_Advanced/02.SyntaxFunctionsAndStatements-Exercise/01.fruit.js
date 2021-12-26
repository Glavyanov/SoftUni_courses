function solve(fruit, weightInGrams, price){
    return `I need $${((weightInGrams*price)/1000).toFixed(2)} to buy ${(weightInGrams/1000).toFixed(2)} kilograms ${fruit}.`;
}