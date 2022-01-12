function solve(obj) {
    const storage = {
        'Small engine': { power: 90, volume: 1800 },
        'Normal engine': { power: 120, volume: 2400 },
        'Monster engine': { power: 200, volume: 3500 },
        Hatchback: { type: 'hatchback', color: '' },
        Coupe: { type: 'coupe', color: '' },
    };
    let result = {};
    result[Object.keys(obj)[0]] = obj.model;
    result.engine = obj.power <= 90 ? storage['Small engine'] : obj.power <= 120 ? storage['Normal engine'] : storage['Monster engine'];
    result.carriage = { type: obj.carriage, color: obj.color };
    result.wheels = [0, 0, 0, 0];
    obj.wheelsize % 2 !== 1 ? result.wheels.fill(obj.wheelsize - 1) : result.wheels.fill(obj.wheelsize);
    return result;
}