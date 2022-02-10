function validate() {
    let inputElement = document.querySelector('body #email');
    inputElement.addEventListener('change', (e) => {
        if (e.currentTarget.value) {
            inputElementCheck = e.currentTarget.value.match(/^[a-z\d]+@{1}[a-z\d]+.{1}[a-z]{3}$/gm);
            !inputElementCheck ? e.currentTarget.className = 'error' : e.currentTarget.className = '';
        }
    });
    
}