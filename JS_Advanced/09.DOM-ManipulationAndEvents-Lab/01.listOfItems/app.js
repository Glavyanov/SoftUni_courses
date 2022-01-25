function addItem() {
    let ulElement = document.getElementById('items');
    let liElement = document.createElement('li');
    let text = document.getElementById('newItemText').value;
    document.getElementById('newItemText').value = '';
    liElement.textContent = text;
    text ? text.search(/^\s*$/) !== -1 ? ulElement.appendChild(liElement) : null : null;
}