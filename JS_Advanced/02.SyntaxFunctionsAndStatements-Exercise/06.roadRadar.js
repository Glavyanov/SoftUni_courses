function solve(speed, area){
    let allowedSpeed = 0;
    switch (area) {
        case 'motorway':
            allowedSpeed = 130;
            break;
        case 'interstate':
            allowedSpeed = 90;
            break;
        case 'city':
            allowedSpeed = 50;
            break;
        case 'residential':
            allowedSpeed = 20;
            break;
        default:
            break;
    }
    let driving;
    if (speed <= allowedSpeed) {
        driving = `Driving ${speed} km/h in a ${allowedSpeed} zone`;
    }else{
        let result = speed - allowedSpeed;
        let drivingType;
        if(result < 21){
            drivingType = 'speeding';
        }else if(result < 41){
            drivingType = 'excessive speeding';
        }else{
            drivingType = 'reckless driving';
        }
        driving = `The speed is ${result} km/h faster than the allowed speed of ${allowedSpeed} - ${drivingType}`
    }
    return driving;
}