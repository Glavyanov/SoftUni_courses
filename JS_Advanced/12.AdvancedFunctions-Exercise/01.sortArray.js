function sol(arr, str) {
    return str === 'asc' ? arr.sort((a, b) => a - b) : arr.sort((a, b) => b - a);
}
