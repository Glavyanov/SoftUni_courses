function encodeAndDecodeMessages() {
    let elementToSend = document.querySelector('div#container #main:first-child textarea');
    let elementToReceive = document.querySelector('div#container #main div:last-child textarea');
    let buttonSend = document.querySelector('div#container #main:first-child button');
    let buttonReceived = document.querySelector('div#container #main div:last-child button');
    buttonSend.addEventListener('click', e => {
        let text = elementToSend.value;
        elementToSend.value = '';
        if (text && text.search(/^\s*$/)) {
            text = text.split('').map(x => String.fromCharCode(x.charCodeAt(0) + 1)).join('');
            elementToReceive.textContent = text;
        }
    });
    buttonReceived.addEventListener('click', e => {
        let text = elementToReceive.textContent;
        if (text && text.search(/^\s*$/)) {
            text = text.split('').map(x => String.fromCharCode(x.charCodeAt(0) - 1)).join('');
            elementToReceive.textContent = text;
        }
    });
}