class Circle {
    constructor(r) {
        this.radius = Number(r);
    }
    get diameter() {
        return this.radius * 2;
    }
    set diameter(value) {
        if (Number(value) < 0) {
            throw new Error('Invalid value for diameter');
        }
        this.radius = Number(value) / 2;
    }
    get area() {
        return Math.PI * (this.radius ** 2);
    }
    set area(value) {
        if (Number(value) < 0) {
            throw new Error('Invalid value for area');
        }
        this.radius = Math.sqrt(Number(value) / Math.PI);
    }
}
let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.area = 113.04;
console.log(`Radius: ${c.radius}`);