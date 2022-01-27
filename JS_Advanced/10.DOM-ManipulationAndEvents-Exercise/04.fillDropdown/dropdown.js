function addItem() {
    let selectElement = document.querySelector('#menu');
    let inputItemText = document.querySelector('#newItemText').value;
    let inputItemValue = document.querySelector('#newItemValue').value;
    if (inputItemText && inputItemValue && inputItemText.search(/^\s*$/) == -1
        && inputItemValue.search(/^\s*$/) == -1) {
        let optionElement = document.createElement('option');
        optionElement.textContent = inputItemText;
        optionElement.value = inputItemValue;
        selectElement.appendChild(optionElement);

    }
    document.querySelector('#newItemText').value = '';
    document.querySelector('#newItemValue').value = '';
}