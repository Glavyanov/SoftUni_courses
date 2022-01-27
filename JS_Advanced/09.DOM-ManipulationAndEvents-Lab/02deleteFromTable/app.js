function deleteByEmail() {
    let inputElement = document.querySelector('[name = "email"]');
    let [...tdEmails] = document.querySelectorAll('tbody td:nth-of-type(2)');
    let divResultElement = document.getElementById('result');
    divResultElement.textContent = '';
    tdEmails.forEach(x => {
        if (x.textContent == inputElement.value.trim()) {
            // x.parentNode.parentNode.removeChild(x.parentNode);
            x.parentNode.remove();
            divResultElement.textContent = 'Deleted.';
        }
    })
    if (!divResultElement.textContent) {
        divResultElement.textContent = 'Not found.';
    }
    inputElement.value = '';
}