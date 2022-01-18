function extractText() {
    const [...elements] = document.querySelectorAll('#items li');
    let textToAppend = '';
    elements.forEach( el => textToAppend += el.innerHTML + '\n' );
    const elementsToWrite = document.getElementById('result');
    elementsToWrite.innerHTML = textToAppend;

}