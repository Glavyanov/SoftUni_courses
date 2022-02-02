function solve() {
  let generateBtn = document.querySelector('#exercise button:first-of-type');
  let resultText = document.querySelector('#exercise textarea:last-of-type');

  let store = [];
  let checkBoxArr = [];
  let boughtNames = [];
  let totalPrice = 0;
  let sumDecorFactor = 0;
  let resultContent = '';
  generateBtn.addEventListener('click', () => {
    let textToGenerate = document.querySelector('#exercise textarea:first-of-type');
    store = JSON.parse(textToGenerate.value);
    if (store.length) {
      store.forEach(x => {
        let tableBody = document.querySelector('.table tbody');
        let trElement = document.createElement('tr');
        let imgEl = document.createElement('img');
        imgEl.setAttribute('src', x.img);
        let tdEl = document.createElement('td');
        tdEl.appendChild(imgEl);
        trElement.appendChild(tdEl);
        let pNameElement = document.createElement('p');
        pNameElement.textContent = x.name;
        let tdElName = document.createElement('td');
        tdElName.appendChild(pNameElement);
        trElement.appendChild(tdElName);
        let pElementPrice = document.createElement('p');
        pElementPrice.textContent = x.price;
        let tdElPrice = document.createElement('td');
        tdElPrice.appendChild(pElementPrice);
        trElement.appendChild(tdElPrice);
        let pElementDecor = document.createElement('p');
        pElementDecor.textContent = x.decFactor;
        let tdElDecor = document.createElement('td');
        tdElDecor.appendChild(pElementDecor);
        trElement.appendChild(tdElDecor);
        let inputElement = document.createElement('input');
        inputElement.setAttribute('type', 'checkbox');
        let tdInputElement = document.createElement('td');
        tdInputElement.appendChild(inputElement);
        trElement.appendChild(tdInputElement);

        tableBody.appendChild(trElement);
      });
      checkBoxArr = Array.from(document.querySelectorAll('.table tbody [type="checkbox"]'));
      checkBoxArr.forEach(x => x.disabled = false);
    }

  });
  let buyBtn = document.querySelector('#exercise button:last-of-type');
  buyBtn.addEventListener('click', (e) => {
    for (const element of checkBoxArr) {
      if (element.checked == true) {
        boughtNames.push(element.parentNode.parentNode.querySelector('td:nth-of-type(2) p').textContent);
        totalPrice += Number(element.parentNode.parentNode.querySelector('td:nth-of-type(3) p').textContent);
        sumDecorFactor += Number(element.parentNode.parentNode.querySelector('td:nth-of-type(4) p').textContent);
      }
    }
    resultContent = `Bought furniture: ${boughtNames.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${sumDecorFactor / boughtNames.length}`;
    resultText.textContent = resultContent;
  });

}