function colorize() {
     let [...result] = document.querySelectorAll('table tr');
     result.forEach((tr, i) => i % 2 == 1 ? tr.style.background = 'teal': tr);
}