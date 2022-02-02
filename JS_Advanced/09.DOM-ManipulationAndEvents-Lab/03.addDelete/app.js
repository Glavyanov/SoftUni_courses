function addItem() {
    let text = document.getElementById('newItemText').value;
    let ulElement = document.getElementById('items');
    let liElement = document.createElement('li');
    let aElement = document.createElement('a');
    aElement.href = '#';
    aElement.textContent = '[Delete]';
    liElement.textContent = text;
    liElement.appendChild(aElement);
    aElement.addEventListener('click', (e) => {
        e.currentTarget.parentNode.remove();
    });
    document.getElementById('newItemText').value = '';

    text ? text.search(/^\s*$/) == -1 ? ulElement.appendChild(liElement) : null : null;

}