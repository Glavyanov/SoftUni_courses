function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}
// const cal = createCalculator();
// cal.add(5);
// console.log(cal.get());
module.exports = createCalculator;
