function solve(arr,rotations){
    let realRotations = rotations % arr.length;
    let elements = arr.splice(arr.length - realRotations,realRotations);
    arr.splice(0,0,...elements);
    return arr.join(' ');
}