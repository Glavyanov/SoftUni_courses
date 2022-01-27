function focused() {
    let inputElements = Array.from(document.querySelectorAll('[type = "text"]'));
    inputElements.forEach(x => {
        x.addEventListener('focus', (e) => {
            e.currentTarget.parentNode.className = 'focused';
        });
        x.addEventListener('blur', (e) => {
            e.currentTarget.parentNode.className = '';
        });
    })
}