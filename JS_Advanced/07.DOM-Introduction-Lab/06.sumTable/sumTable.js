function sumTable() {
    document.getElementById('sum').innerHTML = Array.from(document.querySelectorAll('tbody tr td:last-child:not(#sum)')).map(x => Number(x.innerHTML)).reduce((acc,el) => acc + el,0);
}