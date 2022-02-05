const rgbToHexColor = require('./06RGBtoHex.js');
function isSymmetric(arr) {
    if (!Array.isArray(arr)){
        return false; // Non-arrays are non-symmetric
    }
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

console.log(rgbToHexColor(0, 0, 0));
module.exports = isSymmetric;